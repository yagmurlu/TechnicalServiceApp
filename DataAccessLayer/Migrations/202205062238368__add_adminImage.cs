namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _add_adminImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "UserImage", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "UserImage");
        }
    }
}
