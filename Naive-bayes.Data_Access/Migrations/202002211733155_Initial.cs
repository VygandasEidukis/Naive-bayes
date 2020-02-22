namespace Naive_bayes.Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Angles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        angle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PenetrationDataPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WillPen = c.Boolean(),
                        armorId = c.Int(nullable: false),
                        angleId = c.Int(nullable: false),
                        penetrationId = c.Int(nullable: false),
                        shellSizeId = c.Int(nullable: false),
                        shellTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Angles", t => t.angleId, cascadeDelete: true)
                .ForeignKey("dbo.Armors", t => t.armorId, cascadeDelete: true)
                .ForeignKey("dbo.Penetrations", t => t.penetrationId, cascadeDelete: true)
                .ForeignKey("dbo.ShellSizes", t => t.shellSizeId, cascadeDelete: true)
                .ForeignKey("dbo.ShellTypes", t => t.shellTypeId, cascadeDelete: true)
                .Index(t => t.armorId)
                .Index(t => t.angleId)
                .Index(t => t.penetrationId)
                .Index(t => t.shellSizeId)
                .Index(t => t.shellTypeId);
            
            CreateTable(
                "dbo.Armors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        armor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Penetrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        penetration = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShellSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShellTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PenetrationDataPoints", "shellTypeId", "dbo.ShellTypes");
            DropForeignKey("dbo.PenetrationDataPoints", "shellSizeId", "dbo.ShellSizes");
            DropForeignKey("dbo.PenetrationDataPoints", "penetrationId", "dbo.Penetrations");
            DropForeignKey("dbo.PenetrationDataPoints", "armorId", "dbo.Armors");
            DropForeignKey("dbo.PenetrationDataPoints", "angleId", "dbo.Angles");
            DropIndex("dbo.PenetrationDataPoints", new[] { "shellTypeId" });
            DropIndex("dbo.PenetrationDataPoints", new[] { "shellSizeId" });
            DropIndex("dbo.PenetrationDataPoints", new[] { "penetrationId" });
            DropIndex("dbo.PenetrationDataPoints", new[] { "angleId" });
            DropIndex("dbo.PenetrationDataPoints", new[] { "armorId" });
            DropTable("dbo.ShellTypes");
            DropTable("dbo.ShellSizes");
            DropTable("dbo.Penetrations");
            DropTable("dbo.Armors");
            DropTable("dbo.PenetrationDataPoints");
            DropTable("dbo.Angles");
        }
    }
}
