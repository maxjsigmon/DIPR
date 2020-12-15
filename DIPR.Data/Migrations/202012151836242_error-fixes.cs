namespace DIPR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorfixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiaperListItems", "Baby_ID", "dbo.Babies");
            DropIndex("dbo.DiaperListItems", new[] { "Baby_ID" });
            DropTable("dbo.DiaperListItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DiaperListItems",
                c => new
                    {
                        BabyID = c.Int(nullable: false, identity: true),
                        DiaperID = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Soiled = c.Int(nullable: false),
                        Notes = c.String(),
                        Baby_ID = c.Int(),
                    })
                .PrimaryKey(t => t.BabyID);
            
            CreateIndex("dbo.DiaperListItems", "Baby_ID");
            AddForeignKey("dbo.DiaperListItems", "Baby_ID", "dbo.Babies", "ID");
        }
    }
}
