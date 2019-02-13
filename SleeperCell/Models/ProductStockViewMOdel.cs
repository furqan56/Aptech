using System;

namespace SleeperCell.Models
{
    public class ProductStockViewModel
    {
        public int Id { get; set; }
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public double UnitCost { get; set; }
        public double UnitPrice { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Vendor { get; set; }
        public DateTime CreationDate { get; set; }
    }
    
}