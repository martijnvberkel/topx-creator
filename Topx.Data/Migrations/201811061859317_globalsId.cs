namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class globalsId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Globals");
            AddColumn("dbo.Globals", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Globals", "IdentificatieArchief", c => c.String());
            AddPrimaryKey("dbo.Globals", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Globals");
            AlterColumn("dbo.Globals", "IdentificatieArchief", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Globals", "Id");
            AddPrimaryKey("dbo.Globals", "IdentificatieArchief");
        }
    }
}
