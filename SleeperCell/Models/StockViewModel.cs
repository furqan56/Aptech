using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleeperCell.Models
{
    public class StockViewModel
    {
        public String Date { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public double CostPerUnit { get; set; }

     //   public double PricePerUnit { get; set; }

        public string Description { get; set; }

        public string Vender { get; set; }


    }
}