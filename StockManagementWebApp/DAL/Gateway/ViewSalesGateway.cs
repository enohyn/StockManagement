using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Model.View_Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class ViewSalesGateway : BaseClassGateway
    {

        public List<ViewSalesModel> GetAllSellsByDate(ViewSalesModel viewSalesModel)
        {
            command = new SqlCommand("SELECT * FROM SellsInfo WHERE Date BETWEEN @fromDate AND @toDate ORDER BY ReorderLevel", connection);
            command.Parameters.AddWithValue("@fromDate", viewSalesModel.FromDate);
            command.Parameters.AddWithValue("@toDate", viewSalesModel.ToDate);

            connection.Open();
            reader = command.ExecuteReader();

            List<ViewSalesModel> itemList = new List<ViewSalesModel>();

            while (reader.Read())
            {
                ViewSalesModel aItem = new ViewSalesModel();
                aItem.ItemId = Convert.ToInt32(reader["ItemId"]);
                aItem.ItemName = reader["ItemName"].ToString();
                aItem.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                aItem.CompanyName = reader["CompanyName"].ToString();
                aItem.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                aItem.CategoryName = reader["CategoryName"].ToString();
                aItem.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                aItem.SellQuantity = Convert.ToInt32(reader["SellQuanity"]);

                itemList.Add(aItem);

            }
            connection.Close();
            return itemList;

        }
    }
}