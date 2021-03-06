﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.DAL.Model.View_Model
{
    public class ItemViewModel
    {

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuantity { get; set; }


    }
}