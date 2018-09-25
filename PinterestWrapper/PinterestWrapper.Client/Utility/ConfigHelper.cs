using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PinterestService.Tests")]
namespace PinterestService.Client.Utility
{
    public class ConfigHelper : IConfigHelper
    {
        readonly IConfigurationRoot _configuration;

        public ConfigHelper()
        {
            _configuration = new ConfigurationBuilder()
            .SetBasePath(System.AppContext.BaseDirectory)
            .AddJsonFile("appSettings.json")
            .Build();
        }

        public string GetSetting(string key)
        {
            return _configuration[key];
        }

        public string BaseUrl { get { return $"{GetSetting("BaseSettings:url")}"; } }

        public string Version { get { return $"{GetSetting("BaseSettings:version")}"; } }

        public string RedirectUri { get { return $"{GetSetting("BaseSettings:redirect_uri")}"; } }

        public string State { get { return $"{GetSetting("BaseSettings:state")}"; } }

        public string Scope { get { return $"{GetSetting("BaseSettings:scope")}"; } }


    }
}
