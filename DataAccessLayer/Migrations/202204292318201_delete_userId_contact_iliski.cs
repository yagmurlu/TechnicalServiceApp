namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_userId_contact_iliski : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropColumn("dbo.Contacts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "UserId");
            AddForeignKey("dbo.Contacts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
