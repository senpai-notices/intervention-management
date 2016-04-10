using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagement.Frontend.WebForms
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
            if (txt_loginID.Text == "John Smith" && txt_loginPW.Text == "John Smith")
                Response.Write("<script>alert('Success')</script>");
            else
                Response.Write("<script>alert('Failed')</script>");

        }
    }
}