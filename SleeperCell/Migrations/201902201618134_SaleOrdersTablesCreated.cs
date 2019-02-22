namespace SleeperCell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleOrdersTablesCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaleOrderDetails", "UnitPrice", c => c.Double(nullable: false));
            DropColumn("dbo.SaleOrderDetails", "UnitCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SaleOrderDetails", "UnitCost", c => c.Double(nullable: false));
            DropColumn("dbo.SaleOrderDetails", "UnitPrice");
        }
    }
}
