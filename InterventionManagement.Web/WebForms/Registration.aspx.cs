using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
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
                // pass
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
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
                    new EngineerTableWrapper().addEngineer(username, 1, 1, 1, "Named");
                }
                else if (roleName == "Manager")
                {
                    new ManagerTableWrapper().addManager(username, 1, 1, 1, "Named");
                }
                else if (roleName == "Accountant")
                {
                    new UserTableWrapper().addUser(username, "Named");
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