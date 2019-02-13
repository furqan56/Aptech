using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SleeperCell.Context;
using SleeperCell.Models;
using SleeperCell.ObjectModel;

namespace SleeperCell.Handlers
{
    public class ProductService
    {
        private SleeperCellContext _dbContext;

        public ProductService()
        {
            _dbContext = new SleeperCellContext();
        }

        public List<SelectListItem> GetSelectList(int selectedId = -1)
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

        public List<Product> GetProduct(int id, string Name)
        {
           return _dbContext.Products.Where(p => p.Id == id).ToList();
        }

        public List<ProductViewModel> GetAllProducts()
        {

            return _dbContext.Products.Select(x => new ProductViewModel
            {
                Barcode = x.Barcode,
                CategoryName = x.Category.Name,
                ID = x.Id,
                ProductName = x.Name,
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
                Name = model.ProductName,
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
                ID = product.Id,
               // QuantityInHand = product.Stock.Any() ? product.Stock.Sum(t => t.QuantityIn - t.QuantityOut) : 0,
                ProductName = product.Name,
                Description = product.Description,
                UnitCost = product.Stock.Any() ? product.Stock.Average(a => a.UnitCost) : 0,
                UnitPrice = product.UnitPrice
            };
        }

        public void Update(ProductViewModel model)
        {
            var existingProduct = _dbContext.Products.Find(model.ID);
            if (existingProduct == null) return;
            existingProduct.Barcode = model.Barcode;
            existingProduct.Category = new Category() { Id = model.ID };
            existingProduct.Name = model.ProductName;
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
