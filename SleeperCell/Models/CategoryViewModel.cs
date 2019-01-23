using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace SleeperCell.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}