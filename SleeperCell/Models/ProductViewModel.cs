 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SleeperCell.Models
{
    public class ProductViewModel
    {
        //productID, Barcode, productName, Description, UnitCose, UnitPrice, QuantityinHand, CategoryName 
        public int ID { get; set; }

        [Required]        
        [MaxLength(28, ErrorMessage ="Barcode Max Lenth should be 28 ")]
        public string Barcode { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
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