using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Models;
using SleeperCell.Context;
using SleeperCell.ObjectModel;

namespace SleeperCell.Handlers
{
    public class VendorRepository
    {
        public static List<VendorViewModel> VendorsStore { get; private set; } = new List<VendorViewModel>();

        private SleeperCellContext _dbContext;

        public VendorRepository()
        {
            _dbContext = new SleeperCellContext();
        }

        public static int VendorId { get; private set; } = 1;

        public List<SelectListItem> GetVendorSelectList(int selectedId = -1)
        {
            return _dbContext.Vendors
                .Select(x => new { x.Id, x.Name }).ToList()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = selectedId == x.Id
                }).ToList();
        }

        public List<VendorViewModel> GetAllVendors()
        {
            return _dbContext.Vendors.Select(x => new VendorViewModel
            {
                Name = x.Name,
                Phone = x.Phone,
                Address = x.Address,
                Email = x.Email,
                Id = x.Id
            }).ToList();
        }

        public void AddVendor(VendorViewModel model)
        {
            _dbContext.Vendors.Add(new Vendor
            {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Address = model.Address,
                Email = model.Email
            });
            _dbContext.SaveChanges();
        }

        public VendorViewModel FindVendor(int Id)
        {
            Vendor vendor = _dbContext.Vendors.Find(Id);
            if (vendor == null)
                return null;
            return new VendorViewModel
            {
                Name = vendor.Name,
                Phone = vendor.Phone,
                Address = vendor.Address,
                Email = vendor.Email,
                Id = vendor.Id
            };
        }

        public void Update(VendorViewModel model)
        {
            var existingVendor = _dbContext.Vendors.Find(model.Id);
            if (existingVendor == null) return;

            existingVendor.Id = model.Id;
            existingVendor.Address = model.Address;
            existingVendor.Email = model.Email;
            existingVendor.Phone = model.Phone;
            existingVendor.Name = model.Name;

            _dbContext.Entry(existingVendor).State = System.Data.Entity.EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var vendor = _dbContext.Vendors.Find(id);
            _dbContext.Vendors.Remove(vendor);
            _dbContext.SaveChanges();
        }
    }
}