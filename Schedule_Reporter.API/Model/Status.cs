namespace Schedule_Reporter.API.Model
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<EmployeeWorkDay>? EmployeeWorkdays { get; set; }
    }
}
