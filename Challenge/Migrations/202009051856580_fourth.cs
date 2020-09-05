namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Participants", new[] { "Challenge_Id" });
            AddColumn("dbo.AspNetUsers", "Points", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Challenge_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Challenge_Id");
            DropTable("dbo.Participants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Points = c.Int(nullable: false),
                        Challenge_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.AspNetUsers", new[] { "Challenge_Id" });
            DropColumn("dbo.AspNetUsers", "Challenge_Id");
            DropColumn("dbo.AspNetUsers", "Points");
            CreateIndex("dbo.Participants", "Challenge_Id");
        }
    }
}
