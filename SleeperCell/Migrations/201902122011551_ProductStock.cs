namespace SleeperCell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductStock : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductStocks", "Vendor_Id", "dbo.Vendors");
            DropIndex("dbo.ProductStocks", new[] { "Vendor_Id" });
            CreateTable(
                "dbo.ProductStockViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        UnitCost = c.Double(nullable: false),
                        Product = c.String(),
                        Vendor = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductStocks", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.ProductStocks", "QuantityIn");
            DropColumn("dbo.ProductStocks", "QuantityOut");
            DropColumn("dbo.ProductStocks", "VednorId");
            DropColumn("dbo.ProductStocks", "Vendor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductStocks", "Vendor_Id", c => c.Int());
            AddColumn("dbo.ProductStocks", "VednorId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductStocks", "QuantityOut", c => c.Int(nullable: false));
            AddColumn("dbo.ProductStocks", "QuantityIn", c => c.Int(nullable: false));
            DropColumn("dbo.ProductStocks", "Quantity");
            DropTable("dbo.ProductStockViewModels");
            CreateIndex("dbo.ProductStocks", "Vendor_Id");
            AddForeignKey("dbo.ProductStocks", "Vendor_Id", "dbo.Vendors", "Id");
        }
    }
}
