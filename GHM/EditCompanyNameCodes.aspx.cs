using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GHM
{
    public partial class EditCompanyNameCodes : System.Web.UI.Page
    {
        int CompanyNameID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CompanyNameID);

            if (!Page.IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAgencyName", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@id", CompanyNameID);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();

                    CompanyNameTextBox.Text = rdr["AgencyName"].ToString();
                    rdr.Close();
                    conn.Close();
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string CompanyName = CompanyNameTextBox.Text;

            if (CompanyName.Length == 0)
            {
                ErrorMsg.Text = "You must enter a Company Name!";
                return;
            }
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateCompanyName", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", CompanyNameID);
                cmd.Parameters.AddWithValue("@agencyname", CompanyName);

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
                conn.Close();
                Response.Redirect("admin.aspx");
            }
        }
    }
}