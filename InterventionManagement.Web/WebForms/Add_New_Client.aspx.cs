using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Add_New_Client : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dropList_District.DataSource = new List<string> { "Spot A", "Banlands B", "Middle o Nowhere C", "Neverland D" };
                dropList_District.DataBind();
            }
              
        }

        protected void btn_CreateClient_Click(object sender, EventArgs e)
        {
            bool validName = !String.IsNullOrWhiteSpace(txt_Name.Text);

            if (validName)
            {
                string message = "New Client Created. Name = " + txt_Name.Text + " District = " + dropList_District.SelectedItem.Text;
                Response.Write("<script>alert('" + message + "')</script>");
            }
            else
            {
                string message = "Error: Invalid Input into fields";
                Response.Write("<script>alert('" + message + "')</script>");
            }
        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            string message = "Cancelled.. Redirecting to previous page";
            Response.Write("<script>alert('" + message + "')</script>");
        }
    }
}