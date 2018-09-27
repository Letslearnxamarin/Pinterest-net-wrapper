using System.Net.Http;

namespace PinterestService.Client
{
    public interface IPinterestService
    {
        string BuildRequestUrl(string call);
        HttpClient GetClient(string url);
    }
}