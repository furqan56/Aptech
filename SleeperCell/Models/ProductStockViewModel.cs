using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleeperCell.ObjectModel;

namespace SleeperCell.Models
{
    public class ProductStockViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int RetailPrice { get; set; }
        public double UnitCost { get; set; }
        public string Product { get; set; }
        public int ProductId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}