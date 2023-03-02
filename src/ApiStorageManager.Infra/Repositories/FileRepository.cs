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

                client.BaseAddress = new Uri(_configuration["StorageInfo:UrlBase"]!);
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

        public async Task Add(File file)
        {
            var url = _configuration["StorageInfo:StorageEndpoint"];
            var key = _configuration["StorageInfo:ApiKey"];
            var supabase = new Supabase.Client(url, key, new Supabase.SupabaseOptions { AutoConnectRealtime = true });
            await supabase.InitializeAsync();

            var storage = supabase.Storage;
            var exists = await storage.GetBucket("eventos") != null;
            if (!exists)
                throw new Exception("O bucket informado não exite.");

            var bucket = storage.From("eventos");
            try
            {
                await bucket.Upload(file.Bytes, file.Url);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao inserir o arquivo no bucket", ex);
            } 
        }

        public async Task Update(File file) 
        {
            var url = _configuration["StorageInfo:StorageEndpoint"];
            var key = _configuration["StorageInfo:ApiKey"];
            var supabase = new Supabase.Client(url, key, new Supabase.SupabaseOptions { AutoConnectRealtime = true });
            await supabase.InitializeAsync();

            var storage = supabase.Storage;
            var exists = await storage.GetBucket("eventos") != null;
            if (!exists)
                throw new Exception("O bucket informado não exite.");

            var bucket = storage.From("eventos");
            try
            {
                await bucket.Update(file.Bytes, file.Url);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar o arquivo no bucket", ex);
            }
        }

        public async Task Delete(File file) 
        {

            var url = _configuration["StorageInfo:StorageEndpoint"];
            var key = _configuration["StorageInfo:ApiKey"];
            var supabase = new Supabase.Client(url, key, new Supabase.SupabaseOptions { AutoConnectRealtime = true });
            await supabase.InitializeAsync();

            var storage = supabase.Storage;
            var exists = await storage.GetBucket("eventos") != null;
            if (!exists)
                throw new Exception("O bucket informado não exite.");

            var bucket = storage.From("eventos");
            List<string> filePath = new()
            {
                file.Url
            };
            try
            {
                await bucket.Remove(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao inserir o arquivo no bucket", ex);
            }
        }

        public void Dispose()
        {
            
        }
    }
}
