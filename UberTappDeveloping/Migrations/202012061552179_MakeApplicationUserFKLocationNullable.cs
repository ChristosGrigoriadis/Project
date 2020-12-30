namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeApplicationUserFKLocationNullable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "LocationId" });
            AlterColumn("dbo.AspNetUsers", "LocationId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "LocationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "LocationId" });
            AlterColumn("dbo.AspNetUsers", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "LocationId");
        }
    }
}
