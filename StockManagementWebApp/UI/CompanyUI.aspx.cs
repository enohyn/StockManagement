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
    public partial class CompanyUI : System.Web.UI.Page
    {

        CompanyManager addCompany=new CompanyManager();
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


            allCompanyGridView.DataSource = addCompany.GetAllCompany();
            allCompanyGridView.DataBind();

        }

        protected void addCategoryButton_Click(object sender, EventArgs e)
        {
            if (addCompanyNameTextBox.Text != "")
            {
                if(System.Text.RegularExpressions.Regex.IsMatch(addCompanyNameTextBox.Text, "\\D"))
                {
                    CompanyModel aCompany = new CompanyModel();
                    DateTime date = DateTime.Now;
                    aCompany.CompanyName = addCompanyNameTextBox.Text;
                    aCompany.DateTime = date.ToString("dd-MM-yy");

                    string message = addCompany.AddCompany(aCompany);
                    outputLabel.Text = message;
                    outputLabel.ForeColor = Color.Red;
                    addCompanyNameTextBox.Text = "";

                    allCompanyGridView.DataSource = addCompany.GetAllCompany();
                    allCompanyGridView.DataBind();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Oops!", "VaidationMsg()", true);
                    
                }
            }
            else
            {
                outputLabel.Text = "Please Input a Company Name";
                outputLabel.ForeColor = Color.Red;
            }
        }
    }
}