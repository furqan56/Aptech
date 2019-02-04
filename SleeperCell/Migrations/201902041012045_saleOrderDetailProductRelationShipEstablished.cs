namespace SleeperCell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saleOrderDetailProductRelationShipEstablished : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SaleOrderDetails", new[] { "Product_Id" });
            DropIndex("dbo.SaleOrderDetails", new[] { "SaleOrder_Id" });
            RenameColumn(table: "dbo.SaleOrderDetails", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.SaleOrderDetails", name: "SaleOrder_Id", newName: "SaleOrderId");
            AlterColumn("dbo.SaleOrderDetails", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.SaleOrderDetails", "SaleOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.SaleOrderDetails", "ProductId");
            CreateIndex("dbo.SaleOrderDetails", "SaleOrderId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SaleOrderDetails", new[] { "SaleOrderId" });
            DropIndex("dbo.SaleOrderDetails", new[] { "ProductId" });
            AlterColumn("dbo.SaleOrderDetails", "SaleOrderId", c => c.Int());
            AlterColumn("dbo.SaleOrderDetails", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.SaleOrderDetails", name: "SaleOrderId", newName: "SaleOrder_Id");
            RenameColumn(table: "dbo.SaleOrderDetails", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.SaleOrderDetails", "SaleOrder_Id");
            CreateIndex("dbo.SaleOrderDetails", "Product_Id");
        }
    }
}
