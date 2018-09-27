using PinterestService.Client.Services;
using PinterestService.Client.Utility;
using System;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;
using Xunit;

namespace PinterestService.Tests
{
    public class UtilityTests : IDisposable
    {
        public UtilityTests()
        {
        }

        [Fact]
        public void GetAppSetting_Test()
        {
            // Assign
            var sut = new ConfigHelper();
            
            //// Act 
            var response = sut.GetSetting("BaseSettings:redirect_uri");
            
            //  Assert
            Assert.Equal("Https://MyCoolSite.com", response);
        }

        //teardown
        public void Dispose()
        {
        }
    }
}
