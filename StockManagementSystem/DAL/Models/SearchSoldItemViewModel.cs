﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Models
{
    public class SearchSoldItemViewModel
    {
        public int Sl { get; set; }
        public string ItemName { get; set; }
     
        public int Quantity { get; set; }
    }
}