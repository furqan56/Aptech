using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Handlers;


namespace SleeperCell.Controllers
{
    public class CatagoryController : Controller
    {
        CatagoryRepository _catagoryRepository;
        public CatagoryController()
        {
            _catagoryRepository = new CatagoryRepository();
        }
        // GET: Catagory
        public ActionResult Index()
        {
           
            return View(_catagoryRepository.GetAllCatagory());
        }

        // GET: Catagory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Catagory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catagory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Catagory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Catagory/Edit/5
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

        // GET: Catagory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Catagory/Delete/5
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
