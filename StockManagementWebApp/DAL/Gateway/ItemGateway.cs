using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.Model.View_Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class ItemGateway : BaseClassGateway
    {

        public int AddItem(ItemModel aAddItem)
        {
            string query = "INSERT INTO Item(CategoryId,CompanyId,ItemName,ReorderLevel,Quantity) VALUES(@categoryId,@companyId,@itemName,@reorderLevel,@quantity)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@categoryId", aAddItem.CategoryId);
            command.Parameters.AddWithValue("@companyId", aAddItem.CompanyId);
            command.Parameters.AddWithValue("@itemName", aAddItem.ItemName);
            command.Parameters.AddWithValue("@reorderLevel", aAddItem.ReorderLevel);
            command.Parameters.AddWithValue("@quantity", aAddItem.Quantity);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsExistsItem(ItemModel aAddItem)
        {
            string query = "SELECT * FROM ItemInfo WHERE CategoryId=@categoryId AND CompanyId=@companyId AND ItemName=@itemName";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@categoryId", aAddItem.CategoryId);
            command.Parameters.AddWithValue("@companyId", aAddItem.CompanyId);
            command.Parameters.AddWithValue("@itemName", aAddItem.ItemName);


            connection.Open();
            reader = command.ExecuteReader();
            bool hasRows = reader.HasRows;
            connection.Close();
            return hasRows;
        }

        
    }
}