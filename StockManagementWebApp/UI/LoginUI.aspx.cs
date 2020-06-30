using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.UI
{
    public partial class LoginUi : System.Web.UI.Page
    {
        LoginManager loginManager=new LoginManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] != null)
            {
                Response.Redirect("HomeUI.aspx");
            }
            
      
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (emailTextBox.Text != "" && passwordTextBox.Text != "")
            {
                LoginModel aLoginUser = new LoginModel();
                aLoginUser.Email = emailTextBox.Text;
                aLoginUser.Password = passwordTextBox.Text;
                int rowAffect = loginManager.Login(aLoginUser);

                if (rowAffect == 1)
                {
                    Session["Email"] = aLoginUser.Email;
                    Response.Redirect("HomeUI.aspx");
                }
                else
                {
                    outputLabel.Text = "Your Email and Password is Incorrect";
                }
            }
            else
            {
                outputLabel.Text = "Please Input Your Email and Password";
                
            }
        }


    }
}