namespace Spectrum.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "Product_Id", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "Product_Id" });
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ManuFractureDateTime = c.DateTime(nullable: false),
                        ExpireDateTime = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        MRP = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        PurchaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PurchaseId);
            
            AlterColumn("dbo.Purchases", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Purchases", "ManufactureDate");
            DropColumn("dbo.Purchases", "ExpireDate");
            DropColumn("dbo.Purchases", "Quantity");
            DropColumn("dbo.Purchases", "UnitPrice");
            DropColumn("dbo.Purchases", "TotalPrice");
            DropColumn("dbo.Purchases", "PreviousUnit");
            DropColumn("dbo.Purchases", "PreviousMRP");
            DropColumn("dbo.Purchases", "MRP");
            DropColumn("dbo.Purchases", "Remarks");
            DropColumn("dbo.Purchases", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "Product_Id", c => c.Int());
            AddColumn("dbo.Purchases", "Remarks", c => c.String());
            AddColumn("dbo.Purchases", "MRP", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "PreviousMRP", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "PreviousUnit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "ExpireDate", c => c.DateTime());
            AddColumn("dbo.Purchases", "ManufactureDate", c => c.DateTime());
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            AlterColumn("dbo.Purchases", "Date", c => c.DateTime());
            DropTable("dbo.PurchaseDetails");
            CreateIndex("dbo.Purchases", "Product_Id");
            AddForeignKey("dbo.Purchases", "Product_Id", "dbo.Products", "Id");
        }
    }
}
