namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventModelAndCustomValidation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        VenueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "VenueId", "dbo.Venues");
            DropIndex("dbo.Events", new[] { "VenueId" });
            DropTable("dbo.Events");
        }
    }
}
