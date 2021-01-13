namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNotificationUsersCascadeDeleteTrue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserNotifications", "BeerEnthusiastId", "dbo.AspNetUsers");
            AddForeignKey("dbo.UserNotifications", "BeerEnthusiastId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "BeerEnthusiastId", "dbo.AspNetUsers");
            AddForeignKey("dbo.UserNotifications", "BeerEnthusiastId", "dbo.AspNetUsers", "Id");
        }
    }
}
