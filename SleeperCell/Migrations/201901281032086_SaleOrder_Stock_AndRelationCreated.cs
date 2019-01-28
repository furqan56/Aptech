namespace SleeperCell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleOrder_Stock_AndRelationCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaleOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtyOrdered = c.Int(nullable: false),
                        LineTotal = c.Double(nullable: false),
                        UnitCost = c.Double(nullable: false),
                        Product_Id = c.Int(),
                        SaleOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Sales", t => t.SaleOrder_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.SaleOrder_Id);
            
            CreateTable(
                "dbo.ProductStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantityIn = c.Int(nullable: false),
                        QuantityOut = c.Int(nullable: false),
                        UnitCost = c.Double(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Product_Id = c.Int(),
                        Vendor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Vendors", t => t.Vendor_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        CustomerId = c.String(),
                        SubTotal = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        CashReceived = c.Double(nullable: false),
                        CashReturn = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Products", "UnitCost");
            DropColumn("dbo.Products", "QuantityInHand");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "QuantityInHand", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "UnitCost", c => c.Double(nullable: false));
            DropForeignKey("dbo.SaleOrderDetails", "SaleOrder_Id", "dbo.Sales");
            DropForeignKey("dbo.ProductStocks", "Vendor_Id", "dbo.Vendors");
            DropForeignKey("dbo.ProductStocks", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.SaleOrderDetails", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductStocks", new[] { "Vendor_Id" });
            DropIndex("dbo.ProductStocks", new[] { "Product_Id" });
            DropIndex("dbo.SaleOrderDetails", new[] { "SaleOrder_Id" });
            DropIndex("dbo.SaleOrderDetails", new[] { "Product_Id" });
            DropTable("dbo.Sales");
            DropTable("dbo.ProductStocks");
            DropTable("dbo.SaleOrderDetails");
        }
    }
}
