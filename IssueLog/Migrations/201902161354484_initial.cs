namespace IssueLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ClientId = c.Int(nullable: false),
                        ProjectManagerId = c.Int(nullable: false),
                        ProjectLeaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ClientId)
                .ForeignKey("dbo.Users", t => t.ProjectLeaderId)
                .ForeignKey("dbo.Users", t => t.ProjectManagerId)
                .Index(t => t.ClientId)
                .Index(t => t.ProjectManagerId)
                .Index(t => t.ProjectLeaderId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UserTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectManagerId", "dbo.Users");
            DropForeignKey("dbo.Projects", "ProjectLeaderId", "dbo.Users");
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.Projects", new[] { "ProjectLeaderId" });
            DropIndex("dbo.Projects", new[] { "ProjectManagerId" });
            DropIndex("dbo.Projects", new[] { "ClientId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
        }
    }
}
