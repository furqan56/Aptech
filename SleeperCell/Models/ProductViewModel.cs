 using System;
using System.Collections.Generic;
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

        [Required]
        [Display(Name = "Unit Cost")]
        [Range(0, 9999.99)]
        public double UnitCost { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        [Range(0,9999.99)]
        public double UnitPrice { get; set; }

        [Required]
        [Display(Name = "Qty In Hand")]
        public int QuantityinHand { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

    }
}