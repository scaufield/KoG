using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnightsOfGoodProject.Data.Repositories.Abstract;
using KnightsOfGoodProject.Models;

namespace KnightsOfGoodProject.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
          

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




        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }


    }
}





