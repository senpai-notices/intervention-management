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
            if (clients.Count > 0)
            {
                ListBox_Clients.SelectedIndex = 0;
            }
        }

        protected void btn_ViewClient_Click(object sender, EventArgs e)
        {

        }

        protected void btn_NewClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/Add_New_Client.aspx");

        }

        protected void selectedClient_Click(object sender, EventArgs e)
        {
            if (ListBox_Clients.SelectedIndex != -1)
            {
                // save selected clientId to session
                string selectedClientName = ListBox_Clients.SelectedItem.ToString();
                string[] split = selectedClientName.Split(null);
                Session["ClientId"] = split[0].ToString();

                Response.Redirect("/WebForms/View_Client.aspx");
            }
            else
            {
                string errorMessage = "Please select a client first";
                Response.Write("<script>alert('" + errorMessage + "')</script>");
            }
        }
    }
}