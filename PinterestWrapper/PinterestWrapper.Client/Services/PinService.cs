using PinterestService.Client.DataContracts;
using PinterestService.Client.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinterestService.Client.Services
{
    internal class PinService : PinterestService
    {
        public PinService(string accessToken) : base(accessToken)
        {

        }

        public async Task<Pin> CreatePin(string username, string board_name, string note, string link = null, Image image = null, string image_url = null, string image_base64 = null)
        {
            return await PostAsync<PinRequest, Pin>(BuildRequestUrl($"/pins/{username}/{board_name}"), new PinRequest() { Note = note, Link = link, Image = image, Image_Url = image_url, Image_Base64 = image_base64 });
        }

        public async Task<Pin> GetPin(int id)
        {
            return await GetAsync<Pin>(BuildRequestUrl($"/pins/{id}"));
        }

        public async Task<IEnumerable<Pin>> GetUserPins()
        {
            return await GetAsync<IEnumerable<Pin>>(BuildRequestUrl($"/me/pins/"));
        }

        public async Task<Pin> EditPin(int id, string username = null, string board_name = null, string note = null, string link = null)
        {

            var actionUrl = $"/me/pins/{id}";

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(board_name))
            {
                actionUrl = $"{actionUrl}/{username}/{board_name}";
            }

            return await PatchAsync<PinRequest, Pin>(BuildRequestUrl($"/pins/{username}/{board_name}"), new PinRequest() { Note = note, Link = link });
        }

        public async Task<bool> DeletePin(int id)
        {
            var deleted = await DeleteAsync<string>(BuildRequestUrl($"/pins/{id}"));
            return string.IsNullOrEmpty(deleted);
        }

    }
}
