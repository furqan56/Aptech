using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SleeperCell.Context;
using SleeperCell.Models;

namespace SleeperCell.ApiControllers
{
    //public class CategoryController : ApiController
    //{
    //    private SleeperCellContext db = new SleeperCellContext();

    //    // GET: api/Category
    //    public IQueryable<CategoryViewModel> GetCategoryViewModels()
    //    {
    //        return db.CategoryViewModels;
    //    }

    //    // GET: api/Category/5
    //    [ResponseType(typeof(CategoryViewModel))]
    //    public IHttpActionResult GetCategoryViewModel(int id)
    //    {
    //        CategoryViewModel categoryViewModel = db.CategoryViewModels.Find(id);
    //        if (categoryViewModel == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(categoryViewModel);
    //    }

    //    // PUT: api/Category/5
    //    [ResponseType(typeof(void))]
    //    public IHttpActionResult PutCategoryViewModel(int id, CategoryViewModel categoryViewModel)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        if (id != categoryViewModel.Id)
    //        {
    //            return BadRequest();
    //        }

    //        db.Entry(categoryViewModel).State = EntityState.Modified;

    //        try
    //        {
    //            db.SaveChanges();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!CategoryViewModelExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return StatusCode(HttpStatusCode.NoContent);
    //    }

    //    // POST: api/Category
    //    [ResponseType(typeof(CategoryViewModel))]
    //    public IHttpActionResult PostCategoryViewModel(CategoryViewModel categoryViewModel)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        db.CategoryViewModels.Add(categoryViewModel);
    //        db.SaveChanges();

    //        return CreatedAtRoute("DefaultApi", new { id = categoryViewModel.Id }, categoryViewModel);
    //    }

    //    // DELETE: api/Category/5
    //    [ResponseType(typeof(CategoryViewModel))]
    //    public IHttpActionResult DeleteCategoryViewModel(int id)
    //    {
    //        CategoryViewModel categoryViewModel = db.CategoryViewModels.Find(id);
    //        if (categoryViewModel == null)
    //        {
    //            return NotFound();
    //        }

    //        db.CategoryViewModels.Remove(categoryViewModel);
    //        db.SaveChanges();

    //        return Ok(categoryViewModel);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    private bool CategoryViewModelExists(int id)
    //    {
    //        return db.CategoryViewModels.Count(e => e.Id == id) > 0;
    //    }
    //}
}