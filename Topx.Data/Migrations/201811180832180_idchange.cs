namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idchange : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FieldMappings");
            AlterColumn("dbo.FieldMappings", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.FieldMappings", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FieldMappings");
            AlterColumn("dbo.FieldMappings", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.FieldMappings", "Id");
        }
    }
}
