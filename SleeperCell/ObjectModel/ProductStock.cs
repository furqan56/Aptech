using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleeperCell.ObjectModel
{
    public class ProductStock
    {
            public int Id { get; set; }
            public int Quantity { get; set; }
            public double UnitCost { get; set; }
            public virtual List<Product> Product { get; set; }
            public int ProductId { get; set; }
            public DateTime CreationDate { get; set; }

        
    }
}