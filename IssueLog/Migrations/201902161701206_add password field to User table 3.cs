namespace IssueLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpasswordfieldtoUsertable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Passoword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Passoword", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Password");
        }
    }
}
