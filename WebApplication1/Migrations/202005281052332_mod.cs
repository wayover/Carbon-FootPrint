namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etap_Modul",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModulID = c.Int(nullable: false),
                        EtapID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Etaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        SurowiecId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moduls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Moc = c.Int(nullable: false),
                        Nazwa_nośnikaID = c.Int(nullable: false),
                        SurowiecID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nazwa_nośnika", t => t.Nazwa_nośnikaID, cascadeDelete: true)
                .ForeignKey("dbo.Surowiecs", t => t.SurowiecID, cascadeDelete: true)
                .Index(t => t.Nazwa_nośnikaID)
                .Index(t => t.SurowiecID);
            
            CreateTable(
                "dbo.Linie_Etap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Linie_ProdukcyjneID = c.Int(nullable: false),
                        EtapID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Linie_Produkcyjne",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        SurowiecID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Obliczanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Linie_ProdukcyjneID = c.Int(nullable: false),
                        SurowiecID = c.Int(nullable: false),
                        ilosc_surowca = c.Int(nullable: false),
                        ilosc_produktu = c.Int(nullable: false),
                        Nazwa_nośnikaID = c.Int(nullable: false),
                        czas_pracy = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Moduls", "SurowiecID", "dbo.Surowiecs");
            DropForeignKey("dbo.Moduls", "Nazwa_nośnikaID", "dbo.Nazwa_nośnika");
            DropIndex("dbo.Moduls", new[] { "SurowiecID" });
            DropIndex("dbo.Moduls", new[] { "Nazwa_nośnikaID" });
            DropTable("dbo.Obliczanies");
            DropTable("dbo.Linie_Produkcyjne");
            DropTable("dbo.Linie_Etap");
            DropTable("dbo.Moduls");
            DropTable("dbo.Etaps");
            DropTable("dbo.Etap_Modul");
        }
    }
}
