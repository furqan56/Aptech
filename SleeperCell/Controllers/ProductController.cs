using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Handlers;
using SleeperCell.Models;
namespace SleeperCell.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;
        // GET: Products
        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        public ActionResult Index()
        {
            return View(_productRepository.GetAllProducts());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
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


        [HttpGet]
        public ActionResult Update(int id)
        {
            var product = _productRepository.FindProductDetail(id);
            return View(product);

        }
        [HttpPost]
        public ActionResult Update(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(model);
                return RedirectToAction("Index");

            }
            return View(model);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = _productRepository.FindProductDetail(id);
            return View(product);
        }

        [HttpDelete]
        public ActionResult Delete(ProductViewModel model)
        {
            _productRepository.Delete(model);

            return View(model);
        }
    }
}