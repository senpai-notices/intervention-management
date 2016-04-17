using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity.Owin;

using Microsoft.AspNet.Identity;


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
        protected void LogIn()
        {
           
           if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                
                var user = manager.FindByName(txt_loginID.Text);
                if (user != null)
                {
                    if (manager.CheckPassword(user, txt_loginPW.Text))
                    {
                        signinManager.SignIn(user, false, false);
                        Response.Redirect("/WebForms/View_Client.aspx");
                        
                    }
                }
                }
            }
        }
    }
