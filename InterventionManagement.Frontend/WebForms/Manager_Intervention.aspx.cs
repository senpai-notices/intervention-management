using System;
using System.Collections.Generic;
using System.Web.UI;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Manager_Intervention : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                if (!IsPostBack)
                {
                    Response.Write("Hello " + Session["Login"].ToString());
                    List<string> data = new List<string> { "Woop Woop 1", "Boop boop2", "Scoop Scoop", "Meep Meep" };

                    ListBox1.DataSource = data;
                    ListBox1.DataBind();

                }
            }
            else
            {
                //hide all controls to prevent unauthorised use
                foreach (Control c in this.Controls)
                    c.Visible = false;

                Response.Write("<p>You cannot view this page because you haven't logged in.<p>" +
                    " Please click <a href = Login.aspx>here</a> to log in.");
            }
          }

        protected void ViewIntervention_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                lbl_InterventionType.Text = ListBox1.SelectedItem.Text;
            }
        }
    }
}