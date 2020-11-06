namespace MDF_DouLaiDian.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init_First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        MyID = c.Int(nullable: false),
                        UserName = c.String(),
                        PassWod = c.String(),
                        Sex = c.String(),
                        Birth = c.DateTime(nullable: false),
                        City = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
