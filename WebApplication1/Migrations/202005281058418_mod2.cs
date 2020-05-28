namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Etaps", "SurowiecId");
            AddForeignKey("dbo.Etaps", "SurowiecId", "dbo.Surowiecs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etaps", "SurowiecId", "dbo.Surowiecs");
            DropIndex("dbo.Etaps", new[] { "SurowiecId" });
        }
    }
}
