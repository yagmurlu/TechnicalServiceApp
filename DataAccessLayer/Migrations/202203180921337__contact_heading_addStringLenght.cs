namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _contact_heading_addStringLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Content", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Content", c => c.String());
        }
    }
}
