using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Manager_Intervention : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                for (int i = 0; i < 4; i++) //<----Change number 4 to the number of interventions 
                {
                    InterventionTable.Rows.Add(addTableRow(i, "This is intervention name " + i, "this is intervention details " + i));
                }
            }
        }


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
            approveButton.ID = ID.ToString(); //<---- Assign intervention name to ID so we can extract later

            name.Text = InterventionName;
            details.Text = InterventionDetails;
            update.Controls.Add(approveButton);
            update.Controls.Add(removeButton);

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
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "You have clicked intervention " + click.ID + "');", true);
            //Make sure we gather everything we need in that before going to next page
            //Put it in Session
        }
        protected void removeButton_Click(object sender, EventArgs e)
        {
            //Test only
            Button click = sender as Button; //click.ID will contain the intervention name which can be used
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "You have removed intervention " + click.ID + "');", true);
            //Make sure we gather everything we need in that before going to next page
            //Put it in Session
        }
    }
}