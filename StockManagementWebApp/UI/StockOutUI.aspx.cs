using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model;
using System.Drawing;
using StockManagementWebApp.DAL.Model.View_Model;

namespace StockManagementWebApp.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        private int rowCount = 0;
        StockInManager stockInManager = new StockInManager();
        ItemViewModel addItem = new ItemViewModel();
        StockOutManager stockOutManager=new StockOutManager();
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
            companyDropDownList.Items[0].Attributes["Disabled"] = "Disabled";
        }
        private void ItemListByCompany(ItemViewModel addItem)
        {

            itemNameDropDownList.DataSource = stockInManager.GetAllItemInfoByCompany(addItem);
            itemNameDropDownList.DataTextField = "ItemName";
            itemNameDropDownList.DataValueField = "ItemId";
            itemNameDropDownList.DataBind();
            itemNameDropDownList.Items.Insert(0, new ListItem("Select a Item"));
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

        public void ClearBox()
        {
            companyDropDownList.SelectedIndex = 0;
            companyDropDownList.Items[0].Attributes["Disabled"] = "Disabled";
            itemNameDropDownList.Items.Clear();
            itemNameDropDownList.Items.Insert(0, new ListItem("Select an Item"));
            itemNameDropDownList.Items[0].Attributes["Disabled"] = "Disabled";
            recorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
            stockOutQuantityTextBox.Text = "";

        }

        public void AddButton()
        {
              if (ViewState["aStockListVS"] == null)
                    {
                        StockOutModel aStockOut = new StockOutModel();
                        aStockOut.ItemId = Convert.ToInt32(itemNameDropDownList.SelectedValue);
                        aStockOut.ItemName = itemNameDropDownList.SelectedItem.Text;
                        aStockOut.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                        aStockOut.CompanyName = companyDropDownList.SelectedItem.Text;
                        aStockOut.Quantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
                        aStockOut.RemainningQuanity = Convert.ToInt32(availableQuantityTextBox.Text) -
                                                      Convert.ToInt32(stockOutQuantityTextBox.Text);
                        DateTime date = DateTime.Now;
                        aStockOut.Date = date.ToString("dd-MM-yyyy");


                        List<StockOutModel> aStockList = new List<StockOutModel>();

                        aStockList.Add(aStockOut);
                        ViewState["aStockListVS"] = aStockList;

                        allItemGridView.DataSource = aStockList;
                        rowCount = allItemGridView.Rows.Count;
                        allItemGridView.DataBind();


                        ClearBox();
                    }


                    else
                    {
                        List<StockOutModel> aStockList = (List<StockOutModel>) ViewState["aStockListVS"];

                        int itemIdExists = 0;
                        foreach (StockOutModel stockOut in aStockList)
                        {
                            int itemId = stockOut.ItemId;
                            if (itemId == Convert.ToInt32(itemNameDropDownList.SelectedValue))
                            {
                                stockOut.Quantity = stockOut.Quantity + Convert.ToInt32(stockOutQuantityTextBox.Text);
                                stockOut.RemainningQuanity = Convert.ToInt32(availableQuantityTextBox.Text) -
                                                             stockOut.Quantity;

                                itemIdExists = 1;

                            }

                        }
                        if (itemIdExists != 1)
                        {
                            StockOutModel aStockOut = new StockOutModel();
                            aStockOut.ItemId = Convert.ToInt32(itemNameDropDownList.SelectedValue);
                            aStockOut.ItemName = itemNameDropDownList.SelectedItem.Text;
                            aStockOut.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                            aStockOut.CompanyName = companyDropDownList.SelectedItem.Text;
                            aStockOut.Quantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
                            aStockOut.RemainningQuanity = Convert.ToInt32(availableQuantityTextBox.Text) -
                                                          aStockOut.Quantity;

                            DateTime date = DateTime.Now;
                            aStockOut.Date = date.ToString("dd-MM-yyyy");

                            aStockList.Add(aStockOut);
                        }
                        ViewState["aStockListVS"] = aStockList;
                        allItemGridView.DataSource = aStockList;
                        rowCount = allItemGridView.Rows.Count;
                        allItemGridView.DataBind();
                        ClearBox();
                    }

                }
               
            

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex > 0 && itemNameDropDownList.SelectedIndex > 0 &&
                stockOutQuantityTextBox.Text != "")
            {

                if (System.Text.RegularExpressions.Regex.IsMatch(stockOutQuantityTextBox.Text, "^[0-9]+$") && Convert.ToInt32(stockOutQuantityTextBox.Text) != 0)
                {

                    if (ViewState["aStockListVS"] == null)
                    {
                        int availableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                        int outQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
                        if (availableQuantity >= outQuantity)
                        {
                            AddButton();
                        }
                        else
                        {


                            ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "VaidationMsg()", true);

                        }
                    }
                    else
                    {
                        List<StockOutModel> aStockList = (List<StockOutModel>) ViewState["aStockListVS"];

                        int stockAvailableIn = 0;
                        foreach (StockOutModel aStockOut in aStockList)
                        {
                            if (aStockOut.ItemId == Convert.ToInt32(itemNameDropDownList.SelectedValue))
                            {
                                stockAvailableIn = aStockOut.Quantity;

                            }
                        }
                        int availableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                        int outQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text) + stockAvailableIn;
                        if (availableQuantity >= outQuantity)
                        {
                            AddButton();
                        }
                        else
                        {

                            ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "VaidationMsg()", true);


                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "QuanityVaidationMsg()", true);

                }


            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "emptyFieldMsg()", true);
                
            }
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            if (allItemGridView.Rows.Count>0)
            {
                List<StockOutModel> aStockList = (List<StockOutModel>)ViewState["aStockListVS"];
                foreach (StockOutModel aStock in aStockList)
                {

                    StockOutModel aStockOut = new StockOutModel();
                    aStockOut.ItemId = aStock.ItemId;
                    aStockOut.Quantity = aStock.Quantity;
                    aStockOut.Date = aStock.Date;
                    aStockOut.Type = "Sell";
                    aStockOut.RemainningQuanity = aStock.RemainningQuanity;
                    stockOutManager.UpdateQuantityFromStockOut(aStockOut);
                    string message = stockOutManager.Sell(aStockOut);
                    if (message == "Sell Successfull")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "yess!", "SuccessMsg()", true);
                        allItemGridView.DataSource = null;
                        ViewState["aStockListVS"] = null;
                        allItemGridView.DataBind();
                        ClearBox();
                    }
                }
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "ErrorMsg()", true);               
            }

        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            if (allItemGridView.Rows.Count > 0)
            {
                List<StockOutModel> aStockList = (List<StockOutModel>) ViewState["aStockListVS"];
                foreach (StockOutModel aStock in aStockList)
                {

                    StockOutModel aStockOut = new StockOutModel();
                    aStockOut.ItemId = aStock.ItemId;
                    aStockOut.Quantity = aStock.Quantity;
                    aStockOut.Date = aStock.Date;
                    aStockOut.Type = "DAMAGE";
                    aStockOut.RemainningQuanity = aStock.RemainningQuanity;
                    stockOutManager.UpdateQuantityFromStockOut(aStockOut);
                    string message = stockOutManager.Damage(aStockOut);
                    if (message == "Damage Successfull")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "yess!", "DamageMsg()", true);
                        allItemGridView.DataSource = null;
                        ViewState["aStockListVS"] = null;
                        allItemGridView.DataBind();
                        ClearBox();
                    }
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "ErrorMsg()", true);

            }
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            if (allItemGridView.Rows.Count > 0)
            {
            List<StockOutModel> aStockList = (List<StockOutModel>) ViewState["aStockListVS"];
            foreach (StockOutModel aStock in aStockList)
            {

                StockOutModel aStockOut = new StockOutModel();
                aStockOut.ItemId = aStock.ItemId;
                aStockOut.Quantity = aStock.Quantity;
                aStockOut.Date = aStock.Date;
                aStockOut.Type = "LOST";
                aStockOut.RemainningQuanity = aStock.RemainningQuanity;
                stockOutManager.UpdateQuantityFromStockOut(aStockOut);
                string message = stockOutManager.Lost(aStockOut);
                if (message == "Lost Successfull")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "yess!", "LostMsg()", true);
                    allItemGridView.DataSource = null;
                    ViewState["aStockListVS"] = null;
                    allItemGridView.DataBind();
                    ClearBox();
                }


            }
            }

             else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "ErrorMsg()", true);

            }
        }


        

        

            
            
        }
    }