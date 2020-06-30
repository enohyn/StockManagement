using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class CategoryGateway :BaseClassGateway
    {

       
        public int AddCategory(CategoryModel aCategory)
        {
            string query = "INSERT INTO Category(CategoryName) VALUES(@categoryName) ";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@categoryName", aCategory.CategoryName);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return  rowAffect;
        }

        public bool IsExistsCategory(string aCategoryName)
        {
            string query = "SELECT * FROM Category WHERE CategoryName=@acategoryName";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@acategoryName", aCategoryName);
            connection.Open();
            reader = command.ExecuteReader();
            bool hasRows = reader.HasRows;
            connection.Close();
            return hasRows;
        }



        public List<CategoryModel> GetAllCategory()
        {
            command = new SqlCommand("SELECT * FROM Category Order By CategoryName ASC", connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<CategoryModel> categoryList=new List<CategoryModel>();

            while (reader.Read())
            {
                CategoryModel aCategory=new CategoryModel();
                aCategory.Id = Convert.ToInt32(reader["Id"]);
                aCategory.CategoryName = reader["CategoryName"].ToString();

                categoryList.Add(aCategory);

            }
            connection.Close();
            return categoryList;

        }

        public CategoryModel GetCategoryById(int id)
        {
            command = new SqlCommand("SELECT * FROM Category Where Id=@categoryId", connection);
            command.Parameters.AddWithValue("@categoryId", id);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            CategoryModel aCategory = null;
            if(reader.HasRows)
            {
                aCategory=new CategoryModel();
                aCategory.Id = Convert.ToInt32(reader["Id"]);
                aCategory.CategoryName = reader["CategoryName"].ToString();


            }
            connection.Close();
            return aCategory;

        }

        public int UpdateCategoryById(CategoryModel aCategory)
        {
            command = new SqlCommand("UPDATE Category SET CategoryName=@categoryName WHERE Id=@id", connection);
            command.Parameters.AddWithValue("@categoryName", aCategory.CategoryName);
            command.Parameters.AddWithValue("@id", aCategory.Id);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

    }
}