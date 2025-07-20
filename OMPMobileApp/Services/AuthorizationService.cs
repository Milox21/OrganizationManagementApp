using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using ClassLibrary.DTO;

namespace OMPMobileApp.Services
{
    public class AuthorizationService : INotifyPropertyChanged
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        public UserDTO userDTO;

        private bool _isLogged;
        public bool isLogged
        {
            get => _isLogged;
            set
            {
                if (_isLogged != value)
                {
                    _isLogged = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(isLogged)));
                }
            }
        }

        public bool isUserComplete { get; set; }
        private string accessToken = " ";
        private string refreshToken = " ";
        private DateTime? expiresAt = null;

        public AuthorizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            userDTO = new UserDTO();

            _jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                PropertyNameCaseInsensitive = true
            };

            //SecureStorage.Remove("userData");
            //SecureStorage.Remove("password");

            isLogged = false;
            if (userDTO.Name != null)
            {
                isLogged = true;
            }

            isUserComplete = IsUserComplete();
            //_ = CheckIfLogged();
        }

        public async Task CheckIfLogged()
        {
            try
            {
                var password = await SecureStorage.GetAsync("password");
                var userJson = await SecureStorage.GetAsync("userData");

                if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(userJson))
                {
                    userDTO = JsonSerializer.Deserialize<UserDTO>(userJson, _jsonOptions);
                    await Login(userDTO.Email, password);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking login: {ex.Message}");
            }
        }

        public async Task<string> Login(string email, string password)
        {
            var data = new { email, password };
            string jsonProfile = JsonSerializer.Serialize(data, _jsonOptions);
            var content = new StringContent(jsonProfile, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "login")
            {
                Content = content
            };

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                using (JsonDocument responseBody = JsonDocument.Parse(res))
                {
                    JsonElement result = responseBody.RootElement;

                    if (result.TryGetProperty("accessToken", out JsonElement accessTokenElement))
                        accessToken = accessTokenElement.GetString();

                    if (result.TryGetProperty("expiresIn", out JsonElement expiresIn))
                        expiresAt = DateTime.Now.AddSeconds(expiresIn.GetDouble());

                    if (result.TryGetProperty("refreshToken", out JsonElement refreshTokenElement))
                        refreshToken = refreshTokenElement.GetString();
                }
            }

            // Second request to load full user profile
            var userRequest = new HttpRequestMessage(HttpMethod.Post, "/api/AdminLogin/userlogin")
            {
                Content = content
            };

            var userResponse = await _httpClient.SendAsync(userRequest);

            if (userResponse.IsSuccessStatusCode)
            {
                string userRes = await userResponse.Content.ReadAsStringAsync();
                userDTO = JsonSerializer.Deserialize<UserDTO>(userRes, _jsonOptions);

                string userJson = JsonSerializer.Serialize(userDTO, _jsonOptions);
                await SecureStorage.SetAsync("userData", userJson);
                await SecureStorage.SetAsync("password", password);

                isLogged = true;
                return "OK";
            }

            string errorContent = await userResponse.Content.ReadAsStringAsync();
            var errorResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(errorContent);
            if (errorResponse != null && errorResponse.TryGetValue("errors", out var errors))
            {
                var errorsDict = JsonSerializer.Deserialize<Dictionary<string, string[]>>(errors.ToString());
                return errorsDict?.FirstOrDefault().Value?.FirstOrDefault() ?? "Unknown error.";
            }

            return "Server Error";
        }

        public async Task<string> Register(string email, string password)
        {
            var data = new { email, password };
            string jsonData = JsonSerializer.Serialize(data, _jsonOptions);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "register") { Content = content };
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
                return "OK";

            string responseContent = await response.Content.ReadAsStringAsync();
            var errorResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);
            if (errorResponse != null && errorResponse.TryGetValue("errors", out var errors))
            {
                var errorsDict = JsonSerializer.Deserialize<Dictionary<string, string[]>>(errors.ToString());
                return errorsDict?.FirstOrDefault().Value?.FirstOrDefault() ?? "Unknown error.";
            }

            return "Unknown error.";
        }

        public bool IsUserComplete()
        {
            var requiredProperties = new[] { "Name", "Surname" };
            foreach (var prop in requiredProperties)
            {
                var property = typeof(UserDTO).GetProperty(prop);
                if (property == null) continue;

                var value = property.GetValue(userDTO);
                if (value == null || (value is string s && string.IsNullOrWhiteSpace(s)))
                    return false;
            }

            return true;
        }

        public async Task IsLogged()
        {
            isLogged = !(accessToken == " " || refreshToken == " " || expiresAt == null || expiresAt < DateTime.Now);
        }

        public async Task Logoff()
        {
            userDTO = new UserDTO();
            isLogged = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(isLogged))); // ADD THIS

            await SecureStorage.SetAsync("userData", "");
            await SecureStorage.SetAsync("password", "");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
