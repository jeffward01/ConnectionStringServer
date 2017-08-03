namespace ConStrServer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EnvironmentInfoes", "EnvironmentName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EnvironmentInfoes", "EnvironmentName", c => c.Int(nullable: false));
        }
    }
}
