using PinterestService.Client.DataContracts;
using PinterestService.Client.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinterestService.Client
{
    public class AuthServiceClient 
    {
        private readonly AuthService _authService;
        private string AccessToken { get; set; }



        public AuthServiceClient(string clientId, string clientSecret)
        {
            _authService = new AuthService(clientId, clientSecret);
        }


        #region AuthService

        public string GetAuthorizationUrl() => _authService.Auth.AuthorizationCodeUrl;

        public async Task<string> GetAccessToken(string accessCode)
        {
            return await _authService.GetAccessToken(accessCode);
        }

        #endregion

    }
}
