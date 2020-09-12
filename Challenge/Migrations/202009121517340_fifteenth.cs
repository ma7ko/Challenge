namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifteenth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProblemUserModels", "Solution");
        }
        
        public override void Down()
        {
        }
    }
}
