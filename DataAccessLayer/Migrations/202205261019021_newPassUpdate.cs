namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newPassUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserNewPassword", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserNewPassword", c => c.String());
        }
    }
}
