namespace SleeperCell.ObjectModel
{
    public class SaleOrderDetail
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int QtyOrdered { get; set; }

        public double LineTotal { get; set; }

        public double UnitCost { get; set; }
    }
}