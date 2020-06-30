using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.BLL
{
    public class CategoryManager
    {
        CategoryGateway addCategory=new CategoryGateway();
        private int rowAffect;
        public string AddCategory(CategoryModel aCategory)
        {
            if (addCategory.IsExistsCategory(aCategory.CategoryName))
            {
                return "Category Name Already Exist,Please Input Another Category";
            }
            else
            {
                rowAffect = addCategory.AddCategory(aCategory);
                if (rowAffect == 1)
                {
                    return "Category Added Succesfuly";
                }
                else
                {
                    return "Category Added Failed";
                }
            } 
        }


        public List<CategoryModel> GetAllCategory()
        {
            return addCategory.GetAllCategory();
        }

        public CategoryModel GetCategoryById(int id)
        {
           return addCategory.GetCategoryById(id);
        }

        public int UpdateCategoryById(CategoryModel aCategory)
        {
            if (addCategory.IsExistsCategory(aCategory.CategoryName))
            {
              return rowAffect=0;
            }
            else
            {
                rowAffect = addCategory.UpdateCategoryById(aCategory);
                return rowAffect;
            }

            
        }
    }
}