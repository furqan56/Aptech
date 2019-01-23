using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace SleeperCell.Models
{
    public class CatagoryViewModel
    {
        public int Id { get; set; }
        [DisplayName("Catagory Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}