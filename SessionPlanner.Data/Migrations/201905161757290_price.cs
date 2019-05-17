namespace SessionPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class price : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Session", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Session", "StartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Session", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Session", "EndTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Session", "StartTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Session", "Price");
        }
    }
}
