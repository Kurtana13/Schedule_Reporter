using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Schedule_Reporter.API.Model;

namespace Schedule_Reporter.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //Relationships 
            builder.Entity<Employee>(b =>
            {
                b.HasKey(x  => x.Id);
            });

            builder.Entity<Department>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .OnDelete(DeleteBehavior.SetNull);

                b.HasMany(d => d.AttendanceSummaries)
                .WithOne(a => a.Department)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<AttendanceSummary>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasOne(a => a.Employee)
                .WithOne(e => e.AttendanceSummary)
                .HasForeignKey<AttendanceSummary>(a => a.EmployeeId);
            });

            builder.Entity<EmployeeWorkDay>(b =>
            {
                b.HasKey(ew => new { ew.EmployeeId, ew.WorkDayId });

                b.HasOne(ew => ew.Employee)
                .WithMany(e => e.EmployeeWorkDays)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(ew => ew.EmployeeId);

                b.HasOne(ew => ew.WorkDay)
                .WithMany(w => w.EmployeeWorkDays)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(ew => ew.WorkDayId);


                b.HasOne(ew => ew.Status)
                .WithMany(s => s.EmployeeWorkdays)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey(ew => ew.StatusId);
            });

            builder.Entity<Status>(b =>
            {
                b.HasKey(x => x.Id);
            });
            
        }




        //Tables
        public DbSet<AttendanceSummary> AttendanceSummaries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<EmployeeWorkDay> EmployeeWorkDays { get; set; }
    }
}
