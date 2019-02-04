using System.Collections.Generic;
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
        public Category Category { get; set; }
        public List<ProductStock> Stock { get; set; }
        public List<SaleOrderDetail> ItemsSold { get; set; }
    }
    
}