using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Models;
using SleeperCell.Handlers;

namespace SleeperCell.Controllers
{
    public class StockController : Controller
    {
        private StockRepository _stockRepository;
        
        // GET: Stock

        public StockController()
        {
            _stockRepository = new StockRepository();
        }
        public ActionResult Index()
        {
            return View(_stockRepository.GetAllProducts());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StockViewModel model)
        {
            if (ModelState.IsValid)
            { 
                _stockRepository.AddStock(model);
                return RedirectToAction("Index");
        }
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var Stock = _stockRepository.FindSockDetail(id);
            return View(Stock);
        }

        [HttpPost]
        public ActionResult Update(StockViewModel model)
        {
            if (ModelState.IsValid)
            {
                _stockRepository.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var stock = _stockRepository.FindSockDetail(id);
            return View(stock);
        }

        [HttpDelete]
        public ActionResult Delete(StockViewModel model)
        {
            _stockRepository.Delete(model);
            return View(model);
        }
    }
}