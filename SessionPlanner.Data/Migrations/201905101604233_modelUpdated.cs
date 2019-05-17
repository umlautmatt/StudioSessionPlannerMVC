namespace SessionPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelUpdated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Session", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Session", "CustomerID", c => c.Int(nullable: false));
        }
    }
}
