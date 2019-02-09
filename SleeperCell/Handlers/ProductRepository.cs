using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SleeperCell.Context;
using SleeperCell.Models;
using SleeperCell.ObjectModel;

namespace SleeperCell.Handlers
{
    public class ProductRepository
    {
        private SleeperCellContext _dbContext;

        public ProductRepository()
        {
            _dbContext = new SleeperCellContext();
        }

        public List<ProductViewModel> GetAllProducts()
        {

            return _dbContext.Products.Select(x => new ProductViewModel
            {
                Barcode = x.Barcode,
                CategoryName = x.Category.Name,
                Id = x.Id,
                QuantityInHand = x.Stock.Sum(t => t.QuantityIn - t.QuantityOut),
                Name = x.Name,
                Description = x.Description,
                UnitPrice = x.UnitPrice
            }).ToList();
        }

        public void AddProduct(ProductViewModel model)
        {
            var product = new Product
            {
                Barcode = model.Barcode,
                CategoryId = model.CategoryId,
                Name = model.Name,
                Description = model.Description,
                UnitPrice = model.UnitPrice
            };
            _dbContext.Products.Add(product);

            _dbContext.SaveChanges();
        }

        public ProductViewModel FindProduct(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product == null)
                return null;
            return new ProductViewModel
            {
                Barcode = product.Barcode,
                CategoryName = product.Category.Name,
                Id = product.Id,
                QuantityInHand = product.Stock.Any() ? product.Stock.Sum(t => t.QuantityIn - t.QuantityOut) : 0,
                Name = product.Name,
                Description = product.Description,
                UnitCost = product.Stock.Any() ? product.Stock.Average(a => a.UnitCost) : 0,
                UnitPrice = product.UnitPrice
            };
        }

        public void Update(ProductViewModel model)
        {
            var existingProduct = _dbContext.Products.Find(model.Id);
            if (existingProduct == null) return;
            existingProduct.Barcode = model.Barcode;
            existingProduct.Category = new Category() { Id = model.Id };
            existingProduct.Name = model.Name;
            existingProduct.Description = model.Description;
            existingProduct.UnitPrice = model.UnitPrice;
            _dbContext.Entry(existingProduct).State = System.Data.Entity.EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = _dbContext.Products.Find(id);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}