namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenth : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProblemUserModels");
            AlterColumn("dbo.ProblemUserModels", "ProblemFK", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ProblemUserModels", "UserFK", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ProblemUserModels", new[] { "ProblemFK", "UserFK" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProblemUserModels");
            AlterColumn("dbo.ProblemUserModels", "UserFK", c => c.Int(nullable: false));
            AlterColumn("dbo.ProblemUserModels", "ProblemFK", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProblemUserModels", new[] { "ProblemFK", "UserFK" });
        }
    }
}
