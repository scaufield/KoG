using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KnightsOfGoodProject.Data;
using System;
using KnightsOfGoodProject.Service;

namespace KnightsOfGoodProject.Models.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;

        public SidebarViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;

        }

        public Task<IViewComponentResult> InvokeAsync()
        {


            return Task.FromResult((IViewComponentResult) View("Default", dataManager.ServiceItemsRepository.GetServiceItems()));
        }

       
    }
}
