using System;
using System.IO;
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
    public partial class EditCarrierDetails : System.Web.UI.Page
    {
        int CarrierID;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CarrierID);
            if (!IsPostBack)
            {
                string logopath;
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetCarrierDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", CarrierID);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                NameTextBox.Text = rdr["CarrierName"].ToString();
                LogoURLTextBox.Text = rdr["Website"].ToString();
                logopath = rdr["Logo"].ToString();
                rdr.Close();
                conn.Close();
                }
                LogoImage.ImageUrl = "~/Images/Logos/" + Path.GetFileName(logopath);
                LogoTextBox.Text = logopath;
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string CarrierName = NameTextBox.Text;

            if (CarrierName.Length == 0)
            {
                ErrorMsg.Text = "You must enter a carrier name!";
                return;
            }

            string folder = Server.MapPath("~/Documents/" + CarrierName);
            Directory.CreateDirectory(folder);

            string LogoFile = LogoTextBox.Text.ToString();
            string LogoURL = LogoURLTextBox.Text;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateCarrier", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", CarrierID);
                cmd.Parameters.AddWithValue("@carriername", CarrierName);
                cmd.Parameters.AddWithValue("@logo", LogoFile);
                cmd.Parameters.AddWithValue("@website", LogoURL);

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
                conn.Close();
                Response.Redirect("admin.aspx");
            }
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/Images/Logos/");

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath);
            }

            String fileName = LogoFileUpload.FileName;

            //Save the File to the Directory (Folder).
            LogoFileUpload.SaveAs(folderPath + Path.GetFileName(LogoFileUpload.FileName));

            //Display the Picture in Image control.
            LogoImage.ImageUrl = "~/Images/Logos/" + Path.GetFileName(LogoFileUpload.FileName);
            LogoTextBox.Text = fileName;
        }
    }
}