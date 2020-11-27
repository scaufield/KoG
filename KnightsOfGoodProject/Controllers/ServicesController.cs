using System;
using Microsoft.AspNetCore.Mvc;
using KnightsOfGoodProject.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using KnightsOfGoodProject.Models;
using KnightsOfGoodProject.Repositories.Abstract;
using KnightsOfGoodProject.Service;


namespace KnightsOfGoodProject.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager _dataManager;
		private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public ServicesController(DataManager dataManager, ApplicationDbContext context, IUserService userService)
        {
            _dataManager = dataManager;
			_context = context;
            _userService = userService;

        }

        public IActionResult Events(Guid id)
        {
            ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            if (currentUser != null)
            {
                var currentUserID = currentUser.Id;
                ViewBag.IsPart = _dataManager.ServiceItemsRepository.IsParticipant(currentUserID, id);
            }
            if (id != default)
            {
                ViewBag.UsersCol = _dataManager.ServiceItemsRepository.GetParticipantsCol(id);
                ViewBag.Users = _dataManager.ServiceItemsRepository.GetParticipants(id);

                return View("Show", _dataManager.ServiceItemsRepository.GetServiceItemById(id));
            }
            ViewBag.TextField = _dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            return View(_dataManager.ServiceItemsRepository.GetServiceItems());
        }

        public IActionResult ReturnEvents()
        {

            ViewBag.TextField = _dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            return View("Events", _dataManager.ServiceItemsRepository.GetServiceItems());
        }

        [HttpPost]
        public IActionResult Events(DateTime startdate, DateTime enddate)
        {
            var model = _context.ServiceItems.Where(z => (z.DateTime >= startdate) && (z.DateTime <= enddate));
            return View(model);
        }


        [HttpPost("Services/Events/{id}")/*, Route("ParticipateInTheEvent")*/]
        public async Task<IActionResult> ParticipateInTheEvent(Guid id)
        {
            ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            Guid EventID = id;

            var currentUserID = currentUser.Id;
            await _dataManager.ServiceItemsRepository.ParticipateInTheEventAsync(currentUserID, EventID);
            ViewBag.UsersCol = _dataManager.ServiceItemsRepository.GetParticipantsCol(id);
            ViewBag.Users = _dataManager.ServiceItemsRepository.GetParticipants(id);
            ViewBag.IsPart = _dataManager.ServiceItemsRepository.IsParticipant(currentUserID, EventID);
            return View("Show", _dataManager.ServiceItemsRepository.GetServiceItemById(id));
        }

    }
}
