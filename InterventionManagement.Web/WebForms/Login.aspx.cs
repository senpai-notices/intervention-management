using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity.Owin;

using Microsoft.AspNet.Identity;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.Identity;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.Models;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Cancel(object sender, EventArgs e)
        {
            
        }

        protected void btn_Login(object sender, EventArgs e)
        {
            LogIn();

        }
        /// <summary>
        /// This method will check the username and password the user and then redirect them
        /// to 'UserRoleCheck.aspx' to check the role of that user and then redirect them to a corresponding dashboard
        /// </summary>
        protected void LogIn()
        {

            if (IsValid)
            {
                //Get all the users
                var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                string username = txt_loginID.Text;
                string password = txt_loginPW.Text;

                try
                {
                    new IdentityWrapper().SignIn(userManager, signInManager, username, password);
                        Response.Redirect("/WebForms/UserRoleCheck.aspx");
                }
                catch
                {
                    //catch sign in failed exception
                    //placeholder error message
                    lblError.Text = "Invalid username or password.";
                    lblError.Visible = true;
                }
            }
        }
    }
}
