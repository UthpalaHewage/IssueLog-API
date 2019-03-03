namespace IssueLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpasswordfieldtoUsertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Passowrd", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Passowrd");
        }
    }
}
