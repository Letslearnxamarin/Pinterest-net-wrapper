using PinterestService.Client.Requests;
using PinterestService.Client.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinterestService.Client.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public readonly OAuthHelper Auth;
        public AuthService(string clientId, string clientSecret)
        {
            Auth = new OAuthHelper(clientId, clientSecret);
        }
        
        public async Task<string> GetAccessToken(string accessCode)
        {
            var token = await PostAsync<TokenRequest, string>(Auth.AccessTokenRequestUrl(), Auth.GetTokenRequest(accessCode));
            return token;
        }

    }
}
