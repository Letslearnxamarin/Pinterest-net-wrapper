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


        #region Board Tests
        [Fact]
        public async void CreateBoard_NotNull_Test()
        {
            // Assign
            _boardServiceMock.Setup(x => x.CreateBoard("TestBoard", "")).Returns(Task.FromResult(new Board() { Name = "TestBoard" }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.CreateBoard("TestBoard", "");

            _boardServiceMock.Verify(x => x.CreateBoard("TestBoard", ""));

            Assert.NotNull(response);
        }
        
        [Fact]
        public async void GetBoard_NotNull_Test()
        {
            // Assign
            _boardServiceMock.Setup(x => x.GetBoard("test", "test")).Returns(Task.FromResult(new Board() { Name = "test"}));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetBoard("test", "test");

            _boardServiceMock.Verify(x => x.GetBoard("test", "test"));

            Assert.NotNull(response);
        }

        [Fact]
        public async void GetBoardPins_NotNull_Test()
        {
            // Assign
            _boardServiceMock.Setup(x => x.GetBoardPins("test", "test")).Returns(Task.FromResult(new Pins() { new Pin() { Url = "test" } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetBoardPins("test", "test");

            _boardServiceMock.Verify(x => x.GetBoardPins("test", "test"));

            Assert.NotNull(response);
        }

        [Fact]
        public async void GetUsersBoards_NotNull_Test()
        {
            // Assign
            _boardServiceMock.Setup(x => x.GetUsersBoards()).Returns(Task.FromResult(new Boards() { new Board() { Name = "test" } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetUsersBoards();

            _boardServiceMock.Verify(x => x.GetUsersBoards());

            Assert.NotNull(response);
        }

        [Fact]
        public async void EditBoard_NotNull_Test()
        {
            // Assign
            _boardServiceMock.Setup(x => x.EditBoard("test", "test","TestBoard", "Description")).Returns(Task.FromResult(new Board() { Name = "test" } ));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.EditBoard("test", "test", "TestBoard", "Description");

            _boardServiceMock.Verify(x => x.EditBoard("test", "test", "TestBoard", "Description"));

            Assert.NotNull(response);
        }

        [Fact]
        public async void DeleteBoard_True_Test()
        {
            // Assign
            _boardServiceMock.Setup(x => x.DeleteBoard("test", "test")).Returns(Task.FromResult(true));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.DeleteBoard("test", "test");

            _boardServiceMock.Verify(x => x.DeleteBoard("test", "test"));

            Assert.True(response);
        }


        #endregion

        #region Pin Tests
        [Fact]
        public async void CreatePin_NotNull_Test()

        {
            // Assign
            _pinServiceMock.Setup(x => x.CreatePin("Monkey", "Bananas", "Monkey with a banana", null, null, null, null)).Returns(Task.FromResult(new Pin() { Id = 123 }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.CreatePin("Monkey", "Bananas", "Monkey with a banana");

            _pinServiceMock.Verify(x => x.CreatePin("Monkey", "Bananas", "Monkey with a banana", null, null, null, null));

            Assert.NotNull(response);
        }

        [Fact]
        public async void DeletePin_True_Test()

        {
            // Assign
            _pinServiceMock.Setup(x => x.DeletePin(1232)).Returns(Task.FromResult(true));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.DeletePin(1232);

            _pinServiceMock.Verify(x => x.DeletePin(1232));

            Assert.True(response);
        }

        [Fact]
        public async void EditPin_NotNull_Test()

        {
            // Assign
            _pinServiceMock.Setup(x => x.EditPin(123, "Monkey", "Bananas", "Monkey with a banana", null)).Returns(Task.FromResult(new Pin() { Id = 123 }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.EditPin(123, "Monkey", "Bananas", "Monkey with a banana");

            _pinServiceMock.Verify(x => x.EditPin(123, "Monkey", "Bananas", "Monkey with a banana", null));

            Assert.NotNull(response);
        }

        [Fact]
        public async void GetPin_NotNull_Test()

        {
            // Assign
            _pinServiceMock.Setup(x => x.GetPin(123)).Returns(Task.FromResult(new Pin() { Id = 123 }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetPin(123);

            _pinServiceMock.Verify(x => x.GetPin(123));

            Assert.NotNull(response);
        }

        #endregion

        #region Section Tests


        [Fact]
        public async void CreateSection_NotNull_Test()
        {
            // Assign
            _sectionServiceMock.Setup(x => x.CreateSection("Yellow", "Hat", "Man")).Returns(Task.FromResult(new Section() { Id = 2 }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.CreateSection("Yellow", "Hat", "Man");

            _sectionServiceMock.Verify(x => x.CreateSection("Yellow", "Hat", "Man"));

            Assert.NotNull(response);
        }

        [Fact]
        public async void DeleteSection_True_Test()
        {
            // Assign
            _sectionServiceMock.Setup(x => x.DeleteSection(123)).Returns(Task.FromResult(true));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.DeleteSection(123);

            _sectionServiceMock.Verify(x => x.DeleteSection(123));

            Assert.True(response);
        }

        [Fact]
        public async void GetSection_NotNull_Test()
        {
            // Assign
            _sectionServiceMock.Setup(x => x.GetSection(123)).Returns(Task.FromResult(new Pins() { new Pin() {Id = 1 } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetSection(123);

            _sectionServiceMock.Verify(x => x.GetSection(123));

            Assert.NotNull(response);
        }

        [Fact]
        public async void GetSections_NotNull_Test()
        {
            // Assign
            _sectionServiceMock.Setup(x => x.GetSections("Yellow", "Hat")).Returns(Task.FromResult(new Sections() { new Section() { Id = 2 } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetSections("Yellow", "Hat");

            _sectionServiceMock.Verify(x => x.GetSections("Yellow", "Hat"));

            Assert.NotNull(response);
        }

        #endregion

        #region User Tests   

        [Fact]
        public async void FollowBoard_True_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.FollowBoard("Ninja","Unicorn")).Returns(Task.FromResult(true));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.FollowBoard("Ninja", "Unicorn");

            _userServiceMock.Verify(x => x.FollowBoard("Ninja", "Unicorn"));

            Assert.True(response);
        }
        [Fact]
        public async void FollowUser_True_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.FollowUser("Master")).Returns(Task.FromResult(true));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.FollowUser("Master");

            _userServiceMock.Verify(x => x.FollowUser("Master"));

            Assert.True(response);
        }
        [Fact]
        public async void GetBoards_NotNull_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.GetBoards()).Returns(Task.FromResult(new Boards() { new Board() {Id = 2 } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetBoards();

            _userServiceMock.Verify(x => x.GetBoards());

            Assert.NotNull(response);
        }
        [Fact]
        public async void GetFollowers_NotNull_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.GetFollowers()).Returns(Task.FromResult(new Users() { new User() { Id = 2 } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetFollowers();

            _userServiceMock.Verify(x => x.GetFollowers());

            Assert.NotNull(response);
        }
        [Fact]
        public async void GetFollowingBoards_NotNull_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.GetFollowingBoards()).Returns(Task.FromResult(new Boards() { new Board() { Id = 2 } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetFollowingBoards();

            _userServiceMock.Verify(x => x.GetFollowingBoards());

            Assert.NotNull(response);
        }
        [Fact]
        public async void GetFollowingInterests_NotNull_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.GetFollowingInterests()).Returns(Task.FromResult(new Topics() { new Topic() { Id = 2 } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetFollowingInterests();

            _userServiceMock.Verify(x => x.GetFollowingInterests());

            Assert.NotNull(response);
        }
        [Fact]
        public async void GetFollowingUsers_NotNull_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.GetFollowingUsers()).Returns(Task.FromResult(new Users() { new User() { Id = 2 } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetFollowingUsers();

            _userServiceMock.Verify(x => x.GetFollowingUsers());

            Assert.NotNull(response);
        }
        [Fact]
        public async void GetSuggestedBoards_NotNull_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.GetSuggestedBoards(124)).Returns(Task.FromResult(new Boards() { new Board() { Id = 2 } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetSuggestedBoards(124);

            _userServiceMock.Verify(x => x.GetSuggestedBoards(124));

            Assert.NotNull(response);
        }
        [Fact]
        public async void GetUser_NotNull_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.GetUser()).Returns(Task.FromResult(new User() { First_Name = "George" }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetUser();

            _userServiceMock.Verify(x => x.GetUser());

            Assert.NotNull(response);
        }
        
        [Fact]
        public async void GetUserPins_NotNull_Test()

        {
            // Assign
            _userServiceMock.Setup(x => x.GetUserPins()).Returns(Task.FromResult(new Pins() { new Pin() { Id = 123 } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.GetUserPins();

            _userServiceMock.Verify(x => x.GetUserPins());

            Assert.NotNull(response);
        }
        [Fact]
        public async void SearchBoards_NotNull_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.SearchBoards("1231")).Returns(Task.FromResult(new Boards() { new Board() { Id = 2 } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.SearchBoards("1231");

            _userServiceMock.Verify(x => x.SearchBoards("1231"));

            Assert.NotNull(response);
        }
        [Fact]
        public async void SearchPins_NotNull_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.SearchPins("1231")).Returns(Task.FromResult(new Pins() { new Pin() { Id = 2 } }));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.SearchPins("1231");

            _userServiceMock.Verify(x => x.SearchPins("1231"));

            Assert.NotNull(response);
        }
        [Fact]
        public async void UnfollowBoard_True_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.UnfollowBoard("Ninja", "Unicorn")).Returns(Task.FromResult(true));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.UnfollowBoard("Ninja", "Unicorn");

            _userServiceMock.Verify(x => x.UnfollowBoard("Ninja", "Unicorn"));

            Assert.True(response);
        }
        [Fact]
        public async void UnfollowUserById_True_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.UnfollowUser(123)).Returns(Task.FromResult(true));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.UnfollowUser(123);

            _userServiceMock.Verify(x => x.UnfollowUser(123));

            Assert.True(response);
        }
        [Fact]
        public async void UnfollowUserByName_True_Test()
        {
            // Assign
            _userServiceMock.Setup(x => x.UnfollowUser("Ninja")).Returns(Task.FromResult(true));

            SetTestClient();

            //// Act 
            var response = await _serviceClient.UnfollowUser("Ninja");

            _userServiceMock.Verify(x => x.UnfollowUser("Ninja"));

            Assert.True(response);
        }
        #endregion
        

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
