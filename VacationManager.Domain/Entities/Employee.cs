using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace VacationManager.Domain.Entities
{
	public class Employee : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public ICollection<Application> Applications { get; set; }
	}
}
