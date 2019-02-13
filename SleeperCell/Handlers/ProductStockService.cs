using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleeperCell.Models;

namespace SleeperCell.Handlers
{
    public class ProductStockService
    {
        private readonly ProductRepository _productRepository;
        public ProductStockService()
        {
            _productRepository = new ProductRepository();
        }

        public ProductStockViewModel PopulateProductInStock(int productId)
        {
            var product = _productRepository.FindProduct(productId);

            return new ProductStockViewModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                UnitPrice = product.UnitPrice
            };
        }
    }
}