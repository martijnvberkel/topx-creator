namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class length_classificatie_omschr : DbMigration
    {
        public override void Up()
        {
            Sql(@"ALTER TABLE [Dossiers] ALTER COLUMN [Classificatie_Omschrijving] nvarchar(250)");
        }
        
        public override void Down()
        {
        }
    }
}
