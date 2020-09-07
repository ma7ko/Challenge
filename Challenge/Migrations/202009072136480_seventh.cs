namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Challenge_Id", "dbo.Challenges");
            DropIndex("dbo.AspNetUsers", new[] { "Challenge_Id" });
            CreateTable(
                "dbo.ApplicationUserChallenges",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Challenge_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Challenge_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Challenges", t => t.Challenge_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Challenge_Id);
            
            DropColumn("dbo.AspNetUsers", "Challenge_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Challenge_Id", c => c.Int());
            DropForeignKey("dbo.ApplicationUserChallenges", "Challenge_Id", "dbo.Challenges");
            DropForeignKey("dbo.ApplicationUserChallenges", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserChallenges", new[] { "Challenge_Id" });
            DropIndex("dbo.ApplicationUserChallenges", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserChallenges");
            CreateIndex("dbo.AspNetUsers", "Challenge_Id");
            AddForeignKey("dbo.AspNetUsers", "Challenge_Id", "dbo.Challenges", "Id");
        }
    }
}
