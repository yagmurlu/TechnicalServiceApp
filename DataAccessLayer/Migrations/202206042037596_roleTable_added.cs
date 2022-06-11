namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleTable_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Admins", "Role_RoleId", c => c.Int());
            AddColumn("dbo.Users", "Role_RoleId", c => c.Int());
            CreateIndex("dbo.Admins", "Role_RoleId");
            CreateIndex("dbo.Users", "Role_RoleId");
            AddForeignKey("dbo.Admins", "Role_RoleId", "dbo.Roles", "RoleId");
            AddForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Admins", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            DropIndex("dbo.Admins", new[] { "Role_RoleId" });
            DropColumn("dbo.Users", "Role_RoleId");
            DropColumn("dbo.Admins", "Role_RoleId");
            DropTable("dbo.Roles");
        }
    }
}
