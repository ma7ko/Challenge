namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixteenth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProblemUserModels", "Solution", c => c.String());
        }
        
        public override void Down()
        {
        }
    }
}
