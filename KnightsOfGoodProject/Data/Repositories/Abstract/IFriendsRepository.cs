using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnightsOfGoodProject.Models;

namespace KnightsOfGoodProject.Data.Repositories.Abstract
{
    public interface IFriendsRepository
    {
        IQueryable<ApplicationUser> GetAllUsers();
        ApplicationUser GetUserById(String id);
        Task AddFriendAsync(ApplicationUser currentUser, ApplicationUser Friend);
        public bool IsFriend(ApplicationUser currentUser, ApplicationUser Friend);
        public bool IsFriendById(string currentUserID, string FriendID);
        Task<GetUserFriendsViewModel> GetFriendsAsync(string userId);
        public Task GetFriendsByAsync(string userId);
        IQueryable<ApplicationUser> GetFriendsUsers(string userId);
    }
}