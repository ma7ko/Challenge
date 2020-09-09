namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ninth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProblemUserModels",
                c => new
                    {
                        ProblemFK = c.Int(nullable: false),
                        UserFK = c.Int(nullable: false),
                        Solution = c.String(),
                        Problem_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProblemFK, t.UserFK })
                .ForeignKey("dbo.Problems", t => t.Problem_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Problem_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProblemUserModels", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProblemUserModels", "Problem_Id", "dbo.Problems");
            DropIndex("dbo.ProblemUserModels", new[] { "User_Id" });
            DropIndex("dbo.ProblemUserModels", new[] { "Problem_Id" });
            DropTable("dbo.ProblemUserModels");
        }
    }
}
