using System;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.DistrictDataSetTableAdapters;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.Experimental
{
    public partial class DistrictTds : System.Web.UI.Page
    {
        private readonly DistrictTableAdapter _districtTableAdapter = new DistrictTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GridView1.DataSource = _districtTableAdapter.GetDistricts();
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                GridView1.DataSource = _districtTableAdapter.GetDistricts();
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = _districtTableAdapter.GetDistrictByDistrictId(int.Parse(TextBox1.Text));
                GridView1.DataBind();
            }
        }
    }
}