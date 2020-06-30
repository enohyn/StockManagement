using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class LoginGateway : BaseClassGateway
    {
        public bool Login(string emailUser,string passwordUser)
        {
            string query = "select * from Admin where Email=@email AND Password=@password";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", emailUser);
            command.Parameters.AddWithValue("@password", passwordUser);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();
            return isExists;     
        }

        public int SignUp(LoginModel signUp)
        {
            string query = "INSERT INTO Admin(Name,Email,Password,Signature) VALUES(@name,@email,@password,@signature)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", signUp.Name);
            command.Parameters.AddWithValue("@email", signUp.Email);
            command.Parameters.AddWithValue("@password", signUp.Password);
            command.Parameters.AddWithValue("@signature", signUp.Signature);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public int UpdateName(LoginModel aUser)
        {
            string query = "UPDATE Admin SET Name=@nameOfUser,Password=@password WHERE Email=@email";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nameOfUser", aUser.Name);
            command.Parameters.AddWithValue("@password", aUser.Password);
            command.Parameters.AddWithValue("@email", aUser.Email);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public LoginModel GetAdmin(string email)
        {
            string query = "select * from Admin where Email=@aemail";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@aemail", email);
            connection.Open();
            reader = command.ExecuteReader();
            LoginModel aUser=null;
            if (reader.Read())
            {
                aUser =new LoginModel();
                aUser.Name = reader["Name"].ToString();
                aUser.Email = reader["Email"].ToString();
                aUser.Password = reader["Password"].ToString();
                aUser.Signature = reader["Signature"].ToString();
                
            }
            connection.Close();
            return aUser;
            
        }
    }
}