namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _contact_heading_addStringLenght1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Contents", c => c.String(maxLength: 500));
            DropColumn("dbo.Contacts", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Content", c => c.String(maxLength: 500));
            DropColumn("dbo.Contacts", "Contents");
        }
    }
}
