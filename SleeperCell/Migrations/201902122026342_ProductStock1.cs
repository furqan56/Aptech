namespace SleeperCell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductStock1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductStockViewModels", "RetailPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductStockViewModels", "RetailPrice", c => c.String());
        }
    }
}
