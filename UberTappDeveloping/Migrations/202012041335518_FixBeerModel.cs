namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixBeerModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Beers", "EBC", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Beers", "EBC", c => c.Int(nullable: false));
        }
    }
}
