namespace SleeperCell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductStockAdded : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProductStocks", new[] { "Product_Id" });
            RenameColumn(table: "dbo.ProductStocks", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.ProductStocks", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductStocks", "ProductId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductStocks", new[] { "ProductId" });
            AlterColumn("dbo.ProductStocks", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.ProductStocks", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.ProductStocks", "Product_Id");
        }
    }
}
