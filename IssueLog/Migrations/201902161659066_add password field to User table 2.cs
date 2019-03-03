namespace IssueLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpasswordfieldtoUsertable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Passoword", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Passowrd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Passowrd", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Passoword");
        }
    }
}
