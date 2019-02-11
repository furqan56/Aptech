using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SleeperCell.Context;
using SleeperCell.Models;
using SleeperCell.ObjectModel;

namespace SleeperCell.Handlers
{
    public class ProductStockService
    {
        private SleeperCellContext _dbContext;
        
        public ProductStockService()
        {
            _dbContext = new SleeperCellContext();
        }

        public List<ProductStockViewModel> GetPoductStock()
        {
            return _dbContext.ProductStocks.Select(x => new ProductStockViewModel
            {
                Id = x.Id,
                QuantityIn = x.QuantityIn,
                QuantityOut = x.QuantityOut,
                UnitCost = x.UnitCost,
                Product = x.Product.Name,
                Vendor = x.Vendor.Name,
                CreationDate = x.CreationDate
            }).ToList();
        }

        //public void AddProductStock(ProductStockViewModel model)
        //{
        //    var stock = new ProductStock
        //    {
        //        QuantityIn = model.QuantityIn,
        //        QuantityOut = model.QuantityOut,
        //        UnitCost = model.UnitCost,
        //        Product = model.Product,
        //        Vendor = model.VendorName,
        //        CreationDate = model.CreationDate
        //    };
        //    _dbContext.ProductStocks.Add(stock);
        //    _dbContext.SaveChanges();
        //}

        //public ProductStockViewModel FindProductStock(int id)
        //{
        //    var stock = _dbContext.ProductStocks.Find(id);
        //    if (stock == null)
        //        return null;
        //    return new ProductStockViewModel
        //    {
        //        Id = stock.Id,
        //        QuantityIn = stock.QuantityIn,
        //        QuantityOut = stock.QuantityOut,
        //        UnitCost = stock.UnitCost,
        //        ProductName = stock.Product.Name,
        //        VendorName = stock.Product.Name,
        //        CreationDate = stock.CreationDate
        //    };
        //}

        //public void Update(ProductStockViewModel model)
        //{
        //    var existingStock = _dbContext.ProductStocks.Find(model.Id)
        //    if (existingStock == null) return;
        //    existingStock.QuantityIn = model.QuantityIn;
        //    existingStock.QuantityOut = model.QuantityOut;
        //    existingStock.UnitCost = model.UnitCost;
        //    existingStock.ProductName = new Product() { Id = model.ProductId };
        //    existingStock.VendorName = new Vendor() { Id = model.VendorId };
        //    existingStock.CreationDate = model.CreationDate;
        //    _dbContext.Entry(existingStock).State = EntityState.Modified;
        //    _dbContext.SaveChanges();
        //}

        public void Delete(int id)
        {
            var stock = _dbContext.ProductStocks.Find(id);
            _dbContext.ProductStocks.Remove(stock);
            _dbContext.SaveChanges();
        }
    }
}