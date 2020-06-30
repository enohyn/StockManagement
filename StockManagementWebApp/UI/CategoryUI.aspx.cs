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
    public partial class CategoryUi : System.Web.UI.Page
    {

        CategoryManager addCategory=new CategoryManager();
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


            allCategoryGridView.DataSource = addCategory.GetAllCategory();
            allCategoryGridView.DataBind();
        }

        protected void addCategoryButton_Click(object sender, EventArgs e)
        {
            if (addCategoryNameTextBox.Text != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(addCategoryNameTextBox.Text, "^[a-zA-Z]"))
                {
                    CategoryModel aCategory = new CategoryModel();
                    DateTime date = DateTime.Now;
                    aCategory.CategoryName = addCategoryNameTextBox.Text;
                    aCategory.DateTime = date.ToString("dd-MM-yy");

                    string message = addCategory.AddCategory(aCategory);
                    outputLabel.Text = message;
                    outputLabel.ForeColor = Color.Red;
                    addCategoryNameTextBox.Text = "";

                    allCategoryGridView.DataSource = addCategory.GetAllCategory();
                    allCategoryGridView.DataBind();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "VaidationMsg()", true);                    
                    
                }
            }
            else
            {
                outputLabel.Text = "Please Input a Category Name";
                outputLabel.ForeColor = Color.Red;
            }
           
        }

        protected void updateCategoryLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            DataControlFieldCell cell = linkButton.Parent as DataControlFieldCell;
            GridViewRow row = cell.Parent as GridViewRow;
            HiddenField hiddenField = row.FindControl("idHiddenField") as HiddenField;
            int id = Convert.ToInt32(hiddenField.Value);
            Response.Redirect("UpdateCategoryUI.aspx?Category Id=" + id);
        }
    }
}