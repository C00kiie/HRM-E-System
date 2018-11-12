﻿using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System;
using MySql.Data.Entity;

namespace HRM_MVVM.Model
{
    class HRM_DB : DbContext
    {
        public HRM_DB()
            : base("HRM_DB")
        {
            
        }
        public DbSet<activity> Activities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<attendance> Attendances { get; set; }
        public DbSet<HolidayRequests> HolidayRequests{ get; set; }

    }

}
