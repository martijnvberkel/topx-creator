namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class veldlengte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dossiers", "Classificatie_Bron", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dossiers", "Classificatie_Bron", c => c.String(maxLength: 50));
        }
    }
}
