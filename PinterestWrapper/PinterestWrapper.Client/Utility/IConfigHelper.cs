namespace PinterestService.Client.Utility
{
    public interface IConfigHelper
    {
        string BaseUrl { get; }
        string RedirectUri { get; }
        string Scope { get; }
        string State { get; }
        string Version { get; }

        string GetSetting(string key);
    }
}