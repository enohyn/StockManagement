using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.Model.View_Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class StockInGateway : BaseClassGateway
    {
        public List<ItemViewModel> GetAllItemCompany()
        {
            command = new SqlCommand("SELECT DISTINCT CompanyId,CompanyName FROM ItemInfo Order By CompanyName ASC", connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<ItemViewModel> itemCategoryList = new List<ItemViewModel>();
            while (reader.Read())
            {
                ItemViewModel aItem = new ItemViewModel();;
                aItem.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                aItem.CompanyName = reader["CompanyName"].ToString();
                itemCategoryList.Add(aItem);
            }
            connection.Close();
            return itemCategoryList;
        }

        public List<ItemViewModel> GetAllItemInfoByCompany(ItemViewModel addItem)
        {
            string query = "SELECT ItemId,ItemName FROM ItemInfo WHERE CompanyId=@companyId Order By ItemName ASC";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@companyId", addItem.CompanyId);
            connection.Open();
            reader = command.ExecuteReader();
            List<ItemViewModel> itemInfoList = new List<ItemViewModel>();
            while (reader.Read())
            {
                ItemViewModel aItem = new ItemViewModel();
                aItem.ItemId = Convert.ToInt32(reader["ItemId"]);
                aItem.ItemName = reader["ItemName"].ToString();
                itemInfoList.Add(aItem);
            }
            connection.Close();
            return itemInfoList;
        }

        public ItemViewModel GetReorderLevel(int itemId)
        {
            string query = "SELECT ReorderLevel FROM ItemInfo WHERE ItemId=@itemId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemId", itemId);
            connection.Open();
            reader = command.ExecuteReader();
            ItemViewModel stockItemInfo = null;
            if (reader.Read())
            {
                stockItemInfo = new ItemViewModel();
                stockItemInfo.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
            }

            connection.Close();
            return stockItemInfo;
        }
        public ItemViewModel GetAvailable(int itemId)
        {

            string query = "SELECT Quantity FROM ItemInfo WHERE ItemId=@itemId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemId", itemId);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            ItemViewModel addItem = null;
            if (reader.HasRows)
            {
                addItem = new ItemViewModel();
                addItem.AvailableQuantity = Convert.ToInt32(reader["Quantity"]);
            }
            reader.Close();
            connection.Close();

            return addItem;
        }

        public int StockIn(StockInModel stockIn)
        {
            string query = "UPDATE Item SET Quantity=@quantity WHERE Id=@itemId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@quantity", stockIn.Quantity);
            command.Parameters.AddWithValue("@itemId", stockIn.ItemId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }



    }
}