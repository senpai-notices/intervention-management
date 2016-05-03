using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Add_New_Intervention : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Engineer"))
            {
                // set controls to show relevant data
                fillStatusDropDownWithPending();
                fillClientDropDown();
            }
            else
            {
                Response.Redirect("/WebForms/Not_Logged_In.aspx");
            }
        }

        public void fillStatusDropDownWithPending()
        {
            DropDownListStatus.DataSource = new List<string>() { "Pending" };
            DropDownListStatus.DataBind();
        }

        public void fillClientDropDown()
        {
            List<string> contents;

            if(Session["ClientId"] != null)
            {
                int clientId = Convert.ToInt32(Session["ClientId"]);
                string name = new ClientTableWrapper().getClientNameByClientId(clientId);
                string idAndName = clientId.ToString() + " " + name;

                contents = new List<string>() { idAndName };
            }
            else
            {
                string username = User.Identity.Name;
                contents = new ClientTableWrapper().getClientIdAndNameListForEngineer(username);
            }

            DropDownListClient.DataSource = contents;
            DropDownListClient.DataBind();
        }
    }
}