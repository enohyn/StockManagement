using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.DAL.Model
{
        [Serializable]
    public class StockOutModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int Quantity { get; set; }
        public int RemainningQuanity { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }


    }
}