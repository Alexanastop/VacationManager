using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using VacationManager.Domain.Entities;

namespace VacationManager.Persistence
{
	public class VacationManagerDbContext : IdentityDbContext<Employee>
	{
		public VacationManagerDbContext(DbContextOptions<VacationManagerDbContext> options)
			: base(options)
		{	
        }

		public DbSet<Application> Applications { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.HasDefaultSchema("Identity");
			builder.Entity<Employee>(entity =>
			{
				entity.ToTable(name: "Employee");
			});
			builder.Entity<IdentityRole>(entity =>
			{
				entity.ToTable(name: "Role");
			});
			builder.Entity<IdentityUserRole<string>>(entity =>
			{
				entity.ToTable("EmployeeRoles");
			});
			builder.Entity<IdentityUserClaim<string>>(entity =>
			{
				entity.ToTable("EmployeeClaims");
			});
			builder.Entity<IdentityUserLogin<string>>(entity =>
			{
				entity.ToTable("EmployeeLogins");
			});
			builder.Entity<IdentityRoleClaim<string>>(entity =>
			{
				entity.ToTable("RoleClaims");
			});
			builder.Entity<IdentityUserToken<string>>(entity =>
			{
				entity.ToTable("EmployeeTokens");
			});
		}
	}
}

