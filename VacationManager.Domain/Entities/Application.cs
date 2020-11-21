using System;

namespace VacationManager.Domain.Entities
{
	public class Application
	{
		public int Id { get; set; }
		public DateTime DateSubmited { get; set; }
		public DateTime VacationStartDate { get; set; }
		public DateTime VacationEndDate { get; set; }
		public int DaysRequested { get; set; }
		public string Status { get; set; }
		public string Reason { get; set; }
		public string EmployeeId { get; set; }
		public Employee Employee { get; set; }
	}
}
