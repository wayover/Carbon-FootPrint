namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linieprod : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Linie_Produkcyjne", "SurowiecID");
            AddForeignKey("dbo.Linie_Produkcyjne", "SurowiecID", "dbo.Surowiecs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Linie_Produkcyjne", "SurowiecID", "dbo.Surowiecs");
            DropIndex("dbo.Linie_Produkcyjne", new[] { "SurowiecID" });
        }
    }
}
