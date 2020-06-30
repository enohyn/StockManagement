using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.UI
{
    public partial class UpdateCategoryUI : System.Web.UI.Page
    {
        CategoryManager categoryManager=new CategoryManager();
        private CategoryModel aCategoryName;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] != null)
            {
                userEmailLabel.Text = Session["Email"].ToString();

            }
            else
            {
                Response.Redirect("LoginUI.aspx");
            }


            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Category Id"]);

                aCategoryName = categoryManager.GetCategoryById(id);

                if (aCategoryName != null)
                {
                    
                    updateCategoryNameTextBox.Text = aCategoryName.CategoryName;
                }
            }
        }

        protected void updateCategoryButton_Click(object sender, EventArgs e)
        {
            if (updateCategoryNameTextBox.Text != "")
            {
                aCategoryName = new CategoryModel();
                aCategoryName.CategoryName = updateCategoryNameTextBox.Text;
                aCategoryName.Id = Convert.ToInt32(Request.QueryString["Category Id"]);

                int rowAffect = categoryManager.UpdateCategoryById(aCategoryName);
                if (rowAffect == 1)
                {
                    Response.Redirect("CategoryUi.aspx");

                }
                else
                {
                    outputLabel.Text = "Your Updating Category is already Exist,Please Input Another Category Name";
                    outputLabel.ForeColor = Color.Red;
                }
            }
            else
            {
                outputLabel.Text = "Empty Category Cann't allow to Update";
                outputLabel.ForeColor = Color.Red;

            }
        }
    }
}