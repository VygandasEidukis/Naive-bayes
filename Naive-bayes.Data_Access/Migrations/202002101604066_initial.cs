namespace Naive_bayes.Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                "dbo.Armors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        armor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PenetrationDataPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WillPen = c.Boolean(),
                        Angle_Id = c.Int(),
                        Armor_Id = c.Int(),
                        Penetration_Id = c.Int(),
                        ShellSize_Id = c.Int(),
                        ShellType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Angles", t => t.Angle_Id)
                .ForeignKey("dbo.Armors", t => t.Armor_Id)
                .ForeignKey("dbo.Penetrations", t => t.Penetration_Id)
                .ForeignKey("dbo.ShellSizes", t => t.ShellSize_Id)
                .ForeignKey("dbo.ShellTypes", t => t.ShellType_Id)
                .Index(t => t.Angle_Id)
                .Index(t => t.Armor_Id)
                .Index(t => t.Penetration_Id)
                .Index(t => t.ShellSize_Id)
                .Index(t => t.ShellType_Id);
            
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
            DropForeignKey("dbo.PenetrationDataPoints", "ShellType_Id", "dbo.ShellTypes");
            DropForeignKey("dbo.PenetrationDataPoints", "ShellSize_Id", "dbo.ShellSizes");
            DropForeignKey("dbo.PenetrationDataPoints", "Penetration_Id", "dbo.Penetrations");
            DropForeignKey("dbo.PenetrationDataPoints", "Armor_Id", "dbo.Armors");
            DropForeignKey("dbo.PenetrationDataPoints", "Angle_Id", "dbo.Angles");
            DropIndex("dbo.PenetrationDataPoints", new[] { "ShellType_Id" });
            DropIndex("dbo.PenetrationDataPoints", new[] { "ShellSize_Id" });
            DropIndex("dbo.PenetrationDataPoints", new[] { "Penetration_Id" });
            DropIndex("dbo.PenetrationDataPoints", new[] { "Armor_Id" });
            DropIndex("dbo.PenetrationDataPoints", new[] { "Angle_Id" });
            DropTable("dbo.ShellTypes");
            DropTable("dbo.ShellSizes");
            DropTable("dbo.Penetrations");
            DropTable("dbo.PenetrationDataPoints");
            DropTable("dbo.Armors");
            DropTable("dbo.Angles");
        }
    }
}
