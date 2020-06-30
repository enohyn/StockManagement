using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.UI
{
    public partial class AdminProfileUI : System.Web.UI.Page
    {

        LoginManager manager=new LoginManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            string email =(String) Session["Email"];
            if (email != null)
            {
                userEmailLabel.Text = email;

            }
            else
            {
                Response.Redirect("LoginUI.aspx");
            }

            if (!IsPostBack)
            {
                LoginModel aAdmin = manager.GetAdmin(email);
                if (aAdmin != null)
                {
                    nameTextBox.Text = aAdmin.Name;
                    emailTextBox.Text = aAdmin.Email;
                    passwordTextBox.Text = aAdmin.Password;
                    signatureTextBox.Text = aAdmin.Signature;
                }
            }



        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text!="" && passwordTextBox.Text!="")
            {
                 LoginModel update=new LoginModel();
            update.Name = nameTextBox.Text;
            update.Email = emailTextBox.Text;
            update.Password = passwordTextBox.Text;
            string message = manager.UpdateName(update);

            outputLabel.Text = message;
            }
            else
            {
                outputLabel.Text = "Null Can't Be Insert";

            }
        }
    }
}