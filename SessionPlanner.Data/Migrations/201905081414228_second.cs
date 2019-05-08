namespace SessionPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "LastName");
            DropColumn("dbo.ApplicationUser", "FirstName");
        }
    }
}
