using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace GHM
{
    public partial class CarrierContacts : System.Web.UI.Page
    {
        int CarrierID;
        DataSet ds = new DataSet();
        StringBuilder htmlCode = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CarrierID);
            htmlCode.Append("<table align='center' width=100%>");
            htmlCode.Append("<tr><td>");
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetCarrierContactTypes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carrierid", CarrierID);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(rdr);
                rdr.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    htmlCode.Append("<tr>");
                    htmlCode.Append("<td>" + row["ContactTypeDescription"] + "<br>");
                }
                htmlCode.Append("</td>");
                htmlCode.Append("</table>");
            }
            DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlCode.ToString() });
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            TransferString = "~/CarrierInfo.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }
    }
}