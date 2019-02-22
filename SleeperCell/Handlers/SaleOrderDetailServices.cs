using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleeperCell.Context;
using SleeperCell.Models;

namespace SleeperCell.Handlers
{
    public class SaleOrderDetailServices
    {
        SleeperCellContext _dbContext;

        SaleOrderDetailServices()
        {
            _dbContext = new SleeperCellContext();
        }

        List<SaleOrderDetailViewModel> GetSaleOrderDetails(int id)
        {
            var saleOrdersDetail = _dbContext.SaleOrderDetails.Where(x => x.SaleOrderId == id).ToList();
            List<SaleOrderDetailViewModel> SaleOrdersDetailViewModel = new List<SaleOrderDetailViewModel>();
            SaleOrderDetailViewModel saleOrderDetailViewModel = new SaleOrderDetailViewModel();
            foreach (var SaleOrder in saleOrdersDetail)
            {
                saleOrderDetailViewModel.UnitPrice   =  SaleOrder.UnitPrice;
                saleOrderDetailViewModel.SaleOrderId = SaleOrder.SaleOrderId;
                saleOrderDetailViewModel.QtyOrdered = SaleOrder.QtyOrdered;
                saleOrderDetailViewModel.LineTotal = SaleOrder.LineTotal;
                saleOrderDetailViewModel.Id = SaleOrder.Id;
                saleOrderDetailViewModel.ProductId = SaleOrder.ProductId;

                SaleOrdersDetailViewModel.Add(saleOrderDetailViewModel);    
            }
        
            return SaleOrdersDetailViewModel;
        }

    }
}