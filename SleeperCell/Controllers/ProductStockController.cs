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

        private ProductStockRepository _ProductStockRepositry;
        private VendorRepository _VendorStockRepository;

        public ProductStockController()
        {
            _VendorStockRepository = new VendorRepository();
            _ProductStockRepositry = new ProductStockRepository();
        }

        // GET: ProductStock
        public ActionResult Index()
        {
          
            return View(_ProductStockRepositry.GetAllProductStocks());
        }

        // GET: ProductStock/Create
        public ActionResult Create()
        {
            ViewBag.VendorSelectList = _VendorStockRepository.GetVendorSelectList();
            ViewBag.ProductSelectList = _ProductStockRepositry.GetProductSelectList();
            return View();
        }

        // POST: ProductStock/Create
        [HttpPost]
        public ActionResult Create(ProductStockViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                _ProductStockRepositry.AddProductStock(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View( _ProductStockRepositry.FindProductStock(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductStockViewModel model)
        {
            _ProductStockRepositry.Update(model);
            return RedirectToAction("index");
        }

    }
}
