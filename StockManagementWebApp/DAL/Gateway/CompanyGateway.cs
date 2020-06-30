using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class CompanyGateway : BaseClassGateway
    {


        public int AddCompany(CompanyModel aCompany)
        {
            string query = "INSERT INTO Company(CompanyName) VALUES(@companyName)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@companyName", aCompany.CompanyName);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsExistsCompany(string aCompanyName)
        {
            string query = "SELECT * FROM Company WHERE CompanyName=@CompanyName";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyName", aCompanyName);
            connection.Open();
            reader = command.ExecuteReader();
            bool hasRows = reader.HasRows;
            connection.Close();
            return hasRows;
        }

        public List<CompanyModel> GetAllCompany()
        {
            command = new SqlCommand("SELECT * FROM Company Order By CompanyName ASC", connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<CompanyModel> companyList = new List<CompanyModel>();

            while (reader.Read())
            {
                CompanyModel aCompany = new CompanyModel();
                aCompany.Id = Convert.ToInt32(reader["Id"]);
                aCompany.CompanyName = reader["CompanyName"].ToString();
                companyList.Add(aCompany);

            }
            connection.Close();
            return companyList;

        }
    }
}