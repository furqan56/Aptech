using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Handlers;

namespace SleeperCell.Controllers
{
    public class ProductStockController : Controller
    {
        private readonly ProductStockService _productStockService;
        public ProductStockController()
        {
            _productStockService = new ProductStockService();
        }
        // GET: ProductStock
        public ActionResult Create(int id = -1)
        {
            if (id == -1)
                return RedirectToAction("Index", "Products");

            var viewModel =  _productStockService.PopulateProductInStock(id);
            
            return View(viewModel);
        }
    }
}