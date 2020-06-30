using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model.View_Model;

namespace StockManagementWebApp.BLL
{
    public class ViewSalesManager
    {
        ViewSalesGateway viewSalesGateway=new ViewSalesGateway();
        public List<ViewSalesModel> GetAllSellsByDate(ViewSalesModel viewSalesModel)
        {
            return viewSalesGateway.GetAllSellsByDate(viewSalesModel);
        }
    }
}