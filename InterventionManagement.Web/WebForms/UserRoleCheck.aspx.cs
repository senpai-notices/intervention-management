using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity.Owin;

using Microsoft.AspNet.Identity;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.Identity;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class UserRoleCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.IsInRole("Engineer"))
                Response.Redirect("/WebForms/Engineer_Clients.aspx");
            else if (Page.User.IsInRole("Manager"))
                Response.Redirect("/WebForms/Manager_Intervention.aspx");
            else if (Page.User.IsInRole("Accountant"))
                Response.Redirect("/WebForms/Accountant.aspx");

        }
    }
}