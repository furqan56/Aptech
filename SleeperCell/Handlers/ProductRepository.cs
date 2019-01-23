﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleeperCell.Models;

namespace SleeperCell.Handlers
{
    public class ProductRepository
    {
       
        public static List<ProductViewModel> ProductsStore { get; private set; } = new List<ProductViewModel>();
        public static int ProductId { get; private set; } = 1;
        public List<ProductViewModel> GetAllProducts()
        {
            return ProductsStore;
        }

        public void AddProduct(ProductViewModel model)
        {
            model.Id = ProductId++;
            ProductsStore.Add(model);
        }

        public ProductViewModel FindProduct(int Id)
        {
            ProductViewModel Pr = ProductsStore.Where(p => p.Id == Id).FirstOrDefault();
            return (Pr);
        }

        public void Update(ProductViewModel model)
        {
            ProductsStore.RemoveAll(p => p.Id == model.Id);
            ProductsStore.Add(model);
        }
        public void Delete(int id)
        {
            ProductsStore.RemoveAll(p => p.Id == id);
        }
    }
}