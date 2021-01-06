namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotificationAndUserNotificationModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        OriginalDate = c.DateTime(),
                        OriginalVenueId = c.Int(),
                        OriginalDescription = c.String(),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        BeerEnthusiastId = c.String(nullable: false, maxLength: 128),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.BeerEnthusiastId, t.NotificationId })
                .ForeignKey("dbo.AspNetUsers", t => t.BeerEnthusiastId)
                .ForeignKey("dbo.Notifications", t => t.NotificationId)
                .Index(t => t.BeerEnthusiastId)
                .Index(t => t.NotificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.UserNotifications", "BeerEnthusiastId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "EventId", "dbo.Events");
            DropIndex("dbo.UserNotifications", new[] { "NotificationId" });
            DropIndex("dbo.UserNotifications", new[] { "BeerEnthusiastId" });
            DropIndex("dbo.Notifications", new[] { "EventId" });
            DropTable("dbo.UserNotifications");
            DropTable("dbo.Notifications");
        }
    }
}
