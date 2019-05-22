namespace SessionPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Session", "CreatedUtc", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Session", "ModifiedUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Session", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Session", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
