namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastdossiers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Globals", "LastDossierFileName", c => c.String());
            AddColumn("dbo.Globals", "LastRecordsFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Globals", "LastRecordsFileName");
            DropColumn("dbo.Globals", "LastDossierFileName");
        }
    }
}
