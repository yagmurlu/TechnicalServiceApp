namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _roleId_Admin_User_added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "Role_RoleId" });
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            RenameColumn(table: "dbo.Admins", name: "Role_RoleId", newName: "RoleId");
            RenameColumn(table: "dbo.Users", name: "Role_RoleId", newName: "RoleId");
            AlterColumn("dbo.Admins", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Admins", "RoleId");
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Admins", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Admins", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Admins", new[] { "RoleId" });
            AlterColumn("dbo.Users", "RoleId", c => c.Int());
            AlterColumn("dbo.Admins", "RoleId", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "Role_RoleId");
            RenameColumn(table: "dbo.Admins", name: "RoleId", newName: "Role_RoleId");
            CreateIndex("dbo.Users", "Role_RoleId");
            CreateIndex("dbo.Admins", "Role_RoleId");
            AddForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles", "RoleId");
            AddForeignKey("dbo.Admins", "Role_RoleId", "dbo.Roles", "RoleId");
        }
    }
}
