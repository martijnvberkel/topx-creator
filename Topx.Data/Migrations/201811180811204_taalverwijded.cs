namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taalverwijded : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Records", "Taal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Records", "Taal", c => c.String(maxLength: 10));
        }
    }
}
