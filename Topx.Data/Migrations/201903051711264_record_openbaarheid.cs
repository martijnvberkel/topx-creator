namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class record_openbaarheid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "Openbaarheid_DatumOfPeriode", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Records", "Openbaarheid_DatumOfPeriode");
        }
    }
}
