using PinterestService.Client.DataContracts;
using PinterestService.Client.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinterestService.Client
{
    public class PinterestServiceClient : IPinterestServiceClient
    {
        private readonly AuthService _authService;
        private string AccessToken { get; set; }


        #region ServiceFields
        private readonly IBoardService BoardService;
        private readonly IPinService PinService;
        private readonly IUserService UserService;
        private readonly ISectionService SectionService;
        #endregion

        public PinterestServiceClient(IBoardService boardService, IPinService pinService, IUserService userService, ISectionService sectionService)
        {
            this.BoardService = boardService;
            this.PinService = pinService;
            this.UserService = userService;
            this.SectionService = sectionService;
        }
        
        #region BoardService

        public virtual async Task<Board> CreateBoard(string name, string description = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException($"{nameof(name)} - Name is required");
            }

            return await BoardService.CreateBoard(name, description);
        }

        public async Task<Board> GetBoard(string username, string board_name)
        {
            BoardGuardCheck(username, board_name);

            return await BoardService.GetBoard(username, board_name);
        }

        public async Task<Pins> GetBoardPins(string username, string board_name)
        {
            BoardGuardCheck(username, board_name);

            return await BoardService.GetBoardPins(username, board_name);
        }

        public async Task<Boards> GetUsersBoards()
        {
            return await BoardService.GetUsersBoards();
        }

        public async Task<Board> EditBoard(string username, string board_name, string name, string description)
        {
            BoardGuardCheck(username, board_name);
            return await BoardService.EditBoard(username, board_name, name,description);
        }

        public async Task<bool> DeleteBoard(string username, string board_name)
        {
            BoardGuardCheck(username, board_name);
            return await BoardService.DeleteBoard(username, board_name);
        }

        #endregion

        #region Pinservice

        public async Task<Pin> CreatePin(string username, string board_name, string note, string link = null, Image image = null, string image_url = null, string image_base64 = null)
        {
            return await PinService.CreatePin(username, board_name, note, link, image, image_url, image_base64);
        }

        public async Task<Pin> GetPin(int id)
        {
            return await PinService.GetPin(id);
        }

        public async Task<Pin> EditPin(int id, string username = null, string board_name = null, string note = null, string link = null)
        {
            return await PinService.EditPin(id, username, board_name, note, link);
        }

        public async Task<bool> DeletePin(int id)
        {
            return await PinService.DeletePin(id);
        }
        
        #endregion

        #region UserService
        public async Task<User> GetUser()
        {
            return await UserService.GetUser();
        }

        public async Task<Boards> GetBoards(int id)
        {
            return await UserService.GetBoards(id);
        }

        public async Task<Pins> GetUserPins()
        {
            return await UserService.GetUserPins();
        }

        public async Task<Boards> GetSuggestedBoards(int pinId)
        {
            return await UserService.GetSuggestedBoards(pinId);
        }

        public async Task<Boards> SearchBoards(string query)
        {
            return await UserService.SearchBoards(query);
        }

        public async Task<Pins> SearchPins(string query)
        {
            return await UserService.SearchPins(query);
        }

        public async Task<bool> FollowBoard(string username, string board_name)
        {
            BoardGuardCheck(username, board_name);
            return await UserService.FollowBoard(username, board_name);
        }

        public async Task<bool> FollowUser(string username)
        {
            UserGuardCheck(username);
            return await UserService.FollowUser(username);
        }

        public async Task<Users> GetFollowers()
        {
            return await UserService.GetFollowers();
        }

        public async Task<Boards> GetFollowingBoards()
        {
            return await UserService.GetFollowingBoards();
        }

        public async Task<Topics> GetFollowingInterests()
        {
            return await UserService.GetFollowingInterests();
        }

        public async Task<Users> GetFollowingUsers()
        {
            return await UserService.GetFollowingUsers();
        }

        public async Task<bool> UnfollowBoard(string username, string board_name)
        {
            BoardGuardCheck(username, board_name);
            return await UserService.UnfollowBoard(username, board_name);
        }

        public async Task<bool> UnfollowUser(string username)
        {
            UserGuardCheck(username);

            return await UserService.UnfollowUser(username);
        }

        public async Task<bool> UnfollowUser(int id)
        {
            return await UserService.UnfollowUser(id);
        }

        #endregion

        #region SectionService

        public async Task<Section> CreateSection(string username, string board_name, string title)
        {
            BoardGuardCheck(username, board_name);

            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException($"{nameof(title)} - is required");

            return await SectionService.CreateSection(username, board_name, title);
        }

        public async Task<Sections> GetSections(string username, string board_name)
        {
            BoardGuardCheck(username, board_name);
            return await SectionService.GetSections(username, board_name);
        }

        public async Task<Pins> GetSection(int id)
        {
            return await SectionService.GetSection(id);
        }

        public async Task<bool> DeleteSection(int id)
        {
            return await SectionService.DeleteSection(id);
        }

        #endregion  

        #region Utility

        private void AccessTokenGuard()
        {
            if (string.IsNullOrEmpty(AccessToken))
            {
                throw new ArgumentNullException($"{nameof(AccessToken)} - is required");
            }
        }

        private static void BoardGuardCheck(string username, string board_name)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException($"{nameof(username)} - is required");
            }
            if (string.IsNullOrEmpty(board_name))
            {
                throw new ArgumentNullException($"{nameof(board_name)} - is required");
            }
        }

        private static void UserGuardCheck(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException($"{nameof(username)} - is Required");
        }

        #endregion

    }
}
