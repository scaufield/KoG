using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnightsOfGoodProject.Data.Repositories.Abstract;
using KnightsOfGoodProject.Models;
using KnightsOfGoodProject.Service;

namespace KnightsOfGoodProject.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;


        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserService userService) {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
          

        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.Email,
                EmailConfirmed = true,
                UserImagePath = "KnightOfGood.jpg"
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);         
            return result;
        }




        public async Task<IdentityResult> EditUserAsync(EditUserPageModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            if (model.Bio != null) { user.Bio = model.Bio; }
            if (model.FirstName != null) { user.FirstName = model.FirstName; }
            if (model.LastName != null) { user.LastName = model.LastName; }
            if (model.DateOfBirth != null) { user.DateOfBirth = model.DateOfBirth; }
            if (model.TitleImagePath != null) { user.UserImagePath = model.TitleImagePath; }


            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }


    }
}





