namespace Naive_bayes.Data_Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedallclassess : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "dbo.PenetrationDataPoints", name: "IX_Angle_Id", newName: "IX_PenetrationDataPoint_Angle_Id");
            RenameIndex(table: "dbo.PenetrationDataPoints", name: "IX_Armor_Id", newName: "IX_PenetrationDataPoint_Armor_Id");
            RenameIndex(table: "dbo.PenetrationDataPoints", name: "IX_Penetration_Id", newName: "IX_PenetrationDataPoint_Penetration_Id");
            RenameIndex(table: "dbo.PenetrationDataPoints", name: "IX_ShellSize_Id", newName: "IX_PenetrationDataPoint_ShellSize_Id");
            RenameIndex(table: "dbo.PenetrationDataPoints", name: "IX_ShellType_Id", newName: "IX_PenetrationDataPoint_ShellType_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PenetrationDataPoints", name: "IX_PenetrationDataPoint_ShellType_Id", newName: "IX_ShellType_Id");
            RenameIndex(table: "dbo.PenetrationDataPoints", name: "IX_PenetrationDataPoint_ShellSize_Id", newName: "IX_ShellSize_Id");
            RenameIndex(table: "dbo.PenetrationDataPoints", name: "IX_PenetrationDataPoint_Penetration_Id", newName: "IX_Penetration_Id");
            RenameIndex(table: "dbo.PenetrationDataPoints", name: "IX_PenetrationDataPoint_Armor_Id", newName: "IX_Armor_Id");
            RenameIndex(table: "dbo.PenetrationDataPoints", name: "IX_PenetrationDataPoint_Angle_Id", newName: "IX_Angle_Id");
        }
    }
}
