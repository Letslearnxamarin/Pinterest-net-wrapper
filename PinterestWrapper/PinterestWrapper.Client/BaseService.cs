using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PinterestService.Client
{
    public abstract class BaseService
    {
        private string _version = "v1";
        public string Version
        {
            get
            {
                return _version;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _version = value;
                }
            }
        }

        string BaseUrl { get { return $"https://api.pinterest.com/{Version}/"; } }

        public string Type { get; set; }

        HttpRequestMessage _requestMessage { get; set; }

        public async Task<TResult> Post<T, TResult>(string token, T jsonObject)
        {
            return await Execute(token, jsonObject, async (p,c) => {

                var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                var response = await c.PostAsync(BaseUrl, content);

                try
                {
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResult>(result);
                }
                catch (Exception)
                {
                    throw;
                }

            });
        }

        public async Task<TResult> Get<T, TResult>(string token)
        {
            return await Execute(token, async (c) => {
                
                var response = await c.GetAsync(BaseUrl);

                try
                {
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResult>(result);
                }
                catch (Exception)
                {
                    throw;
                }

            });
        }

        public async Task<TResult> Delete<T, TResult>(string token)
        {
            return await Execute(token, async (c) => {

                var response = await c.DeleteAsync(BaseUrl);

                try
                {
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResult>(result);
                }
                catch (Exception)
                {
                    throw;
                }

            });
        }

        public async Task<TResult> Patch<T, TResult>(string token, T jsonObject)
        {
            return await Execute(token, jsonObject, async (p, c) => {

                var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                var response = await c.PutAsync(BaseUrl, content);

                try
                {
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResult>(result);
                }
                catch (Exception)
                {
                    throw;
                }

            });
        }

        public async Task<TResult> Execute<T, TResult>(string token, T payload, Func<T, HttpClient, Task<TResult>> action)
        {
            using (var client = GetClient(token))
            {
                return  await action(payload, client);
            }

        }

        public async Task<TResult> Execute<TResult>(string token, Func<HttpClient, Task<TResult>> action)
        {
            using (var client = GetClient(token))
            {
                return await action(client);
            }

        }

        private HttpClient GetClient(string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("access_token", token);
            return client;
        }

    }
}
