using System.ComponentModel;
namespace SleeperCell.Models
{
    public class ProductViewModel
    {
        
        [DisplayName("id")]
        public int Id { get; set; }
        public string Barcode { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitCost { get; set; }
        public double UnitPrice { get; set; }
        public int QuantityInHand { get; set; }
        public string CategoryName { get; set; }    
    }
}