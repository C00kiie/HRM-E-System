namespace HRM_MVVM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                        Lat = c.String(nullable: false),
                        Long = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        JoinedSince = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Experience = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        IsActivated = c.Int(nullable: false),
                        Permission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HolidayRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestedDay = c.DateTime(nullable: false),
                        HStatus_ = c.Int(nullable: false),
                        HolidayPermissionLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartingPoint = c.DateTime(nullable: false),
                        EndPoint = c.DateTime(nullable: false),
                        details = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Priority_ = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tasks");
            DropTable("dbo.HolidayRequests");
            DropTable("dbo.Employees");
            DropTable("dbo.attendances");
            DropTable("dbo.activities");
        }
    }
}
