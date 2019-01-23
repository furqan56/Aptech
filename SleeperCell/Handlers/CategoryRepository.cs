using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleeperCell.Models;

namespace SleeperCell.Handlers
{
    public class CategoryRepository
    {
        public static List<CategoryViewModel> CategoryStore { get; private set; } = new List<CategoryViewModel>();
        public static int CategoryId { get; private set; } = 1;
        public List<CategoryViewModel> GetAllCategory()
        {
            return CategoryStore;
        }

        public void AddCategory(CategoryViewModel model)
        {
            model.Id = CategoryId++;
            CategoryStore.Add(model);
        }

        public CategoryViewModel FindCategory(int Id)
        {
            CategoryViewModel Pr = CategoryStore.Where(p => p.Id == Id).FirstOrDefault();
            return (Pr);
        }

        public void Update(CategoryViewModel model)
        {
            CategoryStore.RemoveAll(p => p.Id == model.Id);
            CategoryStore.Add(model);
        }
        public void Delete(int id)
        {
            CategoryStore.RemoveAll(p => p.Id == id);
        }

    }
}