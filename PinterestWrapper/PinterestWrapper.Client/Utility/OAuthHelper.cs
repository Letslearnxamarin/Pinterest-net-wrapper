
using PinterestService.Client.Requests;
using PinterestService.Client.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinterestService.Client.Utility
{
    internal class OAuthHelper
    {
        public ConfigHelper Config;

        private string ClientId { get; set; }
        private string ClientSecret { get; set; }

        public OAuthHelper(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Config = new ConfigHelper();
        }

        public string AuthorizationCodeUrl
        {
            get
            {
                return $@"{Config.BaseUrl}/oauth/?
                                response_type=code&
                                redirect_uri={Config.RedirectUri}&
                                client_id={ClientId}&
                                scope={Config.RedirectUri}&
                                state={Config.State}";
            }
        }

        public string AccessTokenRequestUrl()
        {
            return $@"{Config.BaseUrl}{Config.Version}/oauth/token";
        }

        public TokenRequest GetTokenRequest(string accessCode)
        {
          
            if (string.IsNullOrEmpty(accessCode))
            {
                throw new ArgumentNullException(nameof(accessCode));
            }


            return new TokenRequest() { Client_Id = ClientId, Client_Secret = ClientSecret, Code = accessCode, Grant_Type = "authorization_code" };
        }

    }
}
