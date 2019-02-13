using SleeperCell.ObjectModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SleeperCell.Context.Configuration
{
    public class ProductStockConfiguration : EntityTypeConfiguration<ProductStock>
    {
        public ProductStockConfiguration()
        {
            //HasMany(x => x.Product)
            //    .WithRequired(x => )
            //    .HasForeignKey(x => x.Id).WillCascadeOnDelete(false);
        }
    }
}