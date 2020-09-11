namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirteenth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Problems", "UserFK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Problems", "UserFK", c => c.String());
        }
    }
}
