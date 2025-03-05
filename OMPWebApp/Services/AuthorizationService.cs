using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClassLibrary.DTO;

namespace OMPWebApp.Services
{
    public class AuthorizationService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        public UserDTO userDTO;
        public bool isLogged { get; set; }
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
            };

            isLogged = false;
            if (userDTO.Name != null)
            {
                isLogged = true;
            }
            
            isUserComplete = IsUserComplete();
        }

        public async Task<string> Login(string email, string password)
        {

            // First request
            var data = new
            {
                email,
                password
            };

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
                    {
                        accessToken = accessTokenElement.GetString();
                    }

                    if (result.TryGetProperty("expiresIn", out JsonElement expiresIn))
                    {
                        expiresAt = DateTime.Now.AddSeconds(expiresIn.GetDouble());
                    }

                    if (result.TryGetProperty("refreshToken", out JsonElement refreshTokenElement))
                    {
                        refreshToken = refreshTokenElement.GetString();
                    }
                    
                }
            }

            // Prepare the second request (new HttpRequestMessage)
            var userdata = new
            {
                email,
                password
            };

            string userjsonProfile = JsonSerializer.Serialize(userdata, _jsonOptions);
            var usercontent = new StringContent(userjsonProfile, Encoding.UTF8, "application/json");

            var userrequest = new HttpRequestMessage(HttpMethod.Post, $"/api/AdminLogin/userlogin")
            {
                Content = usercontent
            };

            // Second request
            var userresponse = await _httpClient.SendAsync(userrequest);

            if (userresponse.IsSuccessStatusCode)
            {
                string userres = await userresponse.Content.ReadAsStringAsync();
                userDTO = JsonSerializer.Deserialize<UserDTO>(userres, _jsonOptions);
                isLogged = true;
                return "OK";
            }

            string responseContent = await userresponse.Content.ReadAsStringAsync();
            var errorResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);
            if (errorResponse != null && errorResponse.TryGetValue("errors", out var errors))
            {
                var errorsDict = JsonSerializer.Deserialize<Dictionary<string, string[]>>(errors.ToString());
                return errorsDict?.FirstOrDefault().Value?.FirstOrDefault() ?? "Unknown error.";
            }
            return "Server Error";
        }

        public async Task<string> Register(string email, string password)
        {
            var data = new
            {
                email,
                password
            };

            string jsonData = JsonSerializer.Serialize(data, _jsonOptions);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "register")
            {
                Content = content
            };

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

            foreach (var propertyName in requiredProperties)
            {
                var property = typeof(UserDTO).GetProperty(propertyName);
                if (property == null) continue;

                var value = property.GetValue(userDTO);
                if (value == null || (value is string str && string.IsNullOrWhiteSpace(str)))
                {
                    return false;
                }
            }

            return true;
        }
        public async Task IsLogged()
        {
            if (accessToken == " " || refreshToken == " " || expiresAt == null || expiresAt < DateTime.Now)
            {
                isLogged = false;
            }
            isLogged = true;
            
        }

        public async Task Logoff()
        {
            userDTO = new UserDTO();
            isLogged = false;
        }
    }
}
