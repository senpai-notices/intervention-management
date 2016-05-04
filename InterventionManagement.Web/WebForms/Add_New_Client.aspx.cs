using System;
using System.Collections.Generic;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Services;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Add_New_Client : System.Web.UI.Page
    {
        /// <summary>
        /// When the page is loaded, if the user is in role engineer then 
        /// it will display a list of district
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Engineer"))
            {
                if (!IsPostBack)
                {
                    // set controls to show relevant data
                    fillDistrictList();
                }
            }
            else
            {
                Response.Redirect("/WebForms/Not_Logged_In.aspx");
            }
        }

        /// <summary>
        /// Get all districts
        /// </summary>
        private void fillDistrictList()
        {
            var districts = new DistrictTableWrapper().getDistrictsAndIdsList();
            dropList_District.DataSource = districts;
            dropList_District.DataBind();
        }

        /// <summary>
        /// This button click event will get details from the textboxes and 
        /// create a client accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_CreateClient_Click(object sender, EventArgs e)
        {
            string name = txt_Name.Text;
            string location = txtLocation.Text;
            int districtId = getDistrictIdForSelectedDistrict();
            bool validName = !String.IsNullOrWhiteSpace(name);

            if (validName)
            {
                string message = ClientManager.AddNewClient(name, location, districtId);
                // new ClientTableWrapper().addClient(name, location, districtId);
                showMessage(message);
            }
            else
            {
                showMessage("Client not created, the client name cannot be blank");
            }
        }


        /// <summary>
        /// Return district ID of the selected district
        /// </summary>
        /// <returns>Id of the district</returns>
        private int getDistrictIdForSelectedDistrict()
        {
            string idAndName = dropList_District.SelectedItem.ToString();
            string idString = idAndName.Split(null)[0];
            int id = Convert.ToInt32(idString);
            return id;
        }

        /// <summary>
        /// User message
        /// </summary>
        /// <param name="message"></param>
        private void showMessage(string message)
        {
            Response.Write("<script>alert('" + message + "')</script>");
        }
    }
}