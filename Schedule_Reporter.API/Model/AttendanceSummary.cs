namespace Schedule_Reporter.API.Model
{
    public class AttendanceSummary
    {
        public int Id { get; set; }

        public int TotalAttendances { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        

    }
}
