using System;
using System.Linq;
using System.Collections.Generic;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.DistrictDataSetTableAdapters;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.ClientDataSetTableAdapters;
namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Engineer_Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /* List<string> data = new List<string> { "Woop Woop 1", "Boop boop2", "Scoop Scoop",
                     "Meep Meep", "Boop boop2", "Scoop Scoop", "Meep Meep" };
                 data.Sort();
                 list_Clients.DataSource = data;
                 list_Clients.DataBind();*/

                DistrictDataSet.DistrictDataTable districts = new DistrictTableAdapter().GetDistricts();
                var x = from d in districts where d.DistrictId ==0 select d;
                
                
                foreach (var i in x)
                {
                    
                    DistrictDropDownList.Items.Add(i.ToString());
                }

            }
        }

        protected void btn_ViewClient_Click(object sender, EventArgs e)
        {

        }

        protected void btn_NewClient_Click(object sender, EventArgs e)
        {
           

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void selectedClient_Click(object sender, EventArgs e)
        {
            Session["selected"] = list_Clients.SelectedItem.ToString();
            Response.Redirect("/WebForms/View_Client.aspx");
        }
    }
}