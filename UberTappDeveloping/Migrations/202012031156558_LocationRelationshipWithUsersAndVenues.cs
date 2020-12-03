namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationRelationshipWithUsersAndVenues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Venues", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "LocationId");
            CreateIndex("dbo.Venues", "LocationId");
            AddForeignKey("dbo.AspNetUsers", "LocationId", "dbo.Locations", "Id");
            AddForeignKey("dbo.Venues", "LocationId", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venues", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.AspNetUsers", "LocationId", "dbo.Locations");
            DropIndex("dbo.Venues", new[] { "LocationId" });
            DropIndex("dbo.AspNetUsers", new[] { "LocationId" });
            DropColumn("dbo.Venues", "LocationId");
            DropColumn("dbo.AspNetUsers", "LocationId");
        }
    }
}
