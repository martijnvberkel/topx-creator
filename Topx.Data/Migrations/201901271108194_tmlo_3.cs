namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tmlo_3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FieldMappings", "TMLO", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FieldMappings", "TMLO", c => c.String(maxLength: 10));
        }
    }
}
