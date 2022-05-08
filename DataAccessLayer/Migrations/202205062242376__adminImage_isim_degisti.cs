namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _adminImage_isim_degisti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminImage", c => c.String(maxLength: 200));
            DropColumn("dbo.Admins", "UserImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "UserImage", c => c.String(maxLength: 200));
            DropColumn("dbo.Admins", "AdminImage");
        }
    }
}
