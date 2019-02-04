using System.Data.Entity.ModelConfiguration;
using SleeperCell.ObjectModel;

namespace SleeperCell.Context.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasMany(x => x.ItemsSold)
                .WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);

            HasRequired(x => x.Category)
                .WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}