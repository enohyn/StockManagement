using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.Model.View_Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class SearchAndViewGateway :BaseClassGateway
    {


        public List<ItemViewModel> GetAllItemCompany()
        {
            command = new SqlCommand("SELECT DISTINCT CompanyId,CompanyName FROM ItemInfo", connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<ItemViewModel> itemCompanyList = new List<ItemViewModel>();
            while (reader.Read())
            {
                ItemViewModel aItem = new ItemViewModel(); ;
                aItem.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                aItem.CompanyName = reader["CompanyName"].ToString();
                itemCompanyList.Add(aItem);
            }
            connection.Close();
            return itemCompanyList;
        }
        public List<ItemViewModel> GetAllItemCategory()
        {
            command = new SqlCommand("SELECT DISTINCT CategoryId,CategoryName FROM ItemInfo", connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<ItemViewModel> itemCategoryList = new List<ItemViewModel>();
            while (reader.Read())
            {
                ItemViewModel aItem = new ItemViewModel(); ;
                aItem.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                aItem.CategoryName = reader["CategoryName"].ToString();
                itemCategoryList.Add(aItem);
            }
            connection.Close();
            return itemCategoryList;
        }

        public List<ItemViewModel> GetAllItem()
        {
            command = new SqlCommand("SELECT * FROM ItemInfo ORDER BY ReorderLevel", connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<ItemViewModel> itemList = new List<ItemViewModel>();

            while (reader.Read())
            {
                ItemViewModel aItem = new ItemViewModel();
                aItem.ItemId = Convert.ToInt32(reader["ItemId"]);
                aItem.ItemName = reader["ItemName"].ToString();
                aItem.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                aItem.CompanyName = reader["CompanyName"].ToString();
                aItem.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                aItem.CategoryName = reader["CategoryName"].ToString();
                aItem.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                aItem.AvailableQuantity = Convert.ToInt32(reader["Quantity"]);

                itemList.Add(aItem);

            }
            connection.Close();
            return itemList;

        }
        public List<ItemViewModel> GetAllItemByCompany(int companyId)
        {
            command = new SqlCommand("SELECT * FROM ItemInfo WHERE CompanyId=@companyId ORDER BY ReorderLevel", connection);
            command.Parameters.AddWithValue("@companyId", companyId);
            connection.Open();
            reader = command.ExecuteReader();

            List<ItemViewModel> itemList = new List<ItemViewModel>();

            while (reader.Read())
            {
                ItemViewModel aItem = new ItemViewModel();
                aItem.ItemId = Convert.ToInt32(reader["ItemId"]);
                aItem.ItemName = reader["ItemName"].ToString();
                aItem.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                aItem.CompanyName = reader["CompanyName"].ToString();
                aItem.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                aItem.CategoryName = reader["CategoryName"].ToString();
                aItem.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                aItem.AvailableQuantity = Convert.ToInt32(reader["Quantity"]);

                itemList.Add(aItem);

            }
            connection.Close();
            return itemList;

        }

        public List<ItemViewModel> GetAllItemByCategory(int categoryId)
        {
            command = new SqlCommand("SELECT * FROM ItemInfo WHERE CategoryId=@categoryId ORDER BY ReorderLevel", connection);
            command.Parameters.AddWithValue("@categoryId", categoryId);
            connection.Open();
            reader = command.ExecuteReader();

            List<ItemViewModel> itemList = new List<ItemViewModel>();

            while (reader.Read())
            {
                ItemViewModel aItem = new ItemViewModel();
                aItem.ItemId = Convert.ToInt32(reader["ItemId"]);
                aItem.ItemName = reader["ItemName"].ToString();
                aItem.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                aItem.CompanyName = reader["CompanyName"].ToString();
                aItem.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                aItem.CategoryName = reader["CategoryName"].ToString();
                aItem.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                aItem.AvailableQuantity = Convert.ToInt32(reader["Quantity"]);

                itemList.Add(aItem);

            }
            connection.Close();
            return itemList;

        }
        public List<ItemViewModel> GetAllItemByCompanyAndCategory(int companyId,int categoryId)
        {
            command = new SqlCommand("SELECT * FROM ItemInfo WHERE CompanyId=@companyId AND CategoryId=@categoryId ORDER BY ReorderLevel", connection);
            command.Parameters.AddWithValue("@categoryId", categoryId);
            command.Parameters.AddWithValue("@companyId", companyId);

            connection.Open();
            reader = command.ExecuteReader();

            List<ItemViewModel> itemList = new List<ItemViewModel>();

            while (reader.Read())
            {
                ItemViewModel aItem = new ItemViewModel();
                aItem.ItemId = Convert.ToInt32(reader["ItemId"]);
                aItem.ItemName = reader["ItemName"].ToString();
                aItem.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                aItem.CompanyName = reader["CompanyName"].ToString();
                aItem.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                aItem.CategoryName = reader["CategoryName"].ToString();
                aItem.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                aItem.AvailableQuantity = Convert.ToInt32(reader["Quantity"]);

                itemList.Add(aItem);

            }
            connection.Close();
            return itemList;

        }

    }
}