using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleeperCell.Models;

namespace SleeperCell.Handlers
{
    public class CatagoryRepository
    {
        public static List<CatagoryViewModel> CatagoryStore { get; private set; } = new List<CatagoryViewModel>();
        public static int CatagoryId { get; private set; } = 1;
        public List<CatagoryViewModel> GetAllCatagory()
        {
            return CatagoryStore;
        }

        public void AddCatagory(CatagoryViewModel model)
        {
            model.Id = CatagoryId++;
            CatagoryStore.Add(model);
        }

        public void Update(CatagoryViewModel model)
        {
            CatagoryStore.RemoveAll(p => p.Id == model.Id);
            CatagoryStore.Add(model);
        }
        public void Delete(int id)
        {
            CatagoryStore.RemoveAll(p => p.Id == id);
        }
    }
}