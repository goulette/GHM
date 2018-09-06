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
    public partial class EditContactType : System.Web.UI.Page
    {
        int ContactTypeID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out ContactTypeID);

            if (!Page.IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetContactType", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", ContactTypeID);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();

                    ContactTypeTextBox.Text = rdr["ContactTypeDescription"].ToString();
                    rdr.Close();
                    conn.Close();
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string ContactType = ContactTypeTextBox.Text;

            if (ContactType.Length == 0)
            {
                ErrorMsg.Text = "You must enter a Contact Type!";
                return;
            }
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateContactType", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", ContactTypeID);
                cmd.Parameters.AddWithValue("@contacttypedescription", ContactType);

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
                conn.Close();
                Response.Redirect("admin.aspx");
            }
        }
    }
}