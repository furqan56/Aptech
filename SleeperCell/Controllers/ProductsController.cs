using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Handlers;
using SleeperCell.Models;

namespace SleeperCell.Controllers
{
    public class ProductsController : Controller
    {
        private ProductRepository _productRepository;

        // GET: Products
        public ProductsController()
        {
            _productRepository = new ProductRepository();
        }
        public ActionResult Index()
        {
            return View(_productRepository.GetAllProducts());
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            return View(_productRepository.FindProduct(Id));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            return View(_productRepository.FindProduct(Id));
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            return View(_productRepository.FindProduct(Id));
        }
        [HttpPost]
        public ActionResult Delete(ProductViewModel model)
        {
            _productRepository.Delete(model.Id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productRepository.AddProduct(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}