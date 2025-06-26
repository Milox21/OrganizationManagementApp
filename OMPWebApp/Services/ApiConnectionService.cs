﻿using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

namespace OMPWebApp.Services
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
        public async Task ExecuteGetRequest(string address)
        {
            await _httpClient.GetAsync(address);
        }

        public async Task<T> GetResource(string address)
        {

            var response = await _httpClient.GetStringAsync(address);
            var resource = JsonSerializer.Deserialize<T>(response, _jsonOptions);
            return resource;
        }

        public async Task<List<T>> GetResources(string address)
        {
            try
            {

                var response = await _httpClient.GetStringAsync(address);
                var resources = JsonSerializer.Deserialize<List<T>>(response, _jsonOptions);
                return resources;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task PostResource(string address, T resource)
        {
            try
            {
                var jsonResource = JsonSerializer.Serialize(resource, _jsonOptions);
                var content = new StringContent(jsonResource, Encoding.UTF8, "application/json");
                await _httpClient.PostAsync(address, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async Task PutResource(string address, T resource)
        {
            var jsonResource = JsonSerializer.Serialize(resource, _jsonOptions);
            var content = new StringContent(jsonResource, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(address, content);
        }

        public async Task DeleteResource(string address)
        {
            await _httpClient.DeleteAsync(address);
        }
    }
}

