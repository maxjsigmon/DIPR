namespace DIPR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BottleFeedings", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BottleFeedings", "Name");
        }
    }
}
