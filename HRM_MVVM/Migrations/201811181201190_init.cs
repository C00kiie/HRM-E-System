namespace HRM_MVVM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ActivityId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Day = c.DateTime(nullable: false),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(nullable: false),
                        DepartmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.EmployeeInfoes",
                c => new
                    {
                        EmployeeInfoId = c.Int(nullable: false),
                        Name = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Experience = c.Int(nullable: false),
                        JoinedSince = c.DateTime(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeInfoId)
                .ForeignKey("dbo.Employees", t => t.EmployeeInfoId)
                .Index(t => t.EmployeeInfoId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Permission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.logins",
                c => new
                    {
                        LoginId = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsActivated = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoginId)
                .ForeignKey("dbo.Employees", t => t.LoginId)
                .Index(t => t.LoginId);
            
            CreateTable(
                "dbo.HolidayRequests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        HStatus_ = c.Int(nullable: false),
                        HolidayPermissionLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId);
            
            CreateTable(
                "dbo.Employee_Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false, identity: true),
                        StartingPoint = c.DateTime(nullable: false),
                        EndPoint = c.DateTime(nullable: false),
                        details = c.String(nullable: false),
                        status_ = c.Int(nullable: false),
                        Priority_ = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeInfoes", "EmployeeInfoId", "dbo.Employees");
            DropForeignKey("dbo.logins", "LoginId", "dbo.Employees");
            DropIndex("dbo.logins", new[] { "LoginId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "EmployeeInfoId" });
            DropTable("dbo.Employee_Tasks");
            DropTable("dbo.HolidayRequests");
            DropTable("dbo.logins");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeInfoes");
            DropTable("dbo.Departments");
            DropTable("dbo.Attendances");
            DropTable("dbo.Activities");
        }
    }
}
