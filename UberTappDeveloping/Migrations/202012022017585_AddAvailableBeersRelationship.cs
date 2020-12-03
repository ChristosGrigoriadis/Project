namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableBeersRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VenueBeers",
                c => new
                    {
                        AvailableBeerId = c.Int(nullable: false),
                        VenueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AvailableBeerId, t.VenueId })
                .ForeignKey("dbo.Venues", t => t.VenueId)
                .ForeignKey("dbo.Beers", t => t.AvailableBeerId)
                .Index(t => t.AvailableBeerId)
                .Index(t => t.VenueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VenueBeers", "AvailableBeerId", "dbo.Beers");
            DropForeignKey("dbo.VenueBeers", "VenueId", "dbo.Venues");
            DropIndex("dbo.VenueBeers", new[] { "VenueId" });
            DropIndex("dbo.VenueBeers", new[] { "AvailableBeerId" });
            DropTable("dbo.VenueBeers");
        }
    }
}
