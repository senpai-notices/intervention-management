using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Run_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++) //<----Change number 4 to the number of interventions of that client 
            {
                Table1.Rows.Add(addTableRow(i, "This is name 1 " + i, "this is average cost " + i,"Sample total cost"));
            }
        }
        protected TableRow addTableRow(int ID, string Name, string averageCost, string totalCost)
        {


            TableRow tr = new TableRow();

            TableCell name = new TableCell();
            TableCell details = new TableCell();
            TableCell update = new TableCell();

           

            name.Text = Name;
            details.Text = averageCost;
            update.Text = totalCost;

            tr.Height = 30;
            tr.Cells.Add(name);
            tr.Cells.Add(details);
            tr.Cells.Add(update);

            return tr;
        }
    }
}