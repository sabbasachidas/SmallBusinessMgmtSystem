namespace Spectrum.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newpurchase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "Code", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "SupplierName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "SupplierName");
            DropColumn("dbo.Purchases", "Code");
        }
    }
}
