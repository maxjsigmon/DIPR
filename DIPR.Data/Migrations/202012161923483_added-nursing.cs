namespace DIPR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednursing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nursings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentID = c.Guid(nullable: false),
                        TimeFed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FeedingSide = c.Int(nullable: false),
                        Notes = c.String(),
                        BabyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Babies", t => t.BabyID, cascadeDelete: true)
                .Index(t => t.BabyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nursings", "BabyID", "dbo.Babies");
            DropIndex("dbo.Nursings", new[] { "BabyID" });
            DropTable("dbo.Nursings");
        }
    }
}
