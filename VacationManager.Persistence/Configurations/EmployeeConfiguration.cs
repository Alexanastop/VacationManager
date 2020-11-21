using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationManager.Domain.Entities;

namespace VacationManager.Persistence.Configurations
{
	class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.FirstName).IsRequired().HasMaxLength(150); ;

			builder.Property(e => e.LastName).IsRequired().HasMaxLength(150);

			builder.HasMany(e => e.Applications)
				.WithOne(a => a.Employee)
				.HasForeignKey(d => d.EmployeeId)
				.HasConstraintName("FK_Application_Employee");
		}
		
	}
}
