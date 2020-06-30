using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.Model.View_Model;

namespace StockManagementWebApp.UI
{
    public partial class StockInUI : System.Web.UI.Page
    {

        StockInManager stockInManager=new StockInManager();
        ItemViewModel addItem=new ItemViewModel();

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
                ItemListByCompany(addItem);
            }    
        }

        private void AllItemCompanyList()
        {
            companyDropDownList.DataSource = stockInManager.GetAllItemCompany();
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataValueField = "CompanyId";
            companyDropDownList.DataBind();
            companyDropDownList.Items.Insert(0, new ListItem("Select a Company"));
            companyDropDownList.Items[0].Attributes["Disabled"]="Disabled";
        }
        private void ItemListByCompany(ItemViewModel addItem)
        {

            itemNameDropDownList.DataSource = stockInManager.GetAllItemInfoByCompany(addItem);
            itemNameDropDownList.DataTextField = "ItemName";
            itemNameDropDownList.DataValueField = "ItemId";
            itemNameDropDownList.DataBind();
            itemNameDropDownList.Items.Insert(0, new ListItem("Select an Item"));
            itemNameDropDownList.Items[0].Attributes["Disabled"] = "Disabled";

        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            addItem.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            ItemListByCompany(addItem);
            companyDropDownList.Items[0].Attributes["Disabled"] = "Disabled";
            itemNameDropDownList.Items[0].Attributes["Disabled"] = "Disabled";
            recorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
        }

        protected void itemNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            companyDropDownList.Items[0].Attributes["Disabled"] = "Disabled";
            itemNameDropDownList.Items[0].Attributes["Disabled"] = "Disabled";
            GetReorderLevel();
            GetAvailableQuantity();
        }

        public void GetReorderLevel()
        {           
             addItem = stockInManager.GetReorderLevel(Convert.ToInt32(itemNameDropDownList.SelectedValue));
             recorderLevelTextBox.Text = addItem.ReorderLevel.ToString();           
        }

        public void GetAvailableQuantity()
        {
            addItem = stockInManager.GetAvailableQuantity(Convert.ToInt32(itemNameDropDownList.SelectedValue));
            availableQuantityTextBox.Text = addItem.AvailableQuantity.ToString();
        }
        protected void stockInButton_Click(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex > 0 && itemNameDropDownList.SelectedIndex > 0 &&
                stockInQuantityTextBox.Text != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(stockInQuantityTextBox.Text, "^[0-9]+$") && Convert.ToInt32(stockInQuantityTextBox.Text)!=0)
                {
                    int availableQuantity, stockInQuantity;
                    StockInModel aStockIn = new StockInModel();
                    aStockIn.ItemId = Convert.ToInt32(itemNameDropDownList.SelectedValue);
                    availableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                    stockInQuantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                    aStockIn.Quantity = availableQuantity + stockInQuantity;

                    string message = stockInManager.StockIn(aStockIn);

                    //outputLabel.Text = stockInQuantity + " Quantity " + " " + message + " " + " in " +
                    //                   itemNameDropDownList.SelectedItem + " Item";
                    ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "SuccessMsg()", true);                    

                    if (message == "Stock In Successfull")
                    {
                        companyDropDownList.SelectedIndex = 0;
                        itemNameDropDownList.Items.Clear();
                        itemNameDropDownList.Items.Insert(0, new ListItem("Select an Item"));
                        itemNameDropDownList.Items[0].Attributes["Disabled"] = "Disabled";
                        recorderLevelTextBox.Text = "";
                        availableQuantityTextBox.Text = "";
                        stockInQuantityTextBox.Text = "";
                    }

                    outputLabel.ForeColor = Color.Red;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "VaidationMsg()", true);                    
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "VaidationMsg1()", true);                    

                //outputLabel.Text = "Please Select a Company, an Item and Input Stock Out Quanity";
            }
            
        }



    }
}