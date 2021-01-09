namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoriteBeersAndUserFollowing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
            
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
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.FavBeers", new[] { "User_Id" });
            DropIndex("dbo.FavBeers", new[] { "Beer_Id" });
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropTable("dbo.FavBeers");
            DropTable("dbo.Followings");
        }
    }
}
