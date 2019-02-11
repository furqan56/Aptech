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
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public double UnitCost { get; set; }

        public string Product { get; set; }
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public string Vendor { get; set; }
        public DateTime CreationDate { get; set; }
    }
}