using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PinterestService.Client
{
    public abstract class PinterestService : BaseService
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

        public string Token { get; set; }

        public string BaseUrl { get { return $"https://api.pinterest.com/{Version}/"; } }

        public override HttpClient GetClient()
        {
            if (string.IsNullOrEmpty(Token))
                throw new Exception("Missing Access Token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("access_token", Token);
            return client;
        }
    }
}
