namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "Challenge_Id", c => c.Int());
            AddColumn("dbo.Problems", "Challenge_Id", c => c.Int());
            CreateIndex("dbo.Participants", "Challenge_Id");
            CreateIndex("dbo.Problems", "Challenge_Id");
            AddForeignKey("dbo.Participants", "Challenge_Id", "dbo.Challenges", "Id");
            AddForeignKey("dbo.Problems", "Challenge_Id", "dbo.Challenges", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Problems", "Challenge_Id", "dbo.Challenges");
            DropForeignKey("dbo.Participants", "Challenge_Id", "dbo.Challenges");
            DropIndex("dbo.Problems", new[] { "Challenge_Id" });
            DropIndex("dbo.Participants", new[] { "Challenge_Id" });
            DropColumn("dbo.Problems", "Challenge_Id");
            DropColumn("dbo.Participants", "Challenge_Id");
        }
    }
}
