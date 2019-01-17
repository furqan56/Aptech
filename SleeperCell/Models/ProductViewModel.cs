using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleeperCell.Models
{
    public class ProductViewModel
    {
        //productID, Barcode, productName, Description, Price, Sku
        public int ProductID { get; set; }
         public int Barcode { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public double UnitCost { get; set; }

        public double UnitPrice { get; set; }

        public int QuantityinHand { get; set; }

        public string CategoryName { get; set; }

    }
}