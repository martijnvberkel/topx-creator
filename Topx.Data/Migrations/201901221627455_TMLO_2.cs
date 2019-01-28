namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TMLO_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FieldMappings", "TMLO", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FieldMappings", "TMLO", c => c.String(maxLength: 8));
        }
    }
}
