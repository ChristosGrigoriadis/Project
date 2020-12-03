namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavouriteBeersRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserBeers",
                c => new
                    {
                        FavouriteBeerId = c.Int(nullable: false),
                        BeerEnthusiastId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FavouriteBeerId, t.BeerEnthusiastId })
                .ForeignKey("dbo.AspNetUsers", t => t.BeerEnthusiastId)
                .ForeignKey("dbo.Beers", t => t.FavouriteBeerId)
                .Index(t => t.FavouriteBeerId)
                .Index(t => t.BeerEnthusiastId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBeers", "FavouriteBeerId", "dbo.Beers");
            DropForeignKey("dbo.UserBeers", "BeerEnthusiastId", "dbo.AspNetUsers");
            DropIndex("dbo.UserBeers", new[] { "BeerEnthusiastId" });
            DropIndex("dbo.UserBeers", new[] { "FavouriteBeerId" });
            DropTable("dbo.UserBeers");
        }
    }
}
