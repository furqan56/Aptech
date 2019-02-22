namespace SleeperCell.ObjectModel
{
    public class SaleOrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SaleOrderId { get; set; }
        public double UnitPrice { get; set; }
        public int QtyOrdered { get; set; }
        public double LineTotal { get; set; }
        public SaleOrder SaleOrder { get; set; }
        public Product Product { get; set; }
    }
}