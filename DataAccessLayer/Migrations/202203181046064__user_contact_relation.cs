namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _user_contact_relation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "UserId");
            AddForeignKey("dbo.Contacts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropColumn("dbo.Contacts", "UserId");
        }
    }
}
