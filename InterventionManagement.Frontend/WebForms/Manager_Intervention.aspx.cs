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
            if (!IsPostBack)
            {
                List<string> data = new List<string> { "Woop Woop 1", "Boop boop2", "Scoop Scoop", "Meep Meep" };

                ListBox1.DataSource = data;
                ListBox1.DataBind();

            }
          }

        protected void ViewIntervention_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                // Allowing opperation on selected item.
                Button1.Text = ListBox1.SelectedItem.Text;
            }
        }
    }
}