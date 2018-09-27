using PinterestService.Client.DataContracts;
using PinterestService.Client.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace PinterestService.Client.Services
{
    public class BoardService : PinterestService, IBoardService
    {
        
        public BoardService(string accessToken) : base(accessToken)
        {

        }

        public virtual async Task<Board> CreateBoard(string name, string description = null)
        {
            return await PostAsync<BaseRequest, Board>(BuildRequestUrl("/boards/"), new BaseRequest() { Name = name, Description = description });
        }

        public virtual async Task<Board> GetBoard(string username, string board_name)
        {
            return await GetAsync<Board>(BuildRequestUrl($"/boards/{username}/{board_name}"));
        }

        public virtual async Task<Pins> GetBoardPins(string username, string board_name)
        {
            return await GetAsync<Pins>(BuildRequestUrl($"/boards/{username}/{board_name}/Pins/"));
        }

        public virtual async Task<Boards> GetUsersBoards()
        {
            return await GetAsync<Boards>(BuildRequestUrl($"/me/boards/"));
        }

        public virtual async Task<Board> EditBoard(string username, string board_name, string name, string description)
        {
            return await PatchAsync<BaseRequest, Board>(BuildRequestUrl($"/boards/{username}/{board_name}"), new BaseRequest() { Name = name, Description = description });
        }

        public virtual async Task<bool> DeleteBoard(string username, string board_name)
        {
            var deleted =  await DeleteAsync<string>(BuildRequestUrl($"/boards/{username}/{board_name}"));

            return string.IsNullOrEmpty(deleted);

        }
    }
}
