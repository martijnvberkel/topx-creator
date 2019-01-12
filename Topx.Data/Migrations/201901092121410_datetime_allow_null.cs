namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime_allow_null : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Records", "Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd", c => c.DateTime());
            AlterColumn("dbo.Records", "Bestand_Formaat_DatumAanmaak", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Records", "Bestand_Formaat_DatumAanmaak", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Records", "Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd", c => c.DateTime(nullable: false));
        }
    }
}
