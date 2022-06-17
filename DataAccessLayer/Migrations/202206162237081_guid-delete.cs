namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guiddelete : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.GuidTbls");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GuidTbls",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
