using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.Model.View_Model;

namespace StockManagementWebApp.BLL
{
    public class StockInManager
    {
        StockInGateway stockIn=new StockInGateway();

        public List<ItemViewModel> GetAllItemCompany()
        {
            return stockIn.GetAllItemCompany();
        }

        public List<ItemViewModel> GetAllItemInfoByCompany(ItemViewModel addItem)
        {
            return stockIn.GetAllItemInfoByCompany(addItem);
        }

        public ItemViewModel GetReorderLevel(int itemId)
        {
            return stockIn.GetReorderLevel(itemId);
        }

        public ItemViewModel GetAvailableQuantity(int itemId)
        {
            return stockIn.GetAvailable(itemId);
        }

        public string StockIn(StockInModel aStockIn)
        {
            int rowAffect = stockIn.StockIn(aStockIn);
            if (rowAffect == 1)
            {
                return "Stock In Successfull";
            }
            else
            {
                return "Stock In Failed";                
            }
        }

    }
}