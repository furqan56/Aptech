using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace SleeperCell.Models
{
    public class orderViewModel
    {
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Product Quantity")]
        public decimal ProductQuantity { get; set; }
        [DisplayName("Product Description")]
        public string PDescription { get; set; }
       
    }
}