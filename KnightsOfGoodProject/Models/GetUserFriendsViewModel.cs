using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnightsOfGoodProject.Models;

namespace KnightsOfGoodProject.Models
{
	public class GetUserFriendsViewModel
	{
		public List<ApplicationUser> friends { get; set; }
		public int Count { get; set; }
	}
}