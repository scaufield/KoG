using Microsoft.AspNetCore.Mvc;
using KnightsOfGoodProject.Data;
using KnightsOfGoodProject.Service;

namespace KnightsOfGoodProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.ServiceItemsRepository.GetServiceItems());
        }
    }
}