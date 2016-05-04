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
        /// <summary>
        /// When the page is loaded, it will add a list of district to the DistrictDropDownList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {

                var districts = new DistrictTableWrapper().getDistrictsList();

                foreach (var district in districts)
                {
                    ListItem i = new ListItem(district.ToString());
                    DistrictDropDownList.Items.Add(i);
                }
            }
        }
        /// <summary>
        /// When the register button is clicked, it will add user and the role 
        /// he/she selected to the database
        /// It will also redirect user to the UserRoleCheck.aspx which is then 
        /// redirect he/she to his/her corresponding dashboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    new EngineerTableWrapper().InsertEngineer(username, name,approvalHours, approvalCost, districtID);
                }
                else if (roleName == "Manager")
                {
                    new ManagerTableWrapper().InsertManager(username,name, approvalHours, approvalCost, districtID);
                }
                else if (roleName == "Accountant")
                {
                    new UserTableWrapper().InsertUser(username,name);
                }

                // sign in this new user
                var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                identity.SignIn(userManager, signInManager, username, password);
                Response.Redirect("/WebForms/UserRoleCheck.aspx");
            }
            catch (Exception exception)
            {
                // catch error exception
                
            }
        }
    }
}