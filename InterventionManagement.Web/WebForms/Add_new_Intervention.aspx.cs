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
                fillInterventionTypeDropDown();
                fillStatusDropDownWithPending();
                fillClientDropDown();
                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                Response.Redirect("/WebForms/Not_Logged_In.aspx");
            }
        }

        private void fillInterventionTypeDropDown()
        {
            DropDownListIntervention.DataSource = new InterventionTemplateTableWrapper().getTemplateIdAndNameList();
            DropDownListIntervention.DataBind();
        }
        private void fillStatusDropDownWithPending()
        {
            DropDownListStatus.DataSource = new List<string>() { "1 Pending" };
            DropDownListStatus.DataBind();
        }

        private void fillClientDropDown()
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int cost = Convert.ToInt32(txtCost.Text);
            int hours = Convert.ToInt32(txtHours.Text);
            string notes = txtNote.Text;
            int remainingLife = Convert.ToInt32(txtRemaining.Text);
            DateTime datePerformed = getDateFromTextBox();

            int interventionTemplateId = getIdFromIdAndNameString(DropDownListIntervention.SelectedItem.ToString());
            int interventionStateId = getIdFromIdAndNameString(DropDownListStatus.SelectedItem.ToString());
            int clientId = getIdFromIdAndNameString(DropDownListClient.SelectedItem.ToString());

            string username = User.Identity.Name;
            new InterventionTableWrapper().addIntervention(interventionTemplateId, datePerformed, interventionStateId, hours, cost, username, null, clientId, notes, remainingLife, datePerformed);
        }

        private DateTime getDateFromTextBox()
        {
            string dateString = txtDate.Text;
            string[] dateSplit = dateString.Split('-');
            int day = Convert.ToInt32(dateSplit[0]);
            int month = Convert.ToInt32(dateSplit[1]);
            int year = Convert.ToInt32(dateSplit[2]);
            //Response.Write("<script>alert('" + day.ToString() + month.ToString() + year.ToString() + "')</script>");
            return new DateTime(year, month, day);
        }
        private int getIdFromIdAndNameString(string idAndName)
        {
            return Convert.ToInt32(idAndName.Split(null)[0]);
        }
    }
}