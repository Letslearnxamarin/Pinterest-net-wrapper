using System.Collections.Generic;
using System.Threading.Tasks;
using PinterestService.Client.DataContracts;
using PinterestService.Client.Services;

namespace PinterestService.Client
{
    public interface IPinterestServiceClient
    {
        Task<Board> CreateBoard(string name, string description = null);
        Task<Pin> CreatePin(string username, string board_name, string note, string link = null, Image image = null, string image_url = null, string image_base64 = null);
        Task<Section> CreateSection(string username, string board_name, string title);
        Task<bool> DeleteBoard(string username, string board_name);
        Task<bool> DeletePin(int id);
        Task<bool> DeleteSection(int id);
        Task<Board> EditBoard(string username, string board_name, string name, string description);
        Task<Pin> EditPin(int id, string username = null, string board_name = null, string note = null, string link = null);
        Task<bool> FollowBoard(string username, string board_name);
        Task<bool> FollowUser(string username);
        Task<Board> GetBoard(string username, string board_name);
        Task<Pins> GetBoardPins(string username, string board_name);
        Task<Boards> GetBoards(int id);
        Task<Users> GetFollowers();
        Task<Boards> GetFollowingBoards();
        Task<Topics> GetFollowingInterests();
        Task<Users> GetFollowingUsers();
        Task<Pin> GetPin(int id);
        Task<IEnumerable<Sections>> GetSection(int id);
        Task<Sections> GetSections(string username, string board_name);
        Task<Boards> GetSuggestedBoards(int pinId);
        Task<User> GetUser();
        Task<Pins> GetUserPins();
        Task<Boards> GetUsersBoards();
        Task<Boards> SearchBoards(string query);
        Task<Pins> SearchPins(string query);
        Task<bool> UnfollowBoard(string username, string board_name);
        Task<bool> UnfollowUser(int id);
        Task<bool> UnfollowUser(string username);
    }
}