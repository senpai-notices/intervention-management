using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.Identity;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using System.Web.UI.WebControls;

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

            try
            {
                IdentityWrapper identity = new IdentityWrapper();
                identity.CreateUser(username, password, roleName);

                // create additional tables required
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

                // sign in this new user
                var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                identity.SignIn(userManager, signInManager, username, password);
                Response.Redirect("/WebForms/View_Client.aspx");
            }
            catch (Exception exception)
            {
                // do something
            }
        }
    }
}