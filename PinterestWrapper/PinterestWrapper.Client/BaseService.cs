using Newtonsoft.Json;
using PinterestService.Client.Utility;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PinterestService.Client
{
    public abstract class BaseService
    {
        public RequestStatus Status { get; set; }
        public string Url { get; set; }


        public async Task<TResult> Post<T, TResult>(string token, T jsonObject)
        {
            return await Execute(jsonObject, async (p, c) =>
            {

                var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                var response = await c.PostAsync(Url, content);
                return await GetResponseString<TResult>(response);

            });
        }

        public async Task<TResult> GetAsync<T, TResult>()
        {
            return await Execute(async (c) =>
            {

                var response = await c.GetAsync(Url);
                return await GetResponseString<TResult>(response);

            });
        }

        public async Task<TResult> DeleteAsync<T, TResult>()
        {
            return await Execute(async (c) =>
            {

                var response = await c.DeleteAsync(Url);
                return await GetResponseString<TResult>(response);

            });
        }

        public async Task<TResult> PatchAsync<T, TResult>(T jsonObject)
        {
            return await Execute(jsonObject, async (p, c) =>
            {
                var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                var response = await c.PatchAsync(Url, content);
                return await GetResponseString<TResult>(response);

            });
        }

        public async Task<TResult> PutAsync<T, TResult>(T jsonObject)
        {
            return await Execute(jsonObject, async (p, c) =>
            {
                var content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                var response = await c.PutAsync(Url, content);
                return await GetResponseString<TResult>(response);

            });
        }

        private async Task<TResult> Execute<T, TResult>(T payload, Func<T, HttpClient, Task<TResult>> action)
        {
            Status.Request = RequestStatusEnum.Executed;

            UrlCheck();

            if (payload == null)
                throw new Exception("No Payload provided");
            
            using (var client = GetClient())
            {
                return await action(payload, client);
            }

        }

        private async Task<TResult> Execute<TResult>(Func<HttpClient, Task<TResult>> action)
        {
            Status.Request = RequestStatusEnum.Executed;

            UrlCheck();

            using (var client = GetClient())
            {
                return await action(client);
            }

        }

        private void UrlCheck()
        {
            if (string.IsNullOrEmpty(Url))
            {
                throw new Exception("No Url Provided");
            }
        }

        public virtual HttpClient GetClient()
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
