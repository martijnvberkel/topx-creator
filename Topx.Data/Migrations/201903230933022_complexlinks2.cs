namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complexlinks2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ComplexLinks");
            AddColumn("dbo.ComplexLinks", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.ComplexLinks", "Id");
            DropColumn("dbo.ComplexLinks", "Dossier_IdentificatieKenmerk");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComplexLinks", "Dossier_IdentificatieKenmerk", c => c.String(nullable: false, maxLength: 50));
            DropPrimaryKey("dbo.ComplexLinks");
            DropColumn("dbo.ComplexLinks", "Id");
            AddPrimaryKey("dbo.ComplexLinks", "Dossier_IdentificatieKenmerk");
        }
    }
}
