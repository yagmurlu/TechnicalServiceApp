namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _user_newPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AdminNewPassword", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AdminNewPassword");
        }
    }
}
