namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVenueBeerPriceColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VenueBeers", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VenueBeers", "Price");
        }
    }
}
