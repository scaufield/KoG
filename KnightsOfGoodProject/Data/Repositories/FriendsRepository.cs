using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnightsOfGoodProject.Data.Repositories.Abstract;
using KnightsOfGoodProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnightsOfGoodProject.Data.Repositories
{
    public class FriendsRepository : IFriendsRepository
    {
        private readonly ApplicationDbContext _context;
        public FriendsRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IQueryable<ApplicationUser> GetAllUsers()
        {
            return _context.ApplicationUser;
        }
        public IQueryable<ApplicationUser> GetFriendsUsers(string userId)
        {
            return _context.Users.Where(x => x.UserFriends.Any(z => z.FriendId == userId));
        }








        public ApplicationUser GetUserById(String id)
        {
            return _context.ApplicationUser.FirstOrDefault(x => x.Id == id);
        }




        public async Task AddFriendAsync(ApplicationUser currentUser, ApplicationUser Friend)
        {


            var friendshipsCount = _context.Friends.Where(x =>
               x.FriendId == Friend.Id && x.UserId == currentUser.Id
               || (x.FriendId == currentUser.Id && x.UserId == Friend.Id)).Count();

            if (friendshipsCount == 0)
            {
                if (Friend != null && currentUser != null)
                {
                    Friend.UserFriends.Add(new Friends { UserId = Friend.Id, FriendId = currentUser.Id });
                    currentUser.UserFriends.Add(new Friends { UserId = currentUser.Id, FriendId = Friend.Id });
                    _context.Update(currentUser);
                    _context.SaveChanges();
                    // FriendAddUser(Friend);
                }
                else
                {
                    //обработать ошибку отсутствующего юзера					
                }
            }
            else
            {
                //обработать ошибку если юзер уже добавлен
            }
        }
        public bool IsFriend(ApplicationUser currentUser, ApplicationUser Friend)
        {
            var friendshipsCount = _context.Friends.Where(x =>
              x.FriendId == Friend.Id && x.UserId == currentUser.Id
              || (x.FriendId == currentUser.Id && x.UserId == Friend.Id)).Count();

            if (friendshipsCount == 0)
            {
                return false;
            }
            return true;
        }
        public bool IsFriendById(string currentUserID, string FriendID)
        {
            var friendshipsCount = _context.Friends.Where(x =>
              x.FriendId == FriendID && x.UserId == currentUserID
              || (x.FriendId == currentUserID && x.UserId == FriendID)).Count();

            if (friendshipsCount == 0)
            {
                return false;
            }
            return true;
        }
        public async Task<GetUserFriendsViewModel> GetFriendsAsync(string userId)
        {
            var friendsList = await _context.Users.Where(x => x.UserFriends.Any(z => z.FriendId == userId)).ToListAsync();

            var count = _context.Friends.Where(x => x.UserId == userId).Select(x => x.FriendId)
                .Count();

            var friends = new GetUserFriendsViewModel
            {
                friends = friendsList,
                Count = count
            };

            return friends;
        }
        public Task GetFriendsByAsync(string userId)
        {
            var friendsList = _context.Users.Where(x => x.UserFriends.Any(z => z.FriendId == userId)).ToListAsync();

            var count = _context.Friends.Where(x => x.UserId == userId).Select(x => x.FriendId)
                .Count();

            return friendsList;


        }
    }
}