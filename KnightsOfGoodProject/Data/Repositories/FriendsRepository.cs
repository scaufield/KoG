using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnightsOfGoodProject.Data;
using KnightsOfGoodProject.Data.Repositories.Abstract;
using KnightsOfGoodProject.Models;
using KnightsOfGoodProject.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace KnightsOfGoodProject.Controllers
{
    public class FriendsController : Controller
    {
      
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private UserManager<ApplicationUser> _userManager;
        private readonly DataManager _dataManager;

        public FriendsController( DataManager dataManager,  IUserService userService, UserManager<ApplicationUser> usr, ApplicationDbContext context)
        {
          
            _context = context;
            _userService = userService;
            _userManager = usr;
            _dataManager = dataManager;

        }

        public async Task<IActionResult> Friends(String id)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            var UserID = user.Id;
            string userId = _userService.GetUserId();   
            if(id == UserID)
            {
                ViewBag.IsFriend = _dataManager.FriendsRepository.IsFriendById(userId, id);
                ViewBag.Event = _dataManager.HomeRepository.GetUserEvents(id);
                return View("Im", _dataManager.FriendsRepository.GetUserById(id));
            }
            else  if (id != default)
            {
                ViewBag.IsFriend = _dataManager.FriendsRepository.IsFriendById(userId, id);
                ViewBag.Event = _dataManager.HomeRepository.GetUserEvents(id);
                return View("User", _dataManager.FriendsRepository.GetUserById(id));
            }

            return View(_dataManager.FriendsRepository.GetAllUsers());
        }

        [HttpGet("Friends/Friends/{action}")]
        public async Task<IActionResult> All(String id)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            var UserID = user.Id;
            return View(_dataManager.FriendsRepository.GetFriendsUsers(UserID));
        }

        [HttpPost("Friends/Friends/{id}")]
        public async Task<IActionResult> GetFriendPost(string id)
        {

            ApplicationUser Friend = _context.Users.FirstOrDefault(x => x.Id == id);
            await AddFriend(Friend);

            ViewBag.Event = _dataManager.HomeRepository.GetUserEvents(id);
            return View("User", _dataManager.FriendsRepository.GetUserById(id));
        }

        [HttpPost]
        public async Task AddFriend(ApplicationUser Friend)
        {
            ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            var currentUserID = currentUser.Id;

            await _dataManager.FriendsRepository.AddFriendAsync(currentUser, Friend);

        }

        [HttpGet("Friends/Friends/{id}/{action}")]
        public IActionResult DeleteFriend(string id)
        {
            ApplicationUser currentUser = _context.Users.Include(x => x.UserFriends).ThenInclude(x => x.Friend).FirstOrDefault(x => x.UserName == User.Identity.Name);
            if (currentUser.UserFriends.Count != 0)
            {
                var UserToBeDeleted = currentUser.UserFriends.First(x => x.FriendId == id);
                if (UserToBeDeleted != null)
                {
                    _context.Friends.Remove(UserToBeDeleted);
                    _context.SaveChanges();
                    var UserToBeDeleted2 = _context.Users.Include(x => x.UserFriends).ThenInclude(x => x.Friend).FirstOrDefault(x => x.Id == UserToBeDeleted.FriendId);
                    var delete = UserToBeDeleted2.UserFriends.First(x => x.FriendId == currentUser.Id);
                    _context.Friends.Remove(delete);
                    _context.SaveChanges();
                    ViewBag.IsFriend = _dataManager.FriendsRepository.IsFriendById(currentUser.Id, id);
                    ViewBag.Event = _dataManager.HomeRepository.GetUserEvents(id);

                    return View("DeleteFriend", _dataManager.FriendsRepository.GetUserById(id));
                }
                return View();
            }
            return View();
        }

        [HttpGet("Friends/Friends/{action}")]
        public async Task<GetUserFriendsViewModel> GetFriends(string id)
        {
            var model = await _dataManager.FriendsRepository.GetFriendsAsync(id);
            // ViewFriend(model);
            return null;
        }

        [HttpGet("Friends/Friends/{action}")]
        public Task GetFriendsBy(string id)
        {
            var model = _dataManager.FriendsRepository.GetFriendsByAsync(id);
            ViewFriend(model);
            return null;
        }

        public IActionResult ViewFriend(Task ApplicationUser)
        {
            return View("MyFriends", ApplicationUser);

        }

    }

}