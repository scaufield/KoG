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


        public ServicesController(DataManager dataManager, ApplicationDbContext context)
        {
            _dataManager = dataManager;
			_context = context;
     
     
        }

        public IActionResult Events(Guid id)
        {
            if (id != default)
            {
                return View("Show", _dataManager.ServiceItemsRepository.GetServiceItemById(id));
            }

            ViewBag.TextField = _dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            return View(_dataManager.ServiceItemsRepository.GetServiceItems());
        }


        [HttpPost]
        public IActionResult Events(DateTime startdate, DateTime enddate)
        {

            return View(_context.ServiceItems.Where(z => (z.DateTime <= startdate) && (z.DateTime <= enddate)));
        }

    }
}
