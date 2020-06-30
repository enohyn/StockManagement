using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;

namespace StockManagementWebApp.UI
{
    public partial class SearchAndViewItemUI : System.Web.UI.Page
    {
        SearchAndViewManager searchAndViewManager=new SearchAndViewManager();
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
                AllItemCompanyList();
                AllItemCategoryList();
            }
        }

        private void AllItemCompanyList()
        {
            
            companyNameDropDownList.DataSource = searchAndViewManager.GetAllItemCompany();
            companyNameDropDownList.DataTextField = "CompanyName";
            companyNameDropDownList.DataValueField = "CompanyId";           
            companyNameDropDownList.DataBind();
            companyNameDropDownList.Items.Insert(0, new ListItem("Select a Company"));
            
        }
        private void AllItemCategoryList()
        {

            CategoryNameDropDownList.DataSource = searchAndViewManager.GetAllItemCategory();
            CategoryNameDropDownList.DataTextField = "CategoryName";
            CategoryNameDropDownList.DataValueField = "CategoryId";
            CategoryNameDropDownList.DataBind();
            CategoryNameDropDownList.Items.Insert(0, new ListItem("Select a Category"));

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (companyNameDropDownList.SelectedIndex>0 && CategoryNameDropDownList.SelectedIndex>0)
            {
                allItemGridView.DataSource =
                    searchAndViewManager.GetAllItemByCompanyAndCategory(
                        Convert.ToInt32(companyNameDropDownList.SelectedValue),
                        Convert.ToInt32(CategoryNameDropDownList.SelectedValue));
                allItemGridView.DataBind();
            }
            else if (companyNameDropDownList.SelectedIndex > 0)
            {
                allItemGridView.DataSource =
                  searchAndViewManager.GetAllItemByCompany(Convert.ToInt32(companyNameDropDownList.SelectedValue));
                allItemGridView.DataBind(); 
            }
            else if (CategoryNameDropDownList.SelectedIndex > 0)
            {
                allItemGridView.DataSource =
                    searchAndViewManager.GetAllItemByCategory(Convert.ToInt32(CategoryNameDropDownList.SelectedValue));
                allItemGridView.DataBind();
            }
            else
            {
                allItemGridView.DataSource = searchAndViewManager.GetAllItem();
                allItemGridView.DataBind();  
            }
        }
    }
}