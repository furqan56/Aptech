using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SleeperCell.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Barcode { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Unit Cost")]
        public double? UnitCost { get; set; }
        [DisplayName("Unit Price")]
        public double UnitPrice { get; set; }
        [DisplayName("Quantity In Hand")]
        public int? QuantityInHand { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }    
        public int CategoryId { get; set; }    
    }
}