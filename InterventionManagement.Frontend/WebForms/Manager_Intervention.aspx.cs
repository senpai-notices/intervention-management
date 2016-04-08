using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagement.Frontend.WebForms
{
    public partial class Manager_Intervention : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ViewIntervention_Click(object sender, EventArgs e)
        {
            var tmp = list_Interventions.SelectedValue;

            Button1.Text =  tmp.ToString();
        }
    }
}