using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleeperCell.Models;
namespace SleeperCell.Handlers
{
    public class StockRepository
    {
        public static List<StockViewModel> StockStore { get; set; } = new List<StockViewModel>();
        public static int ProudctId { get; set; } = 1;
        public List<StockViewModel> GetAllProducts()
        {
            return StockStore;
        }

        public void AddStock(StockViewModel model)
        {
            model.ProductID = ProudctId++;
            StockStore.Add(model);
        }

        public StockViewModel FindSockDetail(int id)
        {
            return StockStore.FirstOrDefault(p => p.ProductID == id);
        }

        public void Update(StockViewModel model)
        {
            StockStore.RemoveAll(p => p.ProductID == model.ProductID);
            StockStore.Add(model);
        }

        public void Delete(StockViewModel model)
        {
            StockStore.RemoveAll(p => p.ProductID == model.ProductID);
        }
    }
}