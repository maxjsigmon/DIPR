namespace DIPR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatenursingprops : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nursings", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nursings", "Name");
        }
    }
}
