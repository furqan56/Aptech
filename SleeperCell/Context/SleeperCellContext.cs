using SleeperCell.ObjectModel;
using System.Data.Entity;
using SleeperCell.Context.Configuration;

namespace SleeperCell.Context
{
    public class SleeperCellContext : Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext
    {
        public SleeperCellContext() : base("name=DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(ProductConfiguration).Assembly);




            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleOrder> Sales { get; set; }
        public DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }

        public static SleeperCellContext Create()
        {
            return new SleeperCellContext();
        }
    }
}