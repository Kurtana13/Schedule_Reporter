namespace Schedule_Reporter.API.Model
{
    public class EmployeeWorkDay
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int WorkDayId { get; set; }
        public WorkDay WorkDay { get; set; } = null!;

        public int? StatusId { get; set; }
        public Status Status { get; set; }
    }
}
