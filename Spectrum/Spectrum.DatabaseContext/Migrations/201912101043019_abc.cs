namespace Spectrum.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.SalesDetails", "GrandTotal");
            DropColumn("dbo.SalesDetails", "Discount");
            DropColumn("dbo.SalesDetails", "DiscountAmmount");
            DropColumn("dbo.SalesDetails", "PayableAmmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesDetails", "PayableAmmount", c => c.Int(nullable: false));
            AddColumn("dbo.SalesDetails", "DiscountAmmount", c => c.Int(nullable: false));
            AddColumn("dbo.SalesDetails", "Discount", c => c.Int(nullable: false));
            AddColumn("dbo.SalesDetails", "GrandTotal", c => c.Int(nullable: false));
            AlterColumn("dbo.Sales", "Date", c => c.String());
        }
    }
}
