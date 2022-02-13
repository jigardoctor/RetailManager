﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.Models
{
   public class ProductModel
    {
        //Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxable
        public int id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
        public int QuantityInStock { get; set; }
        public bool IsTaxable { get; set; }
    }
}
