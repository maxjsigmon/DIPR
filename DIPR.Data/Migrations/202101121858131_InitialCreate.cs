﻿namespace DIPR.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Babies",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ParentID = c.Guid(nullable: false),
                    Name = c.String(nullable: false),
                    Gender = c.Int(nullable: false),
                    BirthDate = c.DateTime(nullable: false),
                    Notes = c.String(),
                })
                .PrimaryKey(t => t.ID);

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
                    Name = c.String(),
                    BabyID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Babies", t => t.BabyID, cascadeDelete: true)
                .Index(t => t.BabyID);

            CreateTable(
                "dbo.Diapers",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ParentID = c.Guid(nullable: false),
                    Soiled = c.Int(nullable: false),
                    Time = c.DateTime(nullable: false),
                    Notes = c.String(),
                    BabyID = c.Int(nullable: false),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Babies", t => t.BabyID, cascadeDelete: true)
                .Index(t => t.BabyID);

            CreateTable(
                "dbo.Nursings",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ParentID = c.Guid(nullable: false),
                    Time = c.DateTime(nullable: false),
                    TimeFed = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Name = c.String(),
                    FeedingSide = c.Int(nullable: false),
                    Notes = c.String(),
                    BabyID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Babies", t => t.BabyID, cascadeDelete: true)
                .Index(t => t.BabyID);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Sleeps",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ParentID = c.Guid(nullable: false),
                    Location = c.Int(nullable: false),
                    SleepStart = c.DateTime(nullable: false),
                    SleepEnd = c.DateTime(nullable: false),
                    Notes = c.String(),
                    BabyID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Babies", t => t.BabyID, cascadeDelete: true)
                .Index(t => t.BabyID);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sleeps", "BabyID", "dbo.Babies");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Nursings", "BabyID", "dbo.Babies");
            DropForeignKey("dbo.Diapers", "BabyID", "dbo.Babies");
            DropForeignKey("dbo.BottleFeedings", "BabyID", "dbo.Babies");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sleeps", new[] { "BabyID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Nursings", new[] { "BabyID" });
            DropIndex("dbo.Diapers", new[] { "BabyID" });
            DropIndex("dbo.BottleFeedings", new[] { "BabyID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Sleeps");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Nursings");
            DropTable("dbo.Diapers");
            DropTable("dbo.BottleFeedings");
            DropTable("dbo.Babies");
        }
    }
}
