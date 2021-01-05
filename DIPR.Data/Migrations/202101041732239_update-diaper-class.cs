namespace DIPR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatediaperclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diapers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Diapers", "Name");
        }
    }
}
