using System.Data.Entity.ModelConfiguration;
using SleeperCell.ObjectModel;

namespace SleeperCell.Context.Configuration
{
    public class SaleOrderDetailConfiguration : EntityTypeConfiguration<SaleOrderDetail>
    {
        public SaleOrderDetailConfiguration()
        {
            HasRequired(x => x.SaleOrder).WithMany(x => x.Detail)
                .HasForeignKey(x => x.SaleOrderId).WillCascadeOnDelete(false);
        }
    }
}