namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "IsSpam");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "IsSpam", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "ContactStatus");
        }
    }
}
