using ApiStorageManager.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using File = ApiStorageManager.Domain.Models.File;

namespace ApiStorageManager.Infra.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IConfiguration _configuration;
        public FileRepository(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public IUnitOfWork UnitOfWork { get; set; }

        public async Task<File> GetById(Guid id, string empresa, int codigoEvento)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["StorageInfo:StorageEndpoint"]}/public/eventos/empresas/{empresa}/{codigoEvento}/documentos/{id}");
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");

            request.Headers.Accept.Add(mediaType);
            request.Headers.Add("ApiKey", _configuration["StorageInfo:ApiKey"]);
            request.Headers.Add("Authorization", $"Bearer {_configuration["StorageInfo:AnonToken"]}");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["StorageInfo:UrlBase"]);
                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        string line = null;
                        while((line = await streamReader.ReadLineAsync()) != null)
                        {
                            if(line.Contains("404"))
                            {
                                return null;
                            }
                        }
                        using (var jsonTextReader = new JsonTextReader(streamReader))
                        {
                            File file = new();
                            return file;
                        }
                    }
                }
            }
        }

        public async void Add(File file)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["StorageInfo:StorageEndpoint"]}/{file.Url}");
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");

            request.RequestUri = new Uri($"{_configuration["StorageInfo:UrlBase"]}/{_configuration["StorageInfo:StorageEndpoint"]}/{file.Url}");
            request.Headers.Accept.Add(mediaType);
            request.Headers.Add("ApiKey", _configuration["StorageInfo:ApiKey"]);
            request.Headers.Add("Authorization", $"Bearer {_configuration["StorageInfo:AnonToken"]}");

            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                client.BaseAddress = new Uri(_configuration["StorageInfo:UrlBase"]);

                HttpContent bytesContent = new ByteArrayContent(file.Bytes);
                bytesContent.Headers.ContentType = new MediaTypeHeaderValue(file.Type);

                formData.Add(bytesContent, "fileName", file.Name);
                request.Content = bytesContent;
                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    var details = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var details = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async void Update(File file) 
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["StorageInfo:StorageEndpoint"]}/{file.Url}");
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");

            request.Headers.Accept.Add(mediaType);
            request.Headers.Add("ApiKey", _configuration["StorageInfo:ApiKey"]);
            request.Headers.Add("Authorization", _configuration["StorageInfo:AnonKey"]);

            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                client.BaseAddress = new Uri(_configuration["StorageInfo:UrlBase"]);

                HttpContent bytesContent = new ByteArrayContent(file.Bytes);
                bytesContent.Headers.ContentType = new MediaTypeHeaderValue(file.Type);

                formData.Add(bytesContent, "fileName", file.Name);

                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    var details = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async void Delete(File file) 
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["StorageInfo:StorageEndpoint"]}/{file.Url}");
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");

            request.Headers.Accept.Add(mediaType);
            request.Headers.Add("ApiKey", _configuration["StorageInfo:ApiKey"]);
            request.Headers.Add("Authorization", _configuration["StorageInfo:AnonKey"]);

            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                client.BaseAddress = new Uri(_configuration["StorageInfo:UrlBase"]);

                HttpContent bytesContent = new ByteArrayContent(file.Bytes);
                bytesContent.Headers.ContentType = new MediaTypeHeaderValue(file.Type);

                formData.Add(bytesContent, "fileName", file.Name);

                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    var details = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public void Dispose()
        {
            
        }
    }
}
