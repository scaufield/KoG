using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnightsOfGoodProject.Models
{
	public class Friends
	{
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
		public string FriendId { get; set; }
		public ApplicationUser Friend { get; set; }
	}
}