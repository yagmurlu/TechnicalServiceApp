namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _contact_draft_trash_spam_read : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "Trash", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "IsRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "IsSpam", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Contacts", "Contents", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Contents", c => c.String(maxLength: 500));
            DropColumn("dbo.Contacts", "IsSpam");
            DropColumn("dbo.Contacts", "IsRead");
            DropColumn("dbo.Contacts", "Trash");
            DropColumn("dbo.Contacts", "IsDraft");
        }
    }
}
