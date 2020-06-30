using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.BLL
{
    public class LoginManager
    {
        LoginGateway loginUserGateway=new LoginGateway();
        int rowAffect = 0;
        public int Login(LoginModel loginUser)
        {
            
            if (loginUserGateway.Login(loginUser.Email,loginUser.Password))
            {
                rowAffect = 1;
            }
            else
            {
                rowAffect = 2;
            }
            return rowAffect;

        }

        public string SignUp(LoginModel signUp)
        {
            rowAffect = loginUserGateway.SignUp(signUp);
            if (rowAffect == 1)
            {
                return "New Admin Id Created Successfully";
            }
            else
            {
                return "Something is Wrong,Login failed";
                
            }
        }

        public string UpdateName(LoginModel aUser)
        {
            rowAffect = loginUserGateway.UpdateName(aUser);
            if (rowAffect == 1)
            {
                return "Your Name Update Successfully";
            }
            else
            {
                return "Something is Wrong,Update failed";

            }
        }

        public LoginModel GetAdmin(string email)
        {
            return loginUserGateway.GetAdmin(email);
        }
    }
}