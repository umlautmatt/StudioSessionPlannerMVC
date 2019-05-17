namespace SessionPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quantity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Session", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Session", "Quantity", c => c.Int(nullable: false));
        }
    }
}
