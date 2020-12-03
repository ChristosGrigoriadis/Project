namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VenueUserRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venues", "OwnerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Venues", "OwnerId");
            AddForeignKey("dbo.Venues", "OwnerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venues", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Venues", new[] { "OwnerId" });
            DropColumn("dbo.Venues", "OwnerId");
        }
    }
}
