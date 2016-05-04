using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Engineer_Clients : System.Web.UI.Page
    {
        /// <summary>
        /// When the page is loaded, it will check if the user is in role 'Engineer' or not
        /// It will display a list of client to the user if the user is an angineer
        /// otherwise, it will redirect them to 'Not_Logged_In.aspx'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This method will retrieve the list of client of the engineer
        /// </summary>
        /// <param name="username">username of the logged in user</param>
        private void fillClientListForUser(string username)
        {
            List<string> clients = new ClientTableWrapper().getClientIdAndNameListForEngineer(username);
            ListBox_Clients.DataSource = clients;
            ListBox_Clients.DataBind();

            if (clients.Count > 0)
            {
                ListBox_Clients.SelectedIndex = 0;
            }
        }

        protected void btn_NewClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/Add_New_Client.aspx");

        }

        /// <summary>
        /// This button click event will store the details of the client in a session and
        /// pass them to the next page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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