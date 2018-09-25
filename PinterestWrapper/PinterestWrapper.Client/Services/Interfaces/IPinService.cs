using System.Collections.Generic;
using System.Threading.Tasks;
using PinterestService.Client.DataContracts;

namespace PinterestService.Client.Services
{
    public interface IPinService
    {
        Task<Pin> CreatePin(string username, string board_name, string note, string link = null, Image image = null, string image_url = null, string image_base64 = null);
        Task<bool> DeletePin(int id);
        Task<Pin> EditPin(int id, string username = null, string board_name = null, string note = null, string link = null);
        Task<Pin> GetPin(int id);
        Task<IEnumerable<Pin>> GetUserPins();
    }
}