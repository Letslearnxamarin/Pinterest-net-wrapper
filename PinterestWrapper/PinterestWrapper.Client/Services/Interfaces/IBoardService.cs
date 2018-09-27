using System.Threading.Tasks;
using PinterestService.Client.DataContracts;
using System.Runtime.CompilerServices;

namespace PinterestService.Client.Services
{
    public interface IBoardService
    {
        Task<Board> CreateBoard(string name, string description = null);
        Task<bool> DeleteBoard(string username, string board_name);
        Task<Board> EditBoard(string username, string board_name, string name, string description);
        Task<Board> GetBoard(string username, string board_name);
        Task<Pins> GetBoardPins(string username, string board_name);
        Task<Boards> GetUsersBoards();
    }
}