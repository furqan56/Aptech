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
    public class ProductRepository
    {
        private SleeperCellContext _context;
        public static int ProductId { get; private set; } = 1;

        public ProductRepository()
        {
            _context = new SleeperCellContext();
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var products = _context.Products.Include(x => x.Category).ToList();
            var productViewModel = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var viewmodel = TransformToViewModel(product);
                productViewModel.Add(viewmodel);
            }
            return productViewModel;
        }

        public void AddProduct(ProductViewModel model)
        {
            var product = TransformToObjectModel(model);
            product.Id = ProductId++;
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public ProductViewModel FindProductDetail(int id)
        {
            Product product = Find(id);
            var productViewModel = TransformToViewModel(product);
            return (productViewModel);
        }

        private Product Find(int id)
        {
            return _context.Set<Product>().FirstOrDefault(p => p.Id == id);
        }

        public void Update(ProductViewModel model)
        {
            var product = TransformToObjectModel(model);
            var existing = Find(product.Id);
            _context.Entry(existing).CurrentValues.SetValues(product);
            _context.Entry(existing).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = Find(id);
            _context.Entry(product).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        private ProductViewModel TransformToViewModel(Product model)
        {
            return new ProductViewModel
            {
                ID = model.Id,
                Barcode = model.Barcode,
                ProductName = model.Name,
                Description = model.Description,
                UnitPrice = model.UnitPrice
            };
        }

        private Product TransformToObjectModel(ProductViewModel viewModel)
        {
            return new Product
            {
                Id = viewModel.ID,
                Barcode = viewModel.Barcode,
                Name = viewModel.ProductName,
                Description = viewModel.Description,
                UnitPrice = viewModel.UnitPrice
            };
        }
    }
}
