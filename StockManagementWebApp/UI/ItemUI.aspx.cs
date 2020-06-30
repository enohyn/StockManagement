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
    public partial class ItemUI : System.Web.UI.Page
    {
        CategoryManager categoryManager=new CategoryManager();
        CompanyManager companyManager=new CompanyManager();

        ItemManager itemManager=new ItemManager();
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
                CategoryList();
                CompanyList();
            }
        }
        private void CategoryList()
        {
            categoryDropDownList.DataSource = categoryManager.GetAllCategory();
            categoryDropDownList.DataValueField = "Id";
            categoryDropDownList.DataTextField = "CategoryName";
            categoryDropDownList.DataBind();
            categoryDropDownList.Items.Insert(0, new ListItem("Select a Category"));
        }
        private void CompanyList()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompany();
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataBind();
            companyDropDownList.Items.Insert(0, new ListItem("Select a Company"));
        }

        public void ClearTextBox()
        {
            categoryDropDownList.SelectedIndex = 0;
            companyDropDownList.SelectedIndex = 0;
            itemNameTextBox.Text = "";
            reorderLevelTextBox.Text = "";
        }
        protected void saveItemButton_Click(object sender, EventArgs e)
        {

            if (categoryDropDownList.SelectedIndex > 0 && companyDropDownList.SelectedIndex > 0 &&
                itemNameTextBox.Text != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(itemNameTextBox.Text, "^[a-zA-Z]"))
                {

                    if (System.Text.RegularExpressions.Regex.IsMatch(reorderLevelTextBox.Text, "^[0-9]+$") ||
                        reorderLevelTextBox.Text == "")
                    {
                        int Quantity = 0;
                        int reorderLevel = 0;

                        ItemModel aAddItem = new ItemModel();
                        aAddItem.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
                        aAddItem.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                        aAddItem.ItemName = itemNameTextBox.Text;

                        if (reorderLevelTextBox.Text != "")
                        {
                            reorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                        }
                        aAddItem.ReorderLevel = reorderLevel.ToString();
                        aAddItem.Quantity = Quantity;

                        string message = itemManager.AddItem(aAddItem);
                        outputLabel.Text = aAddItem.ItemName + " " + message;
                        outputLabel.ForeColor = Color.Red;

                        if (message == "Item Added Successfully")
                        {
                            ClearTextBox();
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "VaidationMsg()", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "VaidationMsg1()", true);                    
                }



            }
            else
            {
                outputLabel.Text = "Please Select Category Name, Company Name and Enter an Item Name";
                outputLabel.ForeColor = Color.Red;

            }
            

        }
        
    }
}

















