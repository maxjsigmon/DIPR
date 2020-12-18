namespace DIPR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undocreate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BottleFeedings", "Babies_DataGroupField");
            DropColumn("dbo.BottleFeedings", "Babies_DataTextField");
            DropColumn("dbo.BottleFeedings", "Babies_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BottleFeedings", "Babies_DataValueField", c => c.String());
            AddColumn("dbo.BottleFeedings", "Babies_DataTextField", c => c.String());
            AddColumn("dbo.BottleFeedings", "Babies_DataGroupField", c => c.String());
        }
    }
}
