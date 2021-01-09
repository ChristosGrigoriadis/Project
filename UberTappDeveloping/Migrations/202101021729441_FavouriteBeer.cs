namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavouriteBeer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavBeers",
                c => new
                    {
                        UserThatFollows = c.String(nullable: false, maxLength: 128),
                        BeerToBeFollowed = c.Int(nullable: false),
                        Beer_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserThatFollows, t.BeerToBeFollowed })
                .ForeignKey("dbo.Beers", t => t.Beer_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Beer_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavBeers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavBeers", "Beer_Id", "dbo.Beers");
            DropIndex("dbo.FavBeers", new[] { "User_Id" });
            DropIndex("dbo.FavBeers", new[] { "Beer_Id" });
            DropTable("dbo.FavBeers");
        }
    }
}
