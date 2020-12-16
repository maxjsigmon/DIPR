namespace DIPR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbottlefeeding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BottleFeedings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentID = c.Guid(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Consumed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Contents = c.Int(nullable: false),
                        Notes = c.String(),
                        BabyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Babies", t => t.BabyID, cascadeDelete: true)
                .Index(t => t.BabyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BottleFeedings", "BabyID", "dbo.Babies");
            DropIndex("dbo.BottleFeedings", new[] { "BabyID" });
            DropTable("dbo.BottleFeedings");
        }
    }
}
