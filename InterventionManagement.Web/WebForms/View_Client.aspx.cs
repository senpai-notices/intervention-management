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
        /// <summary>
        /// When the page is loaded, it will add the interventions associated with the client
        /// to a table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                var interventions = new InterventionTableAdapter().GetDataBy_ClientId(1);

                if (Session["ClientId"] != null)
                {
                    lblName.Text = Session["ClientId"].ToString();
                }
                else
                {
                    lblName.Text = User.Identity.Name;
                    lblLocation.Text = User.IsInRole("Accountant") ? "true" : "false";
                    lblDistrict.Text = "sydney";
                }
                
                foreach (var intervention in interventions)
                {
                    InterventionTable.Rows.Add(addTableRow(intervention.InterventionId, intervention.Notes,
                         "Cost: "+ intervention.Cost.ToString()+"<br>" +"Hours: "+ intervention.Hours.ToString()));
                }
            }          
        }

        /// <summary>
        /// This method will add a table row to the main table
        /// The table row will take 3 parameters and add them to the main table
        /// </summary>
        /// <param name="ID">Id of the intervention</param>
        /// <param name="InterventionName">Name of the intervention</param>
        /// <param name="InterventionDetails">Details of the intervention</param>
        /// <returns>A table row that contains data</returns>
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

        /// <summary>
        /// TO BE IMPLEMENTED
        /// When the 'Update Intervention' button is clicked, it will redirect user to a new page
        /// to modify the selected intervention of the client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button_Click(object sender, EventArgs e)
        {

            Button click = sender as Button; //click.ID will contain the intervention name which can be used
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" +"You have clicked intervention "+ click.ID + "');", true);

            Response.Redirect("/WebForms/Update_Intervention_Details.aspx");
        }

        protected void btnAddIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/Add_New_Intervention.aspx");

        }
    }
}