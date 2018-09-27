using System.Collections.Generic;
using System.Threading.Tasks;
using PinterestService.Client.DataContracts;

namespace PinterestService.Client.Services
{
    public interface ISectionService
    {
        Task<Section> CreateSection(string username, string board_name, string title);
        Task<bool> DeleteSection(int id);
        Task<Pins> GetSection(int id);
        Task<Sections> GetSections(string username, string board_name);
    }
}