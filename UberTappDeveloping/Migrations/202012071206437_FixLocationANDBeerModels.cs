namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixLocationANDBeerModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Territory", c => c.String());
            AddColumn("dbo.Locations", "Latitude", c => c.Decimal(nullable: false, precision: 10, scale: 8));
            AddColumn("dbo.Locations", "Longitude", c => c.Decimal(nullable: false, precision: 11, scale: 8));
            AlterColumn("dbo.Beers", "EBC", c => c.Int());
            DropColumn("dbo.Locations", "Country");
            DropColumn("dbo.Locations", "City");
            DropColumn("dbo.Locations", "AddressLine1");
            DropColumn("dbo.Locations", "AddressLine2");
            DropColumn("dbo.Locations", "AddressNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "AddressNumber", c => c.String(nullable: false));
            AddColumn("dbo.Locations", "AddressLine2", c => c.String());
            AddColumn("dbo.Locations", "AddressLine1", c => c.String(nullable: false));
            AddColumn("dbo.Locations", "City", c => c.String(nullable: false));
            AddColumn("dbo.Locations", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Beers", "EBC", c => c.Int(nullable: false));
            DropColumn("dbo.Locations", "Longitude");
            DropColumn("dbo.Locations", "Latitude");
            DropColumn("dbo.Locations", "Territory");
        }
    }
}
