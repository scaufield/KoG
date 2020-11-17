using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using KnightsOfGoodProject.Data;
using KnightsOfGoodProject.Models;
using KnightsOfGoodProject.Service;

namespace KnightsOfGoodProject.Controllers
{


    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;



       public HomeController( DataManager dataManager, UserManager<ApplicationUser> usr, ApplicationDbContext context)
        {         
            _dataManager = dataManager;
            _userManager = usr;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public async Task<IActionResult> Im()
        {         
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

     



        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dataManager.AccountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(userModel);
                }

                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }

            return View(userModel);
        }
    }
    }
