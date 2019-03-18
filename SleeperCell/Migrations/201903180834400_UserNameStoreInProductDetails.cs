namespace SleeperCell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameStoreInProductDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UserName");
        }
    }
}
