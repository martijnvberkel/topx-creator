namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Globals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Globals",
                c => new
                    {
                        IdentificatieArchief = c.String(nullable: false, maxLength: 128),
                        DatumArchief = c.DateTime(nullable: false),
                        OmschrijvingArchief = c.String(),
                        BronArchief = c.String(),
                        DoelArchief = c.String(),
                        NaamArchief = c.String(),
                    })
                .PrimaryKey(t => t.IdentificatieArchief);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Globals");
        }
    }
}
