using System;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.Owin;
using System.Diagnostics;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                var interventions = new InterventionTableAdapter().GetDataBy_ClientId(1);

                if (Session["selected"] != null)
                    lblName.Text = Session["selected"].ToString();
                else
                {
                    //    lblName.Text = "Sample name";
                    //lblLocation.Text = "Ashfield";
                    //lblDistrict.Text = "Sydney";
                    //Debug.WriteLine("debugwriteline" + User.Identity.Name);
                    lblName.Text = User.Identity.Name;
                    lblLocation.Text = User.IsInRole("Accountant") ? "true" : "false";
                    lblDistrict.Text = "sydney";
                }
                //Update button will be add automatically
                foreach (var intervention in interventions)
                {
                    InterventionTable.Rows.Add(addTableRow(intervention.InterventionId, intervention.Notes,
                         "Cost: "+ intervention.Cost.ToString()+"<br>" +"Hours: "+ intervention.Hours.ToString()));
                }
            }

           

        }

        protected TableRow addTableRow(int ID, string InterventionName, string InterventionDetails)
        {
            Button updateButton = new Button();

            TableRow tr = new TableRow();

            TableCell name = new TableCell();
            TableCell details = new TableCell();
            TableCell update = new TableCell();

            updateButton.Text = "Update Intervention";
            updateButton.Click += new EventHandler(this.button_Click);
            updateButton.ID = ID.ToString(); //<---- Assign intervention name to ID so we can extract later

            name.Text = InterventionName;
            details.Text = InterventionDetails;
            update.Controls.Add(updateButton);

            tr.Height = 30;
            tr.Cells.Add(name);
            tr.Cells.Add(details);
            tr.Cells.Add(update);
                       
            return tr;
        }

        protected void button_Click(object sender, EventArgs e)
        {
            //Test only
            Button click = sender as Button; //click.ID will contain the intervention name which can be used
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" +"You have clicked intervention "+ click.ID + "');", true);
            //Make sure we gather everything we need in that before going to next page
            //Put it in Session
            Response.Redirect("/WebForms/Update_Intervention_Details.aspx");
        }

        protected void btnAddIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/Add_New_Intervention.aspx");

        }
    }
}