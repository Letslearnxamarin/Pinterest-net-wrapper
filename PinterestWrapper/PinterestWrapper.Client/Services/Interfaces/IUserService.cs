using System.Threading.Tasks;
using PinterestService.Client.DataContracts;

namespace PinterestService.Client.Services
{
    public interface IUserService
    {
        Task<bool> FollowBoard(string username, string board_name);
        Task<bool> FollowUser(string username);
        Task<Boards> GetBoards(int id);
        Task<Users> GetFollowers();
        Task<Boards> GetFollowingBoards();
        Task<Topics> GetFollowingInterests();
        Task<Users> GetFollowingUsers();
        Task<Boards> GetSuggestedBoards(int pinId);
        Task<User> GetUser();
        Task<Pins> GetUserPins();
        Task<Boards> SearchBoards(string query);
        Task<Pins> SearchPins(string query);
        Task<bool> UnfollowBoard(string username, string board_name);
        Task<bool> UnfollowUser(int id);
        Task<bool> UnfollowUser(string username);
    }
}