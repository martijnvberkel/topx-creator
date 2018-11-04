namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bestanden",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Dossier_IdentificatieKenmerk = c.String(maxLength: 50),
                        Naam = c.String(),
                        Relatie_RelatieId = c.String(maxLength: 50),
                        Relatie_TypeRelatie = c.String(maxLength: 50),
                        Relatie_DatumOfPperiode = c.String(maxLength: 50),
                        Vorm_RedactieGenre = c.String(maxLength: 50),
                        Formaat_IdentificatieKenmerk = c.String(maxLength: 50),
                        Formaat_Bestandsnaam_Naam = c.String(maxLength: 50),
                        Formaat_Bestandsnaam_Extentie = c.String(maxLength: 10),
                        Formaat_Omvang = c.Long(),
                        Formaat_Bestandsformaat = c.String(maxLength: 50),
                        Formaat_FysiekeIntegriteit_Algoritme = c.String(maxLength: 50),
                        Formaat_FysiekeIntegriteit_Waarde = c.String(maxLength: 250),
                        Formaat_FysiekeIntegriteit_DatumEnTijd = c.DateTime(),
                        Formaat_DatumAanmaak = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dossiers", t => t.Dossier_IdentificatieKenmerk)
                .Index(t => t.Dossier_IdentificatieKenmerk);
            
            CreateTable(
                "dbo.Dossiers",
                c => new
                    {
                        IdentificatieKenmerk = c.String(nullable: false, maxLength: 50),
                        Naam = c.String(),
                        Classificatie_Code = c.String(maxLength: 50),
                        Classificatie_Omschrijving = c.String(maxLength: 50),
                        Classificatie_Bron = c.String(maxLength: 50),
                        Classificatie_DatumOfPeriode = c.String(maxLength: 50),
                        Dekking_InTijd_Begin = c.String(maxLength: 50),
                        Dekking_InTijd_Eind = c.String(maxLength: 50),
                        Dekking_GeografischGebied = c.String(),
                        Taal = c.String(maxLength: 10),
                        Eventgeschiedenis_DatumOfPeriode = c.String(maxLength: 50),
                        Eventgeschiedenis_Type = c.String(maxLength: 50),
                        Eventgeschiedenis_VerantwoordelijkeFunctionaris = c.String(maxLength: 50),
                        Eventplan_DatumOfPeriode = c.String(maxLength: 50),
                        Eventplan_DatumOfPeriode_Type = c.String(maxLength: 50),
                        Eventplan_Aanleiding = c.String(maxLength: 50),
                        Eventplan_Beschrijving = c.String(),
                        Relatie_Id = c.String(maxLength: 50),
                        Relatie_Type = c.String(maxLength: 50),
                        Relatie_DatumOfPeriode = c.String(maxLength: 50),
                        Context_Actor_IdentificatieKenmerk = c.String(maxLength: 50),
                        Context_Actor_AggregatieNiveau = c.String(maxLength: 50),
                        Context_Actor_GeautoriseerdeNaam = c.String(maxLength: 50),
                        Context_Activiteit_Naam = c.String(maxLength: 50),
                        Gebruiksrechten_OmschrijvingVoorwaarden = c.String(),
                        Gebruiksrechten_DatumOfPeriode = c.String(maxLength: 50),
                        Vertrouwelijkheid_ClassificatieNiveau = c.String(maxLength: 50),
                        Vertrouwelijkheid_DatumOfPeriode = c.String(maxLength: 50),
                        Openbaarheid_OmschrijvingBeperkingen = c.String(maxLength: 50),
                        Openbaarheid_DatumOfPeriode = c.String(maxLength: 50),
                        Integriteit = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdentificatieKenmerk);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Naam = c.String(),
                        Taal = c.String(maxLength: 10),
                        Gebruiksrechten_OmschrijvingVoorwaarden = c.String(),
                        Gebruiksrechten_DatumOfPeriode = c.String(maxLength: 50),
                        Vertrouwelijkheid_ClassificatieNiveau = c.String(maxLength: 50),
                        Vertrouwelijkheid_DatumOfPeriode = c.String(maxLength: 50),
                        Openbaarheid_OmschrijvingBeperkingen = c.String(),
                        Bestand_Vorm_Redactiegenre = c.String(maxLength: 50),
                        Bestand_Formaat_Bestandsnaam = c.String(maxLength: 50),
                        Bestand_Formaat_BestandsOmvang = c.Long(),
                        Bestand_Formaat_BestandsFormaat = c.String(maxLength: 20),
                        Bestand_Formaat_FysiekeIntegriteit_Algoritme = c.String(maxLength: 10),
                        Bestand_Formaat_FysiekeIntegriteit_Waarde = c.String(maxLength: 250),
                        Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd = c.String(maxLength: 50),
                        Bestand_Formaat_DatumAanmaak = c.String(maxLength: 50),
                        DossierId = c.String(maxLength: 50),
                        Relatie_RelatieId = c.String(maxLength: 50),
                        Relatie_TypeRelatie = c.String(maxLength: 50),
                        Relatie_DatumOfPperiode = c.String(maxLength: 50),
                        Bestand_Formaat_IdentificatieKenmerk = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dossiers", t => t.DossierId)
                .Index(t => t.DossierId);
            
            CreateTable(
                "dbo.FieldMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatabaseFieldName = c.String(maxLength: 250),
                        MappedFieldName = c.String(maxLength: 250),
                        Type = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateTime = c.DateTime(),
                        Identifier = c.String(maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "DossierId", "dbo.Dossiers");
            DropForeignKey("dbo.Bestanden", "Dossier_IdentificatieKenmerk", "dbo.Dossiers");
            DropIndex("dbo.Records", new[] { "DossierId" });
            DropIndex("dbo.Bestanden", new[] { "Dossier_IdentificatieKenmerk" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Log");
            DropTable("dbo.FieldMappings");
            DropTable("dbo.Records");
            DropTable("dbo.Dossiers");
            DropTable("dbo.Bestanden");
        }
    }
}
