using Org.BouncyCastle.Asn1.Mozilla;

namespace Schedule_Reporter.API.Model
{
    public class WorkDay
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public virtual ICollection<EmployeeWorkDay>? EmployeeWorkDays { get; set; }

    }
}
