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
                        ActivityId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        type = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.EmployeeInfoes",
                c => new
                    {
                        EmployeeInfoId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Experience = c.Int(nullable: false),
                        JoinedSince = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeInfoId)
                .ForeignKey("dbo.Employees", t => t.EmployeeInfoId)
                .Index(t => t.EmployeeInfoId);
            
            CreateTable(
                "dbo.EmployeeLogins",
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
                        ReqStatus = c.Int(nullable: false),
                        HolidayPermissionsLevel = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeTasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        StartingPoint = c.DateTime(nullable: false),
                        EndPoint = c.DateTime(nullable: false),
                        Details = c.String(nullable: false),
                        Status_ = c.Int(nullable: false),
                        Priority_ = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
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
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Activities", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeTasks", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.HolidayRequests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeLogins", "LoginId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeInfoes", "EmployeeInfoId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Attendances", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeTasks", new[] { "EmployeeId" });
            DropIndex("dbo.HolidayRequests", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeLogins", new[] { "LoginId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "EmployeeInfoId" });
            DropIndex("dbo.Employees", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Activities", new[] { "Employee_Id" });
            DropTable("dbo.Attendances");
            DropTable("dbo.EmployeeTasks");
            DropTable("dbo.HolidayRequests");
            DropTable("dbo.EmployeeLogins");
            DropTable("dbo.EmployeeInfoes");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Activities");
        }
    }
}
