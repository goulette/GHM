using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GHM
{
    public partial class GHMUserControls : System.Web.UI.UserControl
    {
        int CarrierID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CarrierID);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetCarrierInfo", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", CarrierID);

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                CarrierLabel.Text = rdr["CarrierName"].ToString();
                CarrierLink.ImageUrl = "~/Images/Logos/" + rdr["Logo"].ToString();
                CarrierLink.NavigateUrl = rdr["Website"].ToString();
                Session["CarrierName"] = CarrierLabel.Text;
                rdr.Close();
                conn.Close();
            }
        }
    }
}