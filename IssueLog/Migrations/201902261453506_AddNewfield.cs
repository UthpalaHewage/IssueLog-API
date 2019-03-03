namespace IssueLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "Status");
        }
    }
}
