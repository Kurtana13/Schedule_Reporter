﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Schedule_Reporter.API.Data;

#nullable disable

namespace Schedule_Reporter.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241117153207_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Schedule_Reporter.API.Model.AttendanceSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("TotalAttendances")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("AttendanceSummaries");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MinWorkDaysPerMonth")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.EmployeeWorkDay", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("WorkDayId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "WorkDayId");

                    b.HasIndex("StatusId");

                    b.HasIndex("WorkDayId");

                    b.ToTable("EmployeeWorkDays");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.WorkDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("WorkDays");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.AttendanceSummary", b =>
                {
                    b.HasOne("Schedule_Reporter.API.Model.Department", "Department")
                        .WithMany("AttendanceSummaries")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedule_Reporter.API.Model.Employee", "Employee")
                        .WithOne("AttendanceSummary")
                        .HasForeignKey("Schedule_Reporter.API.Model.AttendanceSummary", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.Employee", b =>
                {
                    b.HasOne("Schedule_Reporter.API.Model.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.EmployeeWorkDay", b =>
                {
                    b.HasOne("Schedule_Reporter.API.Model.Employee", "Employee")
                        .WithMany("EmployeeWorkDays")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedule_Reporter.API.Model.Status", "Status")
                        .WithMany("EmployeeWorkdays")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Schedule_Reporter.API.Model.WorkDay", "WorkDay")
                        .WithMany("EmployeeWorkDays")
                        .HasForeignKey("WorkDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Status");

                    b.Navigation("WorkDay");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.Department", b =>
                {
                    b.Navigation("AttendanceSummaries");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.Employee", b =>
                {
                    b.Navigation("AttendanceSummary");

                    b.Navigation("EmployeeWorkDays");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.Status", b =>
                {
                    b.Navigation("EmployeeWorkdays");
                });

            modelBuilder.Entity("Schedule_Reporter.API.Model.WorkDay", b =>
                {
                    b.Navigation("EmployeeWorkDays");
                });
#pragma warning restore 612, 618
        }
    }
}