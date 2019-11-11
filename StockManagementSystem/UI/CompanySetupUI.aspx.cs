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
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            
                        ////retrive data when form starts and bind it with dataGridView
                        BindDataWithGridView();
                  
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Company company = new Company();

            company.CompanyName = companyNameTextBox.Text;

            // check if textbox is empty or not
            if (company.CompanyName.Equals(""))
            {
                errormessageLabel.Text = "Enter company Name";
                outputMessageLabel.Text = string.Empty;
            }
            else
            {
                // save company name
                outputMessageLabel.Text = companyManager.Save(company);

                // refresh gridview
                BindDataWithGridView();

                // textbox empty
                companyNameTextBox.Text = "";
                // empty error message of textbox
                errormessageLabel.Text = "";
            }
        }

        // binds data with grid view
        public void BindDataWithGridView()
        {
            companyGridView.DataSource = companyManager.GetAllCompany();
            companyGridView.DataBind();
        }


    }
}