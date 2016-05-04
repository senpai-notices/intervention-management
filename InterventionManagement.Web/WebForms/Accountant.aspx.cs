using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Accountant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }        
       

        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/Run_Report.aspx");
        }
    }
}