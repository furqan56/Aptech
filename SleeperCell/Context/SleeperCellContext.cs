﻿using SleeperCell.ObjectModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SleeperCell.Context
{
    public class SleeperCellContext : DbContext
    {
        public SleeperCellContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleOrder> Sales { get; set; }
    }
}