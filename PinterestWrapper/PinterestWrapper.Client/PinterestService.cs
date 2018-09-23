using PinterestService.Client.Utility;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PinterestService.Client
{
    internal class PinterestService : BaseService
    {
        public ConfigHelper Config;

        private readonly string AccessToken;

        public PinterestService(string accessToken)
        {
            Config = new ConfigHelper();
            AccessToken = accessToken;
        }

        public override HttpClient GetClient(string url)
        {
            Uri request = new Uri(url);
            var client = new HttpClient();

            if (request.AbsolutePath.Contains("oauth"))
            {
                return client;
            }
            else
            {
                if (string.IsNullOrEmpty(AccessToken))
                    throw new ArgumentNullException($"{nameof(AccessToken)} Missing Access Token");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("access_token", AccessToken);
                return client;
            }

        }

        public string BuildRequestUrl(string call)
        {
            return $"{Config.BaseUrl}{Config.Version}{call}";
        }

    }
}
