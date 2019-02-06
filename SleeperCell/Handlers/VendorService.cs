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
        private SleeperCellContext _dbcontext;
        
        public VendorRepository()
        {
            _dbcontext = new SleeperCellContext();
        }

        public List<VendorViewModel> GetAllVendors()
        {
            return _dbcontext.Vendors.Select(x => new VendorViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Email = x.Email,
                Address = x.Address
            }).ToList();
        }

        public void AddVendor(VendorViewModel model)
        {
            var vendor = new Vendor
            {
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address
            };

            _dbcontext.Vendors.Add(vendor);
            _dbcontext.SaveChanges();
        }

        public VendorViewModel FindVendor(int id)
        {
            var vendor = _dbcontext.Vendors.Find(id);
            if (vendor == null)
                return null;
            return new VendorViewModel
            {
                Name = vendor.Name,
                Phone = vendor.Phone,
                Email = vendor.Email,
                Address = vendor.Address
            };
        }

        public void Update(VendorViewModel model)
        {
            var existingVendor = _dbcontext.Vendors.Find(model.Id);
            if (existingVendor == null) return;
            existingVendor.Name = model.Name;
            existingVendor.Phone = model.Phone;
            existingVendor.Email = model.Email;
            existingVendor.Address = model.Address;
            _dbcontext.Entry(existingVendor).State = EntityState.Modified;
            _dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var vendor = _dbcontext.Vendors.Find(id);
            _dbcontext.Vendors.Remove(vendor);
            _dbcontext.SaveChanges();
        }

        //private Vendor TransformToObjectModel(VendorViewModel viewModel)
        //{
        //    return new Vendor
        //    {
        //        Id = viewModel.Id,
        //        Name = viewModel.Name,
        //        Phone = viewModel.Phone,
        //        Email = viewModel.Email,
        //        Address = viewModel.Address
        //    };
        //}

        //private VendorViewModel TransformToViewModel(Vendor model)
        //{
        //    return new VendorViewModel
        //    {
        //        Id = model.Id,
        //        Name = model.Name,
        //        Phone = model.Phone,
        //        Email = model.Email,
        //        Address = model.Address
        //    };
        //}
    }
}