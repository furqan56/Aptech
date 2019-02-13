using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SleeperCell.Context;
using SleeperCell.Models;

namespace SleeperCell.Handlers
{
    public class ProductStockService
    {
        private readonly ProductService _productService;
        private SleeperCellContext _context;

        public ProductStockService()
        {
            _context = new SleeperCellContext();
        }

        public ProductStockViewModel PopulateProductInStock(int productId)
        {
            var product = _context.Products.Find(productId);

            return new ProductStockViewModel
            {
                Category=product.Category.Name,
                ProductId = product.Id,
                ProductName = product.Name,
                UnitPrice = product.UnitPrice
            };
        }
    }
}