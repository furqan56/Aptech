using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SleeperCell.ObjectModel
{
    [Table("Sales")]
    public class SaleOrder
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string CustomerId { get; set; }

        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        public double CashReceived { get; set; }
        public double CashReturn { get; set; }
        public List<SaleOrderDetail> Detail { get; set; }
    }

    
}