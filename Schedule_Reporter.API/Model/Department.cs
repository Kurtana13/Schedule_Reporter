namespace Schedule_Reporter.API.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? MinWorkDaysPerMonth { get; set; }

        public virtual ICollection<AttendanceSummary> ?AttendanceSummaries { get; set; }
        public virtual ICollection<Employee> ?Employees { get; set; }
    }
}
