using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleeperCell.Models;

namespace SleeperCell.Handlers
{
    public class ProductRepository
    {
        public static List<ProductViewModel> ProductsStore { get; set; } = new List<ProductViewModel>();
        public static int ProductId { get; set; } = 1;
        public List<ProductViewModel> GetAllProducts()
        {
            return ProductsStore;
        }

        public void AddProduct(ProductViewModel model)
        {
            model.ID = ProductId++;
            ProductsStore.Add(model);
        }

        public void Update(ProductViewModel model)
        {
            ProductsStore.RemoveAll(p => p.ID == model.ID);
            ProductsStore.Add(model);
        }

        public void Delete(int id)
        {
            ProductsStore.RemoveAll(p => p.ID == id);
        }
    }
}