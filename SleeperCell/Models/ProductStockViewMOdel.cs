using System;
using System.Collections.Generic;
using SleeperCell.ObjectModel;

namespace SleeperCell.Models
{
    public class ProductStockViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double RetailPrice { get; set; }
        public double UnitCost { get; set; }
        public List<string> ProductName  { get; set; }
        public String Vendor { get; set; }
        public DateTime CreationDate { get; set; }
    }
    
}