using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Context;
using SleeperCell.Models;
using SleeperCell.ObjectModel;

namespace SleeperCell.Handlers
{
    public class CategoryService
    {
        private SleeperCellContext _dbcontext;
        
        public CategoryService()
        {
            _dbcontext = new SleeperCellContext();
        }

        public List<SelectListItem> GetSelectList(int selectedId = -1)
        {
            return _dbcontext.Categories
                .Select(x => new { x.Id, x.Name }).ToList()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = selectedId == x.Id
                }).ToList();
        }
        public List<CategoryViewModel> GetAllCategory()
        {
            return _dbcontext.Categories.Select(x => new CategoryViewModel
            {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    
            }).ToList();
        }

        public void AddCategory(CategoryViewModel model)
        {
            var category = new Category
            {
                Name = model.Name,
                Description = model.Description,
                Products =  new List<Product>() 
            };

            _dbcontext.Categories.Add(category);
            _dbcontext.SaveChanges();
        }

        public CategoryViewModel FindCategory(int id)
        {
            var category = _dbcontext.Categories.Find(id);
            if (category == null)
                return null;
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        //private Category Find(int id)
        //{
        //    return _context.Set<Category>().FirstOrDefault(p => p.Id == id);
        //}

        public void Update(CategoryViewModel model)
        {
            var existingCategory = _dbcontext.Categories.Find(model.Id);
            if (existingCategory == null) return;
            existingCategory.Name = model.Name;
            existingCategory.Description = model.Description;
            _dbcontext.Entry(existingCategory).State = EntityState.Modified;
            _dbcontext.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = _dbcontext.Categories.Find(id);
            _dbcontext.Categories.Remove(category);
            _dbcontext.SaveChanges();
        }

        //private Category TransformToObjectModel(CategoryViewModel viewModel)
        //{
        //    return new Category
        //    {
        //        Id = viewModel.Id,
        //        Name = viewModel.Name,
        //        Description = viewModel.Description
        //    };
        //}

        //private CategoryViewModel TransformToViewModel(Category model)
        //{
        //    return new CategoryViewModel
        //    {
        //        Id = model.Id,
        //        Name = model.Name,
        //        Description = model.Description
        //    };
        //}
    }
}