using System.Threading.Tasks;

namespace PinterestService.Client.Services
{
    internal interface IAuthService
    {
        Task<string> GetAccessToken(string accessCode);
    }
}