using System;

namespace SleeperCell.Models
{
    public class ProductStockViewModel
    {
        public int Id { get; set; }
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public double UnitCost { get; set; }
        public String Product { get; set; }
        public String Vendor { get; set; }
        public DateTime CreationDate { get; set; }
    }
    
}