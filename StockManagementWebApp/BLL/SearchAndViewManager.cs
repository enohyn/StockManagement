using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model.View_Model;

namespace StockManagementWebApp.BLL
{
    public class SearchAndViewManager
    {
        SearchAndViewGateway searchAndView=new SearchAndViewGateway();

        public List<ItemViewModel> GetAllItemCompany()
        {
            return searchAndView.GetAllItemCompany();
        }
        public List<ItemViewModel> GetAllItemCategory()
        {
            return searchAndView.GetAllItemCategory();
        }

        public List<ItemViewModel> GetAllItem()
        {
            return searchAndView.GetAllItem();
        }
        public List<ItemViewModel> GetAllItemByCompany(int companyId)
        {
            return searchAndView.GetAllItemByCompany(companyId);
        }
        public List<ItemViewModel> GetAllItemByCategory(int categoryId)
        {
            return searchAndView.GetAllItemByCategory(categoryId);
        }

        public List<ItemViewModel> GetAllItemByCompanyAndCategory(int companyId, int categoryId)
        {
            return searchAndView.GetAllItemByCompanyAndCategory(companyId, categoryId);
        }
    }
}