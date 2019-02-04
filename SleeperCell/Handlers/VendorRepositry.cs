using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using SleeperCell.Models;
using SleeperCell.ObjectModel;
using SleeperCell.Context;

namespace SleeperCell.Handlers
{
    public class VendorRepository
    {
        private SleeperCellContext _context;
        public static int VendorId { get; private set; } = 1;

        public VendorRepository()
        {
            _context = new SleeperCellContext();
        }

        public List<VendorViewModel> GetAllVendors()
        {
            var vendors = _context.Vendors.ToList();
            var vendorViewModel = new List<VendorViewModel>();

            foreach (var vendor in vendors)
            {
                var viewModel = TransformToViewModel(vendor);
                vendorViewModel.Add(viewModel);
            }
            return vendorViewModel;
        }

        public void AddVendor(VendorViewModel model)
        {
            var vendor = TransformToObjectModel(model);
            vendor.Id = VendorId++;

            _context.Vendors.Add(vendor);
            _context.SaveChanges();
        }

        public Vendor Find(int Id)
        {
            return _context.Set<Vendor>().FirstOrDefault(p => p.Id == Id);
        }

        public void Update(VendorViewModel model)
        {
            var vendor = TransformToObjectModel(model);

            var existing = Find(vendor.Id);
            _context.Entry(existing).CurrentValues.SetValues(vendor);
            _context.Entry(existing).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var vendor = Find(id);
            _context.Entry(vendor).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        private Vendor TransformToObjectModel(VendorViewModel viewModel)
        {
            return new Vendor
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Phone = viewModel.Phone,
                Email = viewModel.Email,
                Address = viewModel.Address
            };
        }

        private VendorViewModel TransformToViewModel(Vendor model)
        {
            return new VendorViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address
            };
        }
    }
}