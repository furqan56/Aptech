using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SleeperCell.Context;
using SleeperCell.Models;
using SleeperCell.ObjectModel;

namespace SleeperCell.Handlers
{
    public class ProductStockRepository
    {
        private SleeperCellContext _context;
        public static int ProductId { get; private set; } = 1;


        public ProductStockRepository()
        {
            _context = new SleeperCellContext();
        }

        
    }
}