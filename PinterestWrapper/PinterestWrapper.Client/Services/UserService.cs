using PinterestService.Client.DataContracts;
using PinterestService.Client.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PinterestService.Client.Services
{
    internal class UserService : PinterestService
    {
        public UserService(string accessToken) : base(accessToken)
        {

        }

        public async Task<User> GetUser()
        {
            return await GetAsync<User>(BuildRequestUrl($"/me"));
        }

        public async Task<Boards> GetBoards(int id)
        {
            return await GetAsync<Boards>(BuildRequestUrl($"/me/boards"));
        }

        public async Task<Pins> GetUserPins()
        {
            return await GetAsync<Pins>(BuildRequestUrl($"/me/pins/"));
        }

        public async Task<Boards> GetSuggestedBoards(int pinId)
        {
            return await GetAsync<Boards>(BuildRequestUrl($"/me/boards/suggested/{pinId}"));
        }

        public async Task<Boards> SearchBoards(string query)
        {
            return await GetAsync<Boards>(BuildRequestUrl($"/me/search/boards/{query}"));
        }

        public async Task<Pins> SearchPins(string query)
        {
            return await GetAsync<Pins>(BuildRequestUrl($"/me/search/pins/{query}"));
        }

        public async Task<bool> FollowBoard(string username, string board_name)
        {
            var success =  await PostAsync<BoardRequest, string>(BuildRequestUrl($"/me/following/boards/"), new BoardRequest() { UserName = username, Board_Name = board_name });
            return string.IsNullOrEmpty(success);
        }

        public async Task<bool> FollowUser(string username)
        {
            var success = await PostAsync<UserRequest, string>(BuildRequestUrl($"/me/following/boards/"), new UserRequest() { UserName = username });
            return string.IsNullOrEmpty(success);
        }

        public async Task<Users> GetFollowers()
        {
            return await GetAsync<Users>(BuildRequestUrl($"/me/followers/"));
        }

        public async Task<Boards> GetFollowingBoards()
        {
            return await GetAsync<Boards>(BuildRequestUrl($"/me/following/boards/"));
        }

        public async Task<Topics> GetFollowingInterests()
        {
            return await GetAsync<Topics>(BuildRequestUrl($"/me/following/interests/"));
        }

        public async Task<Users> GetFollowingUsers()
        {
            return await GetAsync<Users>(BuildRequestUrl($"/me/following/users/"));
        }

        public async Task<bool> UnfollowBoard(string username, string board_name)
        {
            var deleted = await DeleteAsync<string>(BuildRequestUrl($"/me/following/boards/{username}/{board_name}"));
            return string.IsNullOrEmpty(deleted);
        }

        public async Task<bool> UnfollowUser(string username)
        {
            var deleted = await DeleteAsync<string>(BuildRequestUrl($"/me/following/users/{username}/"));
            return string.IsNullOrEmpty(deleted);
        }

        public async Task<bool> UnfollowUser(int id)
        {
            var deleted = await DeleteAsync<string>(BuildRequestUrl($"/me/following/users/{id}/"));
            return string.IsNullOrEmpty(deleted);
        }
    }
}
