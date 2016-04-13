using System;

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
            if (txt_loginID.Text == "John Smith" && txt_loginPW.Text == "John Smith")
            {
                Response.Write("<script>alert('Success')</script>");
                Session["login"] = txt_loginID.Text; 
                Response.Redirect("~/WebForms/Manager_Intervention.aspx");
            }
            else
                Response.Write("<script>alert('Failed')</script>");

        }

        protected void txt_loginPW_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_loginID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}