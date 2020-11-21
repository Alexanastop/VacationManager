using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using VacationManager.Domain.Entities;

namespace VacationManager.Application.Interfaces
{
	public interface IVacationManagerDbContext
	{
		DbSet<App> Applications { get; set; }

		//DbSet<Employee> Employees { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);

		DatabaseFacade Database { get; }
	}
}
