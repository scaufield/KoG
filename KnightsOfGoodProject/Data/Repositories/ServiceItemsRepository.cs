using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KnightsOfGoodProject.Repositories.Abstract;
using KnightsOfGoodProject.Models;
using System.Threading.Tasks;

namespace KnightsOfGoodProject.Data.Repositories
{
        public class ServiceItemsRepository : IServiceItemsRepository
        {
            private readonly ApplicationDbContext context;
            public ServiceItemsRepository(ApplicationDbContext context)
            {
                this.context = context;
            }

            public IQueryable<ServiceItem> GetServiceItems()
            {
                return context.ServiceItems;
            }

            public ServiceItem GetServiceItemById(Guid id)
            {
                return context.ServiceItems.FirstOrDefault(x => x.Id == id);
            }

            public void SaveServiceItem(ServiceItem entity)
            {
                if (entity.Id == default)
                    context.Entry(entity).State = EntityState.Added;
                else
                    context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }

            public void DeleteServiceItem(Guid id)
            {
                context.ServiceItems.Remove(new ServiceItem() { Id = id });
                context.SaveChanges();
            }

        public async Task ParticipateInTheEventAsync(string userID, Guid EventID)
        {
            if (userID != null && EventID != null)
            {
                var UserCounter = context.EventsAndUser.Where(x => x.EventId == EventID).Count();
                var EventForPart = await context.ServiceItems.FirstOrDefaultAsync(x => x.Id == EventID);

                var UserForEvent = await context.EventsAndUser
                    .Where(x => x.UserId == userID && x.EventId == EventID)
                    .Select(x => x.EventId).FirstOrDefaultAsync();

                var UserForEventStr = UserForEvent.ToString();

                if (UserForEventStr == "00000000-0000-0000-0000-000000000000")
                {
                    await context.EventsAndUser.AddAsync(new EventsAndUserModel { EventId = EventID, UserId = userID });
                    EventForPart.UserCounter = UserCounter + 1;
                }
                else
                {
                    context.EventsAndUser.Remove(new EventsAndUserModel { UserId = userID, EventId = EventID });
                    EventForPart.UserCounter = UserCounter - 1;
                }
                await context.SaveChangesAsync();
            }
            else
            {
                //Обработать исключение
            }
        }



        public IQueryable<ApplicationUser> GetParticipants(Guid EventID)
        {
            return context.Users.Where(x => x.UserEvents.Any(z => z.EventId == EventID));
        }
        public int GetParticipantsCol(Guid EventID)
        {
            return context.Users.Where(x => x.UserEvents.Any(z => z.EventId == EventID)).Count();
        }

        public bool IsParticipant(string currentUserID, Guid EventID)
        {
            var participateCount = context.EventsAndUser.Where(x =>
              x.EventId == EventID && x.UserId == currentUserID).Count();

            if (participateCount == 0)
            {
                return false;
            }
            return true;
        }


    }
}
