namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _son : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "Deneme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Deneme", c => c.String());
        }
    }
}
