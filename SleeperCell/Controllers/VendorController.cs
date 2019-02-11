using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Models;
using SleeperCell.Handlers;

namespace SleeperCell.Controllers
{
    public class VendorController : Controller
    {
        private VendorService _VendorRepositry;

        public VendorController()
        {
            _VendorRepositry = new VendorService();
        }

        // GET: Vendor
        public ActionResult Index()
        {
            return View(_VendorRepositry.GetAllVendors());
        }

        // GET: Vendor/Details/5
        public ActionResult Details(int id)
        {
            return View(_VendorRepositry.FindVendor(id));
        }

        // GET: Vendor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendor/Create
        [HttpPost]
        public ActionResult Create(VendorViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                _VendorRepositry.AddVendor(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Vendor/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_VendorRepositry.FindVendor(id));
        }

        // POST: Vendor/Edit/5
        [HttpPost]
        public ActionResult Edit(VendorViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                _VendorRepositry.Update(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Vendor/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_VendorRepositry.FindVendor(id));
        }

        // POST: Vendor/Delete/5
        [HttpPost]
        public ActionResult Delete(VendorViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _VendorRepositry.Delete(model.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
