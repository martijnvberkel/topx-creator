namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complexlinks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComplexLinks",
                c => new
                    {
                        Dossier_IdentificatieKenmerk = c.String(nullable: false, maxLength: 50),
                        ComplexLinkNummer = c.String(maxLength: 20),
                        Dossiers_IdentificatieKenmerk = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Dossier_IdentificatieKenmerk)
                .ForeignKey("dbo.Dossiers", t => t.Dossiers_IdentificatieKenmerk)
                .Index(t => t.Dossiers_IdentificatieKenmerk);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComplexLinks", "Dossiers_IdentificatieKenmerk", "dbo.Dossiers");
            DropIndex("dbo.ComplexLinks", new[] { "Dossiers_IdentificatieKenmerk" });
            DropTable("dbo.ComplexLinks");
        }
    }
}
