using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SleeperCell.ObjectModel
{
    public class Product
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<ProductStock> Stock { get; set; }
        public virtual List<SaleOrderDetail> ItemsSold { get; set; }
    }

    public class ProductStock
    {
        public int Id { get; set; }
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public double UnitCost { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int VednorId { get; set; }
        public virtual Vendor Vendor{ get; set; }
        public DateTime CreationDate { get; set; }
        
    }
    
}