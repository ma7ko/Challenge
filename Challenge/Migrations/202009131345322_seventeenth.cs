namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventeenth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Problems", "WinnerFK", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Problems", "WinnerFK");
        }
    }
}
