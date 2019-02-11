using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Models;
using SleeperCell.Handlers;

namespace SleeperCell.Controllers
{
    public class ProductStockController : Controller
    {
        private ProductStockService _stockService;
        private ProductService _productService;
        private VendorService _vendorService;
        
        // GET: Stock

        public ProductStockController()
        {
            _stockService = new ProductStockService();
        }
        public ActionResult Index()
        {
            return View(_stockService.GetPoductStock());
        }

        public ActionResult Edit(int id)
        {
            var productStock = _stockService.FindProductStock(id);
            ViewBag.VendorSelectList = _vendorService.GetSelectList(productStock.VendorId);
            ViewBag.ProductSelectList = _productService.GetSelectList(productStock.ProductId);
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.VendorSelectList = _vendorService.GetSelectList();
            ViewBag.ProductSelectList = _productService.GetSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductStockViewModel model)
        {
            if (ModelState.IsValid)
            { 
                _stockService.AddProductStock(model);
                return RedirectToAction("Index");
        }
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var Stock = _stockService.FindProductStock(id);
            return View(Stock);
        }

        //[HttpPost]
        //public ActionResult Update(ProductStockViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _stockService.Update(model);
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var productStock = _stockService.FindProductStock(id);
            return View(productStock);
        }

        //[HttpDelete]
        //public ActionResult Delete(ProductStockViewModel model)
        //{
        //    _stockService.Delete(model);
        //    return View(model);
        //}
    }
}