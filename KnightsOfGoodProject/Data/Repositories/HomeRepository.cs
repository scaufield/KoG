using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KnightsOfGoodProject.Data.Repositories.Abstract;
using KnightsOfGoodProject.Models;
using Microsoft.AspNetCore.Identity;

namespace KnightsOfGoodProject.Data.Repositories
{


    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _context = null;
        private readonly UserManager<ApplicationUser> _userManager;


        public HomeRepository(UserManager<ApplicationUser> userManager,  ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IQueryable<ServiceItem> GetUserEvents(string UserID)
        {
            return _context.ServiceItems.Where(x => x.Users.Any(z => z.UserId == UserID));
        }


    }
}