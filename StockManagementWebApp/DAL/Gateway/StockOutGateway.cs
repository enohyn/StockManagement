using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class StockOutGateway : BaseClassGateway
    {
        public int Sell(StockOutModel aStockOut)
        {
            string query = "INSERT INTO StockOut(ItemId,Quantity,Type,Date) VALUES(@itemId,@quantity,@type,@datee)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemId", aStockOut.ItemId);
            command.Parameters.AddWithValue("@quantity", aStockOut.Quantity);
            command.Parameters.AddWithValue("@type", aStockOut.Type);
            command.Parameters.AddWithValue("@datee", aStockOut.Date);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public int Damage(StockOutModel aStockOut)
        {
            
            string query = "INSERT INTO StockOut(ItemId,Quantity,Type,Date) VALUES(@itemId,@quantity,@type,@datee)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemId", aStockOut.ItemId);
            command.Parameters.AddWithValue("@quantity", aStockOut.Quantity);
            command.Parameters.AddWithValue("@type", aStockOut.Type);
            command.Parameters.AddWithValue("@datee", aStockOut.Date);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public int Lost(StockOutModel aStockOut)
        {
            string query = "INSERT INTO StockOut(ItemId,Quantity,Type,Date) VALUES(@itemId,@quantity,@type,@datee)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemId", aStockOut.ItemId);
            command.Parameters.AddWithValue("@quantity", aStockOut.Quantity);
            command.Parameters.AddWithValue("@type", aStockOut.Type);
            command.Parameters.AddWithValue("@datee", aStockOut.Date);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public int UpdateQuantityFromStockOut(StockOutModel aStockOut)
        {
            string query = "UPDATE Item SET Quantity=@RemainningQuanity WHERE Id=@itemId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@RemainningQuanity", aStockOut.RemainningQuanity);
            command.Parameters.AddWithValue("@itemId", aStockOut.ItemId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }



    }
}