namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VenueOwnersAndBeersCascadeDeleteTrue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VenueBeers", "AvailableBeerId", "dbo.Beers");
            DropForeignKey("dbo.VenueBeers", "VenueId", "dbo.Venues");
            AddForeignKey("dbo.VenueBeers", "AvailableBeerId", "dbo.Beers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VenueBeers", "VenueId", "dbo.Venues", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VenueBeers", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.VenueBeers", "AvailableBeerId", "dbo.Beers");
            AddForeignKey("dbo.VenueBeers", "VenueId", "dbo.Venues", "Id");
            AddForeignKey("dbo.VenueBeers", "AvailableBeerId", "dbo.Beers", "Id");
        }
    }
}
