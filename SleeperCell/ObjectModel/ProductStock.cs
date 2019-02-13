using System;

namespace SleeperCell.ObjectModel
{
    public class ProductStock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public double UnitCost { get; set; }
        public virtual Product Product { get; set; }
        public virtual Vendor Vendor { get; set; }
        public DateTime CreationDate { get; set; }
    }
    
}