using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.BLL
{
    public class CompanyManager
    {
        CompanyGateway addCompany=new CompanyGateway();
        public string AddCompany(CompanyModel aCompany)
        {
            if (addCompany.IsExistsCompany(aCompany.CompanyName))
            {
                return "Company Name Already Exist,Please Input Another Company";
            }
            else
            {
                int rowAffect = addCompany.AddCompany(aCompany);
                if (rowAffect == 1)
                {
                    return "Company Added Succesfuly";
                }
                else
                {
                    return "Company Added Failed";
                }
            }
        }


        public List<CompanyModel> GetAllCompany()
        {
            return addCompany.GetAllCompany();
        } 

    }
}