namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserVenueFollowingModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserVenueFollowings",
                c => new
                    {
                        VenueId = c.Int(nullable: false),
                        BeerEnthusiastId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.VenueId, t.BeerEnthusiastId })
                .ForeignKey("dbo.AspNetUsers", t => t.BeerEnthusiastId, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId)
                .Index(t => t.BeerEnthusiastId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserVenueFollowings", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.UserVenueFollowings", "BeerEnthusiastId", "dbo.AspNetUsers");
            DropIndex("dbo.UserVenueFollowings", new[] { "BeerEnthusiastId" });
            DropIndex("dbo.UserVenueFollowings", new[] { "VenueId" });
            DropTable("dbo.UserVenueFollowings");
        }
    }
}
