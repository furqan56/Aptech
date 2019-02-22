using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleeperCell.Models
{
    public class SaleOrderDetailViewModel
    {
        public int    Id           { get; set; }
        public int    ProductId    { get; set; }
        public int    SaleOrderId  { get; set; }
        public int    QtyOrdered   { get; set; }
        public double UnitPrice    { get; set; }
        public double LineTotal    { get; set; }
        public string SaleOrder    { get; set; }
        public string Product      { get; set; }
    }
}