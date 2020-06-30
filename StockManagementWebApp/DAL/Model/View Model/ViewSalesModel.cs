using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.DAL.Model.View_Model
{
    public class ViewSalesModel
    {

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int ReorderLevel { get; set; }
        public int Quantity { get; set; }
        public int SellQuantity { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }


    }
}