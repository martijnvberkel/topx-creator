namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TMLO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FieldMappings", "TMLO", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FieldMappings", "TMLO");
        }
    }
}
