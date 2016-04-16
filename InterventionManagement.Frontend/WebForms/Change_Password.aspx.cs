using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagement.Web.WebForms
{
    public partial class Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Save_OnClick(object sender, EventArgs e)
        {
            if (TextBox_NewPassword1.Text != TextBox_NewPassword2.Text)
            {
                // new passwords do not match error
            }
            else
            {
                if (TextBox_ExistingPassword.Text != "user's current password")
                {
                    // old password is wrong error
                }
                else
                {
                    // new password saved
                }
            }
        }

        protected void Button_Cancel_OnClick(object sender, EventArgs e)
        {
            // add cancel code
        }
    }
}