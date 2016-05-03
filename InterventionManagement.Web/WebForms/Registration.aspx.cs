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

        }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //if (result.Succeeded)
            //{
            //    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
            //    Response.Redirect("/Webforms/Add_New_Client.aspx");
            //}
            //else
            //{
            //    Label5.Text = result.Errors.FirstOrDefault();
            //}
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string roleName = DropDownList_Roles.SelectedItem.ToString();

            new IdentityWrapper().CreateUser(username, password, roleName);
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
        }
    }
}