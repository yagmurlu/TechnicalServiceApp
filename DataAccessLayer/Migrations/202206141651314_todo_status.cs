namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todo_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "TodoStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Todoes", "Wait");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Todoes", "Wait", c => c.Boolean(nullable: false));
            DropColumn("dbo.Todoes", "TodoStatus");
        }
    }
}
