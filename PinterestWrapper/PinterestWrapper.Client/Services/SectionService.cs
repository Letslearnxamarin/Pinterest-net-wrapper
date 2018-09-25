using PinterestService.Client.DataContracts;
using PinterestService.Client.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinterestService.Client.Services
{
    public class SectionService : PinterestService, ISectionService
    {
        public SectionService(string accessToken) : base(accessToken)
        {

        }

        public async Task<Section> CreateSection(string username, string board_name, string title)
        {
            return await PostAsync<SectionRequest, Section>(BuildRequestUrl($"/board/{username}/{board_name}/sections/"), new SectionRequest() { Title = title });
        }

        public async Task<Sections> GetSections(string username, string board_name)
        {
            return await GetAsync<Sections>(BuildRequestUrl($"/board/{username}/{board_name}/sections/"));
        }

        public async Task<IEnumerable<Sections>> GetSection(int id)
        {
            return await GetAsync<IEnumerable<Sections>>(BuildRequestUrl($"/board/sections/{id}/pins/"));
        }

        public async Task<bool> DeleteSection(int id)
        {
            var deleted = await DeleteAsync<string>(BuildRequestUrl($"/board/sections/{id}/"));
            return string.IsNullOrEmpty(deleted);
        }

    }
}
