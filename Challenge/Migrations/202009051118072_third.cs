namespace Challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Challenges", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Challenges", "Name");
        }
    }
}
