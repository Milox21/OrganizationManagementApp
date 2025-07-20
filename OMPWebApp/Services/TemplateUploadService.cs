using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;

namespace OMPWebApp.Services
{
    public class TemplateUploadService
    {
        private readonly HttpClient _http;
        private readonly AuthorizationService _auth;

        public TemplateUploadService(HttpClient http, AuthorizationService auth)
        {
            _http = http;
            _auth = auth;
        }

        public async Task<string> UploadTemplateAsync(IBrowserFile file)
        {
            var content = new MultipartFormDataContent();

            var streamContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024));
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            content.Add(streamContent, "file", file.Name);

            _http.DefaultRequestHeaders.Remove("CustomerId");
            _http.DefaultRequestHeaders.Add("CustomerId", _auth.userDTO.CustomerId.ToString());

            var response = await _http.PostAsync("/api/Printout/upload-template", content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}