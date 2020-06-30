using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.Model.View_Model;

namespace StockManagementWebApp.BLL
{
    public class ItemManager
    {

        ItemGateway addItem=new ItemGateway();
        public string AddItem(ItemModel aAddItem)
        {
            if (addItem.IsExistsItem(aAddItem))
            {
                return "Item Name Already Exist,Please Input Another Company";
            }
            else
            {
                int rowAffect= addItem.AddItem(aAddItem);
                if (rowAffect == 1)
                {
                    return "Item Added Successfully";
                }
                else
                {
                    return "Item Added Successfully";                    
                }
                
            }
        }


    }
}