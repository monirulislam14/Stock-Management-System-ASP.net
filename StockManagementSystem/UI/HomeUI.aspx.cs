using StockManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystem.UI
{
    public partial class HomeUI : System.Web.UI.Page
    {

        ItemManager itemManager = new ItemManager();
        StockOutManager stockOutManager = new StockOutManager();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                   
                        GetAndBindWithDataGrid();
                        LoadAllQuantitiesAndShow();
                       
                  
                
            }
        }

        public void GetAndBindWithDataGrid()
        {
            itemGridView.DataSource = itemManager.GetItem();
            itemGridView.DataBind();

            soldItemGridView.DataSource = stockOutManager.GetAllSoldItems();
            soldItemGridView.DataBind();
        }

        public void LoadAllQuantitiesAndShow()
        {
            totalItemLabel.Text = itemManager.GetTotalItems().ToString();
            totalStockInLabel.Text = itemManager.GetTotalStockInQuantity().ToString();
            totalStockOutLabel.Text = stockOutManager.GetTotalStockOutQuantity().ToString();
            totalSoldLabel.Text = stockOutManager.GetTotalSoldItems().ToString();
        }

       
    }
}