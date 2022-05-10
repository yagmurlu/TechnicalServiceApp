namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_admin_NewPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminNewPassword", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminNewPassword");
        }
    }
}
