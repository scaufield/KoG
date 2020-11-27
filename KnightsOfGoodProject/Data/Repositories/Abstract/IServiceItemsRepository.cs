using System;
using System.Linq;
using System.Threading.Tasks;
using KnightsOfGoodProject.Models;

namespace KnightsOfGoodProject.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid id);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid id);
        Task ParticipateInTheEventAsync(string userID, Guid EventID);
        IQueryable<ApplicationUser> GetParticipants(Guid EventID);
        int GetParticipantsCol(Guid EventID);
        bool IsParticipant(string currentUserID, Guid EventID);
    }
}