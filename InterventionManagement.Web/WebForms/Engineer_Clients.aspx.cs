using System;
using System.Linq;
using System.Collections.Generic;

using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;


using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using System.Web.UI.WebControls;

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
                //MainDataSet.EngineerDataTable engineers = new EngineerTableAdapter();
                //DistrictDataSet.DistrictDataTable districts = new DistrictTableAdapter
                var districts = new Data.DataSets.MainDataSetTableAdapters.DistrictTableAdapter()
                    .GetDataBy_GetDistrictByEngineerUsername("DebugEngineer");                

                 foreach(var district in districts)
                 {
                    ListItem i = new ListItem(district.Name.ToString(), "");
                    DistrictDropDownList.Items.Add(i);
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