using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleeperCell.Context;
using SleeperCell.ObjectModel;
using SleeperCell.Models;

namespace SleeperCell.Handlers
{
    public class SaleOrderServices
    {
        SleeperCellContext _dbContext;


        public SaleOrderServices()
        {
            _dbContext = new SleeperCellContext();
        }

        public  List<SaleOrderViewModel> GetAllSaleOrders()
        {
            var SaleOrders = _dbContext.Sales.ToList();
            var SaleOrdersViewModel = new List<SaleOrderViewModel>();
            SaleOrderViewModel saleOrderViewModel= new SaleOrderViewModel();
            foreach (var SaleOrder in SaleOrders)
            {
                saleOrderViewModel.CreationDate = SaleOrder.CreationDate;
                saleOrderViewModel.CustomerId = SaleOrder.CustomerId;
                saleOrderViewModel.Discount = SaleOrder.Discount;
                saleOrderViewModel.SubTotal = SaleOrder.SubTotal;
                saleOrderViewModel.Id = SaleOrder.Id;
                saleOrderViewModel.Total = SaleOrder.Total;
                saleOrderViewModel.CashReturn = SaleOrder.CashReturn;
                saleOrderViewModel.CashReceived = SaleOrder.CashReceived;

                
                SaleOrdersViewModel.Add(saleOrderViewModel);
            }
            return SaleOrdersViewModel;
        }

        public void AddSaleOrder(SaleOrderViewModel model)
        {
            _dbContext.Sales.Add(new ObjectModel.SaleOrder {
                CashReceived = model.CashReceived,
                CreationDate = DateTime.Now,
                SubTotal = model.SubTotal,
                CashReturn = model.CashReturn,
                CustomerId = model.CustomerId,
                Discount = model.Discount,
                Id = model.Id,
                Total = model.Total,
                Detail = SaleOrderDetailViewModelIntoSaleOrderDetail(model.Detail)
            });
        }

        List<SaleOrderDetail> SaleOrderDetailViewModelIntoSaleOrderDetail( List<SaleOrderDetailViewModel> saleOrderDetailViewModels )
        {
            List<SaleOrderDetail> saleOrderDetails = new List<SaleOrderDetail>();

            SaleOrderDetail saleOrderDetail = new SaleOrderDetail();
            foreach (var SaleOrder in saleOrderDetailViewModels)
            {
                saleOrderDetail.UnitPrice = SaleOrder.UnitPrice;
                saleOrderDetail.SaleOrderId = SaleOrder.SaleOrderId;
                saleOrderDetail.QtyOrdered = SaleOrder.QtyOrdered;
                saleOrderDetail.LineTotal = SaleOrder.LineTotal;
                saleOrderDetail.Id = SaleOrder.Id;
                saleOrderDetail.ProductId = SaleOrder.ProductId;
                

                saleOrderDetails.Add(saleOrderDetail);
            }

            return saleOrderDetails;
        }
    }
}