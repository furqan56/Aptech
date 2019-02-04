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
        private CategoryRepository _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View(_categoryRepository.GetAllCategory());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View(_categoryRepository.FindCategory(id));
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
                _categoryRepository.AddCategory(model);
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
            return View(_categoryRepository.FindCategory(id));
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                _categoryRepository.Update(model);
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
            return View(_categoryRepository.FindCategory(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(CategoryViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _categoryRepository.Delete(model.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
