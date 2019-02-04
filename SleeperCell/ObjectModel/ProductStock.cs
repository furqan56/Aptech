using System;

namespace SleeperCell.ObjectModel
{
    public class ProductStock
    {
        public int Id { get; set; }
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public double UnitCost { get; set; }
        public Product Product { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime CreationDate { get; set; }
    }
    
}