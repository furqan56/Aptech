using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Models;
using SleeperCell.Handlers;

namespace SleeperCell.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryRepositry _CategoryRepositry;

        public CategoryController()
        {
            _CategoryRepositry = new CategoryRepositry();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View(_CategoryRepositry.GetAllCategory());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View(_CategoryRepositry.FindCategory(id));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                _CategoryRepositry.AddCategory(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_CategoryRepositry.FindCategory(id));
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                _CategoryRepositry.Update(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_CategoryRepositry.FindCategory(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(CategoryViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _CategoryRepositry.Delete(model.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
