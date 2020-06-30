using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.UI
{
    public partial class AdminSignUpUI : System.Web.UI.Page
    {
        LoginManager manager= new LoginManager();
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

        }

        protected void signUpButton_Click(object sender, EventArgs e)
        {

            if (nameTextBox.Text != "" && emailTextBox.Text != "" && passwordTextBox.Text != "" &&
                signatureTextBox.Text != "")
            {
                LoginModel aSignUp = new LoginModel();
                aSignUp.Name = nameTextBox.Text;
                aSignUp.Email = emailTextBox.Text;
                aSignUp.Password = passwordTextBox.Text;
                aSignUp.Signature = signatureTextBox.Text;
                string message = manager.SignUp(aSignUp);
                outputLabel.Text = message;
                outputLabel.ForeColor = Color.Red;

                nameTextBox.Text = "";
                emailTextBox.Text = "";
                passwordTextBox.Text = "";
                signatureTextBox.Text = "";
            }
            else
            {
                outputLabel.Text = "Please Input All Field" ;
                
            }

        }
    }
}