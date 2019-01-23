using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleeperCell.Models;

namespace SleeperCell.Handlers
{
    public class orderRepository
    {

        public static List<orderViewModel> ordersStore { get; private set; } = new List<orderViewModel>();
        public static int orderId { get; private set; } = 1;
        public List<orderViewModel> GetAllorders()
        {
            return ordersStore;
        }

        public void Addorder(orderViewModel model)
        {
            model.Id = orderId++;
            ordersStore.Add(model);
        }

        public void Update(orderViewModel model)
        {
            ordersStore.RemoveAll(p => p.Id == model.Id);
            ordersStore.Add(model);
        }
        public void Delete(int id)
        {
            ordersStore.RemoveAll(p => p.Id == id);
        }
    }
}