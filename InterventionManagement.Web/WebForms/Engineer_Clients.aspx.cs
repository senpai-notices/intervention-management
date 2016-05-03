using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Engineer_Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Engineer"))
            {
                if (!IsPostBack)
                {
                    string username = User.Identity.Name;

                    // set the controls to show relevant data
                    Label_District.Text = new DistrictTableWrapper().getDistrictForUser(username);
                    fillClientListForUser(username);
                }
            }
            else
            {
                Response.Redirect("/WebForms/Not_Logged_In.aspx");
            }
        }

        private void fillClientListForUser(string username)
        {
            List<string> clients = new ClientTableWrapper().getClientsForEngineer(username);
            foreach (var clientName in clients)
            {
                ListBox_Clients.Items.Add(clientName);
            }
        }

        protected void btn_ViewClient_Click(object sender, EventArgs e)
        {

        }

        protected void btn_NewClient_Click(object sender, EventArgs e)
        {
           

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void selectedClient_Click(object sender, EventArgs e)
        {
            //Session["selected"] = list_Clients.SelectedItem.ToString();
            Response.Redirect("/WebForms/View_Client.aspx");
        }
    }
}