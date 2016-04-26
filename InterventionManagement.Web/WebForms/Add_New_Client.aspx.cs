using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.ClientDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms
{
    public partial class Add_New_Client : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dropList_District.DataSource = new List<string> { "Spot A", "Banlands B", "Middle o Nowhere C", "Neverland D" };
                dropList_District.DataBind();
            }

        }

        protected void btn_CreateClient_Click(object sender, EventArgs e)
        {
            bool validName = !String.IsNullOrWhiteSpace(txt_Name.Text);

            // showing that we can access data from typed datasets
            ClientDataSet.ClientDataTable clients = new ClientTableAdapter().GetData();
            foreach (ClientDataSet.ClientRow clientRow in clients)
            {
                Response.Write("<script>alert('" + clientRow.Name + clientRow.Location + "')</script>");
            }

            ClientDataSet.ClientRow testRow = clients.NewClientRow();
            testRow.Location = "test location";
            testRow.Name = "John Smithy";
            testRow.DistrictId = 5;
            testRow.ClientId = 10;

            clients.Rows.Add(testRow);
            Response.Write("<script>alert('" + "new row added" + "')</script>");
            foreach (ClientDataSet.ClientRow clientRow in clients)
            {
                Response.Write("<script>alert('" + clientRow.Name + clientRow.Location + "')</script>");
            }
            
            ClientTableAdapter cta = new ClientTableAdapter();
            cta.Update(clients);
            // end the demo section
            // testing FillByClientId
            Response.Write("<script>alert('" + "testing fillbyclientid method" + "')</script>");

            clients = new ClientTableAdapter().GetDataByClientId(10);
            foreach (ClientDataSet.ClientRow clientRow in clients)
            {
                Response.Write("<script>alert('" + clientRow.Name + clientRow.Location + "')</script>");
            }
            // end test 2

            if (validName)
            {
                string message = "New Client Created. Name = " + txt_Name.Text + " District = " + dropList_District.SelectedItem.Text;
                Response.Write("<script>alert('" + message + "')</script>");
            }
            else
            {
                string message = "Error: Invalid Input into fields";
                Response.Write("<script>alert('" + message + "')</script>");
            }
        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            string message = "Cancelled.. Redirecting to previous page";
            Response.Write("<script>alert('" + message + "')</script>");
        }
    }
}