namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourteenth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Problems", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Problems", "ApplicationUser_Id");
            AddForeignKey("dbo.Problems", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Problems", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Problems", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Problems", "ApplicationUser_Id");
        }
    }
}
