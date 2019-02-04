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
        private SleeperCellContext _context;
        public static int CategoryId { get; private set; } = 1;

        public CategoryService()
        {
            _context = new SleeperCellContext();
        }

        public List<SelectListItem> GetSelectList(int selectedId = -1)
        {
            return _context.Categories
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
            var db = new SleeperCellContext().Database;
            _context = new SleeperCellContext();
            var categories = _context.Categories.ToList();

            var categoryViewModel = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                var viewModel = TransformToViewModel(category);

                categoryViewModel.Add(viewModel);
            }

            return categoryViewModel;
        }

        public void AddCategory(CategoryViewModel model)
        {
            var category = TransformToObjectModel(model);
            category.Id = CategoryId++;

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public CategoryViewModel FindCategory(int id)
        {
            Category category = Find(id);

            var categoryViewModel = TransformToViewModel(category);

            return (categoryViewModel);
        }

        private Category Find(int id)
        {
            return _context.Set<Category>().FirstOrDefault(p => p.Id == id);
        }

        public void Update(CategoryViewModel model)
        {
            var category = TransformToObjectModel(model);

            var existing = Find(category.Id);
            _context.Entry(existing).CurrentValues.SetValues(category);
            _context.Entry(existing).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = Find(id);
            _context.Entry(category).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        private Category TransformToObjectModel(CategoryViewModel viewModel)
        {
            return new Category
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description
            };
        }

        private CategoryViewModel TransformToViewModel(Category model)
        {
            return new CategoryViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
        }
    }
}