using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Accountant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++) //<----Change number 4 to the number of interventions of that client 
            {
                Table1.Rows.Add(addTableRow(i, "This is intervention name " + i, "this is intervention details " + i));
            }

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected TableRow addTableRow(int ID, string Name, string Role)
        {
            //Button updateButton = new Button();
            DropDownList changeDistrict = new DropDownList();
            TableRow tr = new TableRow();

            TableCell name = new TableCell();
            TableCell details = new TableCell();
            TableCell update = new TableCell();
            TableCell district = new TableCell();

            changeDistrict.Items.Add("District 1");
            changeDistrict.Items.Add("District 2");
            changeDistrict.Items.Add("District 3");
            changeDistrict.Items.Add("District 4");
            changeDistrict.Items.Add("District 5");

            //updateButton.Text = "Update";
            // updateButton.Click += new EventHandler(this.button_Click);
            // updateButton.ID = ID.ToString(); //<---- Assign intervention name to ID so we can extract later

            name.Text = Name;
            details.Text = Role;
            district.Text = "Sample district";
            update.Controls.Add(changeDistrict);

            tr.Height = 30;
            tr.Cells.Add(name);
            tr.Cells.Add(details);
            tr.Cells.Add(district);
            tr.Cells.Add(update);

            return tr;
        }


        protected void button_Click(object sender, EventArgs e)
        {
            //Test only
            Button click = sender as Button; //click.ID will contain the intervention name which can be used
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "You have clicked user " + click.ID + "');", true);
            //Make sure we gather everything we need in that before going to next page
            //Put it in Session
        }

    }
}