using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.BLL
{
    public class StockOutManager
    {
        StockOutGateway aStockOut=new StockOutGateway();

        public string Sell(StockOutModel aStock)
        {
            int rowAffect = aStockOut.Sell(aStock);
            if (rowAffect == 1)
            {
                return "Sell Successfull";
            }
            else
            {
                return "Sell Failed";

            }
        }

        public string Damage(StockOutModel aStock)
        {
            int rowAffect = aStockOut.Sell(aStock);
            if (rowAffect == 1)
            {
                return "Damage Successfull";
            }
            else
            {
                return "Damage Failed";

            }
        }
        public string Lost(StockOutModel aStock)
        {
            int rowAffect = aStockOut.Sell(aStock);
            if (rowAffect == 1)
            {
                return "Lost Successfull";
            }
            else
            {
                return "Lost Failed";

            }
        }

        public int UpdateQuantityFromStockOut(StockOutModel aStock)
        {
            return aStockOut.UpdateQuantityFromStockOut(aStock);
        }
    }
}