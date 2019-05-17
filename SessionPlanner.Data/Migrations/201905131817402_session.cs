namespace SessionPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class session : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SessionType", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SessionType", "OwnerID");
        }
    }
}
