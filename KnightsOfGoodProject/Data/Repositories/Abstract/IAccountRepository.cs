using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnightsOfGoodProject.Models;

namespace KnightsOfGoodProject.Data.Repositories.Abstract
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);

        Task SignOutAsync();

        Task<IdentityResult> EditUserAsync(EditUserPageModel model);

        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);

    }
}