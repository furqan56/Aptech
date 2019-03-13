﻿using System.Web.Mvc;
using SleeperCell.Handlers;
using SleeperCell.Models;

namespace SleeperCell.Controllers
{
    public class ProductsController : Controller
    {
        private ProductService _productService;
        private CategoryService _categoryService;

        // GET: Products
        public ProductsController()
        {
            _categoryService = new CategoryService();
            _productService = new ProductService();
        }
        public ActionResult Index()
        {
            return View(_productService.GetAllProducts());
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var product = _productService.FindProduct(Id);
            ViewBag.CategorySelectList = _categoryService.GetSelectList(product.CategoryId);
            return View(product);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CategorySelectList = _categoryService.GetSelectList();
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            return View(_productService.FindProduct(Id));
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            return View(_productService.FindProduct(Id));
        }
        [HttpPost]
        public ActionResult Delete(ProductViewModel model)
        {
            _productService.Delete(model.Id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}