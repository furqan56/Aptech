using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Models;
using SleeperCell.Handlers;

namespace SleeperCell.Controllers
{
    public class SaleOrderController : Controller
    {

        private SaleOrderServices _SaleOrderServices;

        public SaleOrderController()
        {
            _SaleOrderServices = new SaleOrderServices();
        }

        // GET: SaleOrder
        public ActionResult Index()
        {
            
            return View(_SaleOrderServices.GetAllSaleOrders());
        }

        // GET: SaleOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleOrder/Create
        [HttpPost]
        public ActionResult Create(SaleOrderViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                _SaleOrderServices.AddSaleOrder(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: SaleOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleOrder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
