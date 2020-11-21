using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VacationManager.Domain.Entities;

namespace VacationManager.Persistence
{
	public class VacationManagerDbInitializer
	{
		public static void Seed(VacationManagerDbContext context)
		{
			if (!context.Users.Any())
			{
				context.Users.AddRange(new Employee
				{
					FirstName = "Alexandros",
					LastName = "Anastopoulos",
					Email = "alexanastop@gmail.com",
					Id = "1",
				},
				new Employee
				{
					FirstName = "George",
					LastName = "Test",
					Email = "test@gmail.com",
					Id = "2"
				});
			}

			if (!context.Applications.Any())
			{
				context.Applications.AddRange(new[] {
					new App()
					{
						EmployeeId = "1",
						DateSubmited = DateTime.Now,
						VacationStartDate = DateTime.Now.AddDays(10),
						VacationEndDate = DateTime.Now.AddDays(20),
						DaysRequested = 10,
						Reason = "Vacation",
						Status = "Accepted"
					},
					new App()
					{
						EmployeeId = "1",
						DateSubmited = DateTime.Now,
						VacationStartDate = DateTime.Now.AddDays(30),
						VacationEndDate = DateTime.Now.AddDays(40),
						DaysRequested = 10,
						Reason = "Vacation",
						Status = "Accepted"
					},
					new App()
					{
						EmployeeId = "2",
						DateSubmited = DateTime.Now,
						VacationStartDate = DateTime.Now.AddDays(50),
						VacationEndDate = DateTime.Now.AddDays(60),
						DaysRequested = 10,
						Reason = "Vacation",
						Status = "Accepted"
					},
				});
			}

			if (!context.Roles.Any())
			{
				context.Roles.AddRange(new IdentityRole
				{
					Id = "1",
					Name = "Admin"
				});
			}

			context.SaveChanges();
		}
	}
}
