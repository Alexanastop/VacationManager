using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using VacationManager.Application.Interfaces;
using VacationManager.Persistence;

namespace VacationManager.UI.MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{

				//using (var context = new VacationManagerDbContext)
				using (var context = (VacationManagerDbContext)scope.ServiceProvider.GetService<IVacationManagerDbContext>())
				{
					var dbCreator = context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
					var migrator = context.GetService<IMigrator>();

					var pendingMigrations = context.Database.GetPendingMigrations();

					if (!dbCreator.Exists())
					{
						dbCreator.Create();

						//Initial migration with schema
						if (pendingMigrations.Any())
						{
							var initialSchemaMigration = pendingMigrations.First();
							migrator.Migrate(initialSchemaMigration);
							pendingMigrations = pendingMigrations.Except(new[] { initialSchemaMigration });
						}

						VacationManagerDbInitializer.Seed(context);
					}

					if (pendingMigrations.Any())
					{
						foreach (var migration in pendingMigrations)
						{
							migrator.Migrate(migration);
						}
					}
				}
			}
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				})
				.ConfigureServices((builder, services) =>
				{
					// Database Context Registration
					services.AddDbContext<IVacationManagerDbContext, VacationManagerDbContext>(opts =>
					{
						opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
					});
				});
	}
}
