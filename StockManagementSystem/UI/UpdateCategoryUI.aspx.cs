using StockManagementSystem.BLL;
using StockManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystem.UI
{
    public partial class UpdateCategoryUI : System.Web.UI.Page
    {
        CategoryManager categoryManager = new CategoryManager();
        Category category;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                        int categoryId = Convert.ToInt32(Request.QueryString["Id"]);

                        // load CategoryName by Id
                        category = categoryManager.GetCategoryById(categoryId);

                        // set CategoryName on textBox
                        SetNameOnTextBox();
                  
                

            }

        }

        private void SetNameOnTextBox()
        {
            categoryNameTextBox.Text = category.CategoryName;
        }

        protected void updateButton_OnClick(object sender, EventArgs e)
        {
            if (categoryNameTextBox.Text.Equals(""))
            {
                //set the error message for empty textBox
                errorLabel.Text = "Enter the category name";
                messageLabel.Text = "";
            }
            else
            {
                // update category
                Category category = new Category();

                category.Id = Convert.ToInt32(Request.QueryString["Id"]);
                category.CategoryName = categoryNameTextBox.Text;

                string message = categoryManager.UpdateCategoryNameById(category);
                // check if update success
                if (message.Equals("Success"))
                {
                    // go to category setup page
                    Response.Redirect("CategorySetupUI.aspx?Id=" + Request.QueryString["UserId"]);
                }
                else if (message.Equals("Failed"))
                {
                    messageLabel.Text = "Failed to Update";
                }
                else
                {
                    // if category name already exists
                    messageLabel.Text = message;
                }

                // empty the texbox error message
                errorLabel.Text = "";
            }
        }
    }
}