using Newtonsoft.Json;
using PinterestService.Client.Utility;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PinterestService.Client
{
    internal abstract class BaseService
    {
        public RequestStatus Status { get; set; }

        public BaseService()
        {
            Status = new RequestStatus();
        }

        public async Task<TResult> PostAsync<T, TResult>(string url, T jsonObject)
        {
            return await Execute(url, jsonObject, async (p, c) =>
            {

                var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                var response = await c.PostAsync(url, content);
                return await GetResponseString<TResult>(response);

            });
        }

        public async Task<TResult> GetAsync<TResult>(string url)
        {
            return await Execute(url, async (c) =>
            {

                var response = await c.GetAsync(url);
                return await GetResponseString<TResult>(response);

            });
        }

        public async Task<TResult> DeleteAsync<TResult>(string url)
        {
            return await Execute(url, async (c) =>
            {
                var response = await c.DeleteAsync(url);
                return await GetResponseString<TResult>(response);

            });
        }

        public async Task<TResult> DeleteAsync<T, TResult>(string url, T jsonObject)
        {
            return await Execute(url, jsonObject, async (p, c) =>
            {
                var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                var response = await c.DeleteAsync(url, content);
                return await GetResponseString<TResult>(response);

            });
        }

        public async Task<TResult> PatchAsync<T, TResult>(string url, T jsonObject)
        {
            return await Execute(url, jsonObject, async (p, c) =>
            {
                var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                var response = await c.PatchAsync(url, content);
                return await GetResponseString<TResult>(response);

            });
        }

        public async Task<TResult> PutAsync<T, TResult>(string url, T jsonObject)
        {
            return await Execute(url, jsonObject, async (p, c) =>
            {
                var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                var response = await c.PutAsync(url, content);
                return await GetResponseString<TResult>(response);

            });
        }

        private async Task<TResult> Execute<T, TResult>(string url, T payload, Func<T, HttpClient, Task<TResult>> action)
        {
            Status.Request = RequestStatusEnum.Executed;

            UrlCheck(url);

            if (payload == null)
                throw new Exception("No Payload provided");

            using (var client = GetClient(url))
            {
                return await action(payload, client);
            }

        }

        private async Task<TResult> Execute<TResult>(string url, Func<HttpClient, Task<TResult>> action)
        {
            Status.Request = RequestStatusEnum.Executed;

            UrlCheck(url);

            using (var client = GetClient(url))
            {
                return await action(client);
            }

        }

        private void UrlCheck(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception("No Url Provided");
            }
        }

        public virtual HttpClient GetClient(string url)
        {
            var client = new HttpClient();
            return client;
        }

        private async Task<TResult> GetResponseString<TResult>(HttpResponseMessage response)
        {
            try
            {
                response.EnsureSuccessStatusCode();
                Status.Request = RequestStatusEnum.AwaitResponse;
                var result = await response.Content.ReadAsStringAsync();
                Status.Request = RequestStatusEnum.Complete;
                return JsonConvert.DeserializeObject<TResult>(result);
            }
            catch
            {
                Status.Request = RequestStatusEnum.Error;
                throw;
            }
        }

    }
}
