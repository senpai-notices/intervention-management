using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                
        }
        /*When Save button is clicked, it will first check if the new passwords match and then if
        they match, it will check if the current password is correct.
        After performing all the verification, it will remove the old password and add the new password in.
        lblMessage.Text will notify user the result*/
        protected void Button_Save_OnClick(object sender, EventArgs e)
        {           
            var userID = User.Identity.GetUserId();
            
            if (TextBox_NewPassword1.Text != TextBox_NewPassword2.Text)
            {
                lblMessage.Text = "New passwords do not match.";
            }
            else
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                if (manager.CheckPassword(manager.FindById(userID), TextBox_ExistingPassword.Text))
                {
                    
                    manager.RemovePassword(userID);                   
                    manager.AddPassword(userID, TextBox_NewPassword1.Text);
                    lblMessage.Text = "Your password has been changed.";
                } else
                    lblMessage.Text = "Your current password is incorrect.";

            }
            lblMessage.Visible = true;
        }

        protected void Button_Cancel_OnClick(object sender, EventArgs e)
        {
            // add cancel code
        }
    }
}