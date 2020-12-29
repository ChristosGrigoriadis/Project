namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageAndProfileImageModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VenueProfileImage",
                c => new
                    {
                        VenueId = c.Int(nullable: false),
                        Name = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.VenueId)
                .ForeignKey("dbo.Venues", t => t.VenueId)
                .Index(t => t.VenueId);
            
            CreateTable(
                "dbo.VenueImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContentType = c.String(),
                        Data = c.Binary(),
                        VenueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VenueImages", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.VenueProfileImage", "VenueId", "dbo.Venues");
            DropIndex("dbo.VenueImages", new[] { "VenueId" });
            DropIndex("dbo.VenueProfileImage", new[] { "VenueId" });
            DropTable("dbo.VenueImages");
            DropTable("dbo.VenueProfileImage");
        }
    }
}
