namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todoDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "TodoDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todoes", "TodoDelete");
        }
    }
}
