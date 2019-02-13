using System.Data.Entity.ModelConfiguration;
using SleeperCell.ObjectModel;

namespace SleeperCell.Context.Configuration
{
    public class VendorConfiguration: EntityTypeConfiguration<Vendor>
    {

        public VendorConfiguration()
        {
            HasKey(x => x.Id);
            Property(X => X.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasMany(x => x.Stock)
                .WithRequired(x => x.Vendor)
                .HasForeignKey(x => x.VendorId).WillCascadeOnDelete(false);
        }
    }
}