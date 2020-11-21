using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VacationManager.Domain.Entities;

namespace VacationManager.Persistence.Configurations
{
	class ApplicationConfiguration : IEntityTypeConfiguration<Application>
	{
		public void Configure(EntityTypeBuilder<Application> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.DateSubmited).IsRequired().HasColumnType("datetime");

			builder.Property(p => p.VacationStartDate).IsRequired().HasColumnType("datetime");

			builder.Property(p => p.VacationEndDate).IsRequired().HasColumnType("datetime");

			builder.Property(p => p.DaysRequested).IsRequired().HasColumnType("int");

			builder.Property(p => p.Reason).IsRequired();

			builder.Property(p => p.EmployeeId).IsRequired().HasColumnType("int");

			builder.HasOne(a => a.Employee)
				.WithMany()
				.HasForeignKey(d => d.EmployeeId)
				.HasConstraintName("FK_Employee_Application");
		}
	}
}
