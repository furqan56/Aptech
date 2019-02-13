using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using SleeperCell.Context;
using SleeperCell.Models;
using SleeperCell.ObjectModel;
using System;

namespace SleeperCell.Handlers
{
    public class ProductStockRepository
    {
        private SleeperCellContext _dbContext;



        public ProductStockRepository()
        {
            _dbContext = new SleeperCellContext();
        }


        public List<SelectListItem> GetProductSelectList(int selectedId = -1)
        {
            return _dbContext.Products
                .Select(x => new { x.Id, x.Name }).ToList()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = selectedId == x.Id
                }).ToList();
        }

        public List<ProductStockViewModel> GetAllProductStocks()
        {

            return _dbContext.ProductStocks.Select(x => new ProductStockViewModel
            {
                Product = x.Product.Name,
               
                QuantityIn = x.QuantityIn,
                Id = x.Id,
                QuantityOut = x.QuantityOut,
                CreationDate = x.CreationDate,
                UnitCost = x.UnitCost,
                Vendor = x.Vendor.Name
            }).ToList();
        }

        public void AddProductStock(ProductStockViewModel model)
        {
            var ProductStock = new ProductStock
            {
                ProductId = model.ProductId,
                QuantityIn = model.QuantityIn,
                QuantityOut = 0,
                CreationDate = DateTime.Now,
                VendorId = model.VendorId,
                UnitCost = model.UnitCost,
            };
            _dbContext.ProductStocks.Add(ProductStock);

            _dbContext.SaveChanges();
        }

        public ProductStockViewModel FindProductStock(int id)
        {
            var ProductStock = _dbContext.ProductStocks.Find(id);
            if (ProductStock == null)
                return null;
            return new ProductStockViewModel
            { 
                QuantityIn = ProductStock.QuantityIn,
                UnitCost = ProductStock.UnitCost,
            };
        }

        public void Update(ProductStockViewModel model)
        {
            var existingProductStock = _dbContext.ProductStocks.Find(model.Id);
            if (existingProductStock == null) return;
            existingProductStock.QuantityIn = model.QuantityIn;
            existingProductStock.UnitCost = model.UnitCost;
            _dbContext.Entry(existingProductStock).State = System.Data.Entity.EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var ProductStock = _dbContext.ProductStocks.Find(id);
            _dbContext.ProductStocks.Remove(ProductStock);
            _dbContext.SaveChanges();
        }
    }
}