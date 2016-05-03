using System;
using System.Collections.Generic;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Add_New_Client : System.Web.UI.Page
    {
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

        private void fillDistrictList()
        {
            var districts = new DistrictTableWrapper().getDistrictsAndIdsList();
            dropList_District.DataSource = districts;
            dropList_District.DataBind();
        }

        protected void btn_CreateClient_Click(object sender, EventArgs e)
        {
            string name = txt_Name.Text;
            string location = txtLocation.Text;
            int districtId = getDistrictIdForSelectedDistrict();
            bool validName = !String.IsNullOrWhiteSpace(name);

            if (validName)
            {
                new ClientTableWrapper().addClient(name, location, districtId);
                showMessage("Client created successfully");
            }
            else
            {
                showMessage("Client not created, the client name cannot be blank");
            }
        }

        private int getDistrictIdForSelectedDistrict()
        {
            string idAndName = dropList_District.SelectedItem.ToString();
            string idString = idAndName.Split(null)[0];
            int id = Convert.ToInt32(idString);
            return id;
        }

        private void showMessage(string message)
        {
            Response.Write("<script>alert('" + message + "')</script>");
        }
    }
}