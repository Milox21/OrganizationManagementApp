using System.Text.Json.Serialization;
using System.Text.Json;

namespace OmpAdminWeb.Services
{
    public class ApiConnectionService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiConnectionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
            };
        }
    }
}
