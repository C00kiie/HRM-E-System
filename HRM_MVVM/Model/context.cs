using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System;
using HRM_MVVM.ViewModels;
using MySql.Data.Entity;

namespace HRM_MVVM.Model
{
    public class HRM_DB : DbContext
    {
        public HRM_DB()
            : base("HRM_DB")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HRM_DB>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<login> Logins { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfos{ get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee_Tasks> Tasks { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<HolidayRequests> HolidayRequests{ get; set; }

    }

}
