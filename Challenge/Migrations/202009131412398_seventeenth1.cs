namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventeenth1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Problems", name: "Winner_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Problems", name: "IX_Winner_Id", newName: "IX_ApplicationUser_Id");
            AddColumn("dbo.Problems", "WinnerFK", c => c.String());
            DropColumn("dbo.AspNetUsers", "Points");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Points", c => c.Int(nullable: false));
            DropColumn("dbo.Problems", "WinnerFK");
            RenameIndex(table: "dbo.Problems", name: "IX_ApplicationUser_Id", newName: "IX_Winner_Id");
            RenameColumn(table: "dbo.Problems", name: "ApplicationUser_Id", newName: "Winner_Id");
        }
    }
}
