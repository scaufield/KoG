using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnightsOfGoodProject.Models;
using Microsoft.AspNetCore.Identity;

namespace KnightsOfGoodProject.Data.Repositories.Abstract
{
    public interface IHomeRepository
    {
        IQueryable<ServiceItem> GetUserEvents(string UserID);
    }
}