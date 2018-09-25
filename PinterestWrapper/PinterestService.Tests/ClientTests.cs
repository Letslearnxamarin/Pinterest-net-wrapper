using Moq;
using PinterestService.Client;
using PinterestService.Client.DataContracts;
using PinterestService.Client.Services;
using PinterestService.Client.Utility;
using System;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;
using Xunit;

namespace PinterestService.Tests
{
    public class ClientTests : IDisposable
    {
        Mock<IBoardService> _boardServiceMock;
        Mock<IPinService> _pinServiceMock;
        Mock<IUserService> _userServiceMock;
        Mock<ISectionService> _sectionServiceMock;
        Mock<IAuthService> _authServiceMock;

        IPinterestServiceClient _serviceClient;
        
        const string AuthToken = "123123asdf123123";
        const string AccessToken = "alskdjflkasdzjfskj198231231";

        public ClientTests()
        {
            _boardServiceMock = new Mock<IBoardService>();
            _pinServiceMock = new Mock<IPinService>();
            _userServiceMock = new Mock<IUserService>();
            _sectionServiceMock = new Mock<ISectionService>();
            _authServiceMock = new Mock<IAuthService>();
        }


        [Fact]
        public async void CreateBoard_NotNull_Test()
        {
            // Assign
            _boardServiceMock.Setup(x => x.CreateBoard("TestBoard", "")).Returns(Task.FromResult(new Board() { Name = "TestBoard" }));
            
            SetTestClient();

            //// Act 
            var response = await _serviceClient.CreateBoard("TestBoard", "");

            _boardServiceMock.Verify(x => x.CreateBoard("TestBoard",""));

            Assert.NotNull(response);
        }

        [Fact]
        public async void CreatePin_NotNull_Test()
            // Assign
        {
            
           _pinServiceMock.Setup(x => x.CreatePin("Monkey", "Bananas", "Monkey with a banana", null, null, null, null)).Returns(Task.FromResult(new Pin() {Id = 123 }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.CreatePin("Monkey", "Bananas", "Monkey with a banana");

            _pinServiceMock.Verify(x => x.CreatePin("Monkey", "Bananas", "Monkey with a banana", null, null, null, null));

            Assert.NotNull(response);
        }

        [Fact]
        public async void CreateSection_NotNull_Test()
        // Assign
        {

            _sectionServiceMock.Setup(x => x.CreateSection("Yellow", "Hat", "Man")).Returns(Task.FromResult(new Section() { Id = 2 }));
            SetTestClient();

            //// Act 
            var response = await _serviceClient.CreateSection("Yellow", "Hat", "Man");

            _sectionServiceMock.Verify(x => x.CreateSection("Yellow", "Hat", "Man"));

            Assert.NotNull(response);
        }

        [Fact]
        public async void GetUser_NotNull_Test()
        // Assign
        {
            _userServiceMock.Setup(x => x.GetUser()).Returns(Task.FromResult(new User() { First_Name = "George" }));
            
            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetUser();

            _userServiceMock.Verify(x => x.GetUser());

            Assert.NotNull(response);
        }




        private void SetTestClient()
        {
            _serviceClient = new PinterestServiceClient(_boardServiceMock.Object, _pinServiceMock.Object, _userServiceMock.Object, _sectionServiceMock.Object);
        }
        
        //teardown
        public void Dispose()
        {
        }
    }
}
