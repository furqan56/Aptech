namespace SleeperCell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendorAndProductStockRelationShip : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProductStocks", new[] { "Vendor_Id" });
            RenameColumn(table: "dbo.ProductStocks", name: "Vendor_Id", newName: "VendorId");
            AlterColumn("dbo.ProductStocks", "VendorId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductStocks", "VendorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductStocks", new[] { "VendorId" });
            AlterColumn("dbo.ProductStocks", "VendorId", c => c.Int());
            RenameColumn(table: "dbo.ProductStocks", name: "VendorId", newName: "Vendor_Id");
            CreateIndex("dbo.ProductStocks", "Vendor_Id");
        }
    }
}
