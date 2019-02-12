namespace SleeperCell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductStock : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductStocks", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductStocks", new[] { "Product_Id" });
            RenameColumn(table: "dbo.ProductStocks", name: "Product_Id", newName: "ProductId");
            AddColumn("dbo.ProductStocks", "VednorId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductStocks", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductStocks", "ProductId");
            AddForeignKey("dbo.ProductStocks", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductStocks", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductStocks", new[] { "ProductId" });
            AlterColumn("dbo.ProductStocks", "ProductId", c => c.Int());
            DropColumn("dbo.ProductStocks", "VednorId");
            RenameColumn(table: "dbo.ProductStocks", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.ProductStocks", "Product_Id");
            AddForeignKey("dbo.ProductStocks", "Product_Id", "dbo.Products", "Id");
        }
    }
}
