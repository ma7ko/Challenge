namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Problems", "ChallengeFK", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Problems", "ChallengeFK");
        }
    }
}
