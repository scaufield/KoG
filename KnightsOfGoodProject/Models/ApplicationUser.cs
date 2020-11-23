using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KnightsOfGoodProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {           
		    UserEvents = new List<EventsAndUserModel>();
        }
    
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        public string Bio { get; set; }
        public virtual string UserImagePath { get; set; }
        public List<EventsAndUserModel> UserEvents { get; set; }
   
    }
}
