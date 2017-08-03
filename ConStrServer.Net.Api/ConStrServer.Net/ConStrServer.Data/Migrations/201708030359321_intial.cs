namespace ConStrServer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConnectionStrings",
                c => new
                    {
                        ConnectionStringId = c.Int(nullable: false, identity: true),
                        MachineId = c.Int(nullable: false),
                        ConnectionStringName = c.String(),
                        ConnectionStringUrl = c.String(),
                    })
                .PrimaryKey(t => t.ConnectionStringId)
                .ForeignKey("dbo.Machines", t => t.MachineId, cascadeDelete: true)
                .Index(t => t.MachineId);
            
            CreateTable(
                "dbo.EnvironmentInfoes",
                c => new
                    {
                        EnvironmentId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        EnvironmentName = c.Int(nullable: false),
                        LoadBalenced = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnvironmentId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        MachineId = c.Int(nullable: false, identity: true),
                        EnvironmentId = c.Int(nullable: false),
                        MachineNickName = c.String(),
                        MachineName = c.String(),
                        MachineIpAddress = c.String(),
                        MachinePort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineId)
                .ForeignKey("dbo.EnvironmentInfoes", t => t.EnvironmentId, cascadeDelete: true)
                .Index(t => t.EnvironmentId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectOwner = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnvironmentInfoes", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Machines", "EnvironmentId", "dbo.EnvironmentInfoes");
            DropForeignKey("dbo.ConnectionStrings", "MachineId", "dbo.Machines");
            DropIndex("dbo.Machines", new[] { "EnvironmentId" });
            DropIndex("dbo.EnvironmentInfoes", new[] { "ProjectId" });
            DropIndex("dbo.ConnectionStrings", new[] { "MachineId" });
            DropTable("dbo.Projects");
            DropTable("dbo.Machines");
            DropTable("dbo.EnvironmentInfoes");
            DropTable("dbo.ConnectionStrings");
        }
    }
}
