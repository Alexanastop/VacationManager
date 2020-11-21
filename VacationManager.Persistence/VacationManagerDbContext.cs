using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace VacationManager.Persistence
{
	public class VacationManagerDbContext : IdentityDbContext
	{
		public VacationManagerDbContext(DbContextOptions<VacationManagerDbContext> options)
			: base(options)
		{
		}
	}
}

