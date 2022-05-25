namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _user_newPassword2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserNewPassword", c => c.String(maxLength: 20));
            DropColumn("dbo.Users", "AdminNewPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AdminNewPassword", c => c.String(maxLength: 20));
            DropColumn("dbo.Users", "UserNewPassword");
        }
    }
}
