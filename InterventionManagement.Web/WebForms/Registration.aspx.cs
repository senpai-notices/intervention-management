using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.Identity;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;


namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var districts = new DistrictWrapper().getDistricts();
                
                foreach (var district in districts)
                {
                    ListItem i = new ListItem(district.ToString());
                    DistrictDropDownList.Items.Add(i);
                }

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int approvalHours = Convert.ToInt32(txtHours.Text);
            int approvalCost = Convert.ToInt32(txtCost.Text);
            int districtID = DistrictDropDownList.SelectedIndex + 1;

            string name = txtName.Text;      
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string roleName = DropDownList_Roles.SelectedItem.ToString();
            
            new IdentityWrapper().CreateUser(username, password, roleName);
            if (roleName == "Engineer")
            {
                new EngineerTableWrapper().addEngineer(username, approvalHours, approvalCost, districtID, name);
            }
            else if (roleName == "Manager")
            {
                new ManagerTableWrapper().addManager(username, approvalHours, approvalCost, districtID, name);
            }
            else if (roleName == "Accountant")
            {
                new UserTableWrapper().addUser(username, name);
            }
        }

        protected void DropDownList_Roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}