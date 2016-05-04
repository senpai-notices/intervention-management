using System;
using System.Collections.Generic;
using System.Web.UI;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using System.Web.UI.WebControls;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Manager_Intervention : System.Web.UI.Page
    {
        /// <summary>
        /// When the page is loaded, it will retrieve the intervention(s) that needed to be approved
        /// and put it in the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*Dictionary<int, KeyValuePair<string, string>> interventions = new InterventionTableWrapper().getInterventionsByManager(User.Identity.Name);               
                foreach (var details in interventions)
                {
                    InterventionTable.Rows.Add(addTableRow(details.Key, details.Value.Key,details.Value.Value));
                }*/
                
                for (int i = 0; i < 4; i++)
                {
                    InterventionTable.Rows.Add(addTableRow(i, "", ""));
                }
            }
        }

        /// <summary>
        /// This method will add a table row to the main table
        /// The table row will take 3 parameters and add them to the main table
        /// </summary>
        /// <param name="ID"> Id of the intervention</param>
        /// <param name="InterventionName">Name of the intervention</param>
        /// <param name="InterventionDetails">Details of the intervention</param>
        /// <returns>A table row that contains data</returns>
        protected TableRow addTableRow(int ID, string InterventionName, string InterventionDetails)
        {
            Button approveButton = new Button();
            Button removeButton = new Button();

            TableRow tr = new TableRow();

            TableCell name = new TableCell();
            TableCell details = new TableCell();
            TableCell update = new TableCell();

            approveButton.Text = "Approve ";
            removeButton.Text = "Remove ";
            
            approveButton.Click += new EventHandler(this.button_Click);
            removeButton.Click += new EventHandler(this.removeButton_Click);
            removeButton.ID = ID.ToString();
            approveButton.ID = ID.ToString(); // Assign intervention name to ID so we can extract later

            name.Text = InterventionName;
            details.Text = InterventionDetails;
            /*update.Controls.Add(approveButton);
            update.Controls.Add(removeButton);
            */
            tr.Height = 30;
            tr.Cells.Add(name);
            tr.Cells.Add(details);
            tr.Cells.Add(update);

            return tr;
        }
        /// <summary>
        /// TO BE IMPLEMENTED
        /// When the approve button is clicked, it will get the ID of the intervention
        /// and change its status to 'Approved'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button_Click(object sender, EventArgs e)
        {

            Button click = sender as Button; //click.ID will contain the intervention name which can be used
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "You have clicked intervention " + click.ID + "');", true);

        }

        /// <summary>
        /// TO BE IMPLEMENTED
        /// When the approve button is clicked, it will get the ID of the intervention
        /// and change its status to 'Cancelled'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void removeButton_Click(object sender, EventArgs e)
        {
            Button click = sender as Button; //click.ID will contain the intervention name which can be used
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "You have removed intervention " + click.ID + "');", true);

        }
    }
}