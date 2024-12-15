using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OMPWebAppAdmin.Services
{
    public class AuthorizationService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public bool isLogged { get; set; }
        private string accessToken = " ";
        private string refreshToken = " ";
        private DateTime? expiresAt = null;

        public AuthorizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
            };
            isLogged = false;
        }

        public async Task<string> Login(string email, string password)
        {
            var data = new
            {
                email,
                password
            };

            string jsonProfile = JsonSerializer.Serialize(data, _jsonOptions);
            var content = new StringContent(jsonProfile, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "api/AdminLogin/adminlogin") 
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
                    isLogged = true;
                }
                return "OK";
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            var errorResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);
            if (errorResponse != null && errorResponse.TryGetValue("errors", out var errors))
            {
                var errorsDict = JsonSerializer.Deserialize<Dictionary<string, string[]>>(errors.ToString());
                return errorsDict?.FirstOrDefault().Value?.FirstOrDefault() ?? "Unknown error.";
            }

            return "Unknown error.";
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

        public async Task IsLogged()
        {
            if (accessToken == " " || refreshToken == " " || expiresAt == null || expiresAt < DateTime.Now)
            {
                isLogged = false;
            }
            isLogged = true;
        }
    }
}
