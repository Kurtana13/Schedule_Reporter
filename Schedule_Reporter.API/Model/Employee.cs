namespace Schedule_Reporter.API.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;

        public AttendanceSummary? AttendanceSummary { get; set; }
        public Department? Department { get; set; }

        public virtual ICollection<EmployeeWorkDay>? EmployeeWorkDays { get; set; }
    }
}
