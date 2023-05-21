namespace PasswordSerwice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Service_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credentials", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Credentials", "Service_Id", "dbo.Services");
            DropIndex("dbo.Credentials", new[] { "User_Id" });
            DropIndex("dbo.Credentials", new[] { "Service_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Services");
            DropTable("dbo.Credentials");
        }
    }
}
