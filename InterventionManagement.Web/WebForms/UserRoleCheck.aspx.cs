using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity.Owin;

using Microsoft.AspNet.Identity;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.Identity;
/// <summary>
/// This web page is used to redirect user to their dashboard
/// </summary>
namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    /// <summary>
    /// This class will check the role of the logged in user and redirect them accordingly
    /// </summary>
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