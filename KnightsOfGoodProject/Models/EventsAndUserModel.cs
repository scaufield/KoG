using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KnightsOfGoodProject.Models
{
    public class EventsAndUserModel
    {
        public string UserId { get; set; }
        public Guid EventId { get; set; }
        public ApplicationUser User { get; set; }
        public ServiceItem Event { get; set; }
    }
}