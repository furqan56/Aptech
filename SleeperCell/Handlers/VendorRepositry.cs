using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleeperCell.Models;

namespace SleeperCell.Handlers
{
    public class VendorRepository
    {
        public static List<VendorViewModel> VendorsStore { get; private set; } = new List<VendorViewModel>();
        public static int VendorId { get; private set; } = 1;
        public List<VendorViewModel> GetAllVendors()
        {
            return VendorsStore;
        }

        public void AddVendor(VendorViewModel model)
        {
            model.Id = VendorId++;
            VendorsStore.Add(model);
        }

        public VendorViewModel FindVendor(int Id)
        {
            VendorViewModel Pr = VendorsStore.Where(p => p.Id == Id).FirstOrDefault();
            return (Pr);
        }

        public void Update(VendorViewModel model)
        {
            VendorsStore.RemoveAll(p => p.Id == model.Id);
            VendorsStore.Add(model);
        }
        public void Delete(int id)
        {
            VendorsStore.RemoveAll(p => p.Id == id);
        }
    }
}