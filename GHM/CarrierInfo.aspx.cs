using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace GHM
{
    public partial class CarrierInfo : System.Web.UI.Page
    {
        int CarrierID;
        DataSet ds = new DataSet();   
        StringBuilder htmlCode = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            string str;
            int.TryParse(Request.QueryString["id"], out CarrierID);
            DocumentsLink.NavigateUrl = "~/CarrierDocuments.aspx?id=" + CarrierID;
            ContactsLink.NavigateUrl = "~/CarrierContacts.aspx?id=" + CarrierID;
            htmlCode.Append("<table width=100%>");
                htmlCode.Append("<tr width=90%>");
                    htmlCode.Append("<td width=33%>");
                        htmlCode.Append("<table width='100%'");
                            htmlCode.Append("<tr><td style='color: #0C77BD'><b><u>ADDRESSES:</u></b><br><br></td></tr>");
                            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                            {
                                SqlCommand cmd = new SqlCommand("spGetCarrierAddress", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id", CarrierID);
                                conn.Open();
                                SqlDataReader rdr = cmd.ExecuteReader();
                                DataTable dataTable = new DataTable();
                                dataTable.Load(rdr);
                                rdr.Close();

                                foreach (DataRow row in dataTable.Rows)
                                {
                                    htmlCode.Append("<tr>");
                                    htmlCode.Append("<td><b><u>" + row["AddressDescription"] + "</u></b><br>");
                                    str = row["AddressLine1"].ToString();
                                    if (str.Length > 0)
                                    {
                                        htmlCode.Append(str + "<br>");
                                    }
                                    str = row["AddressLine2"].ToString();
                                    if (str.Length > 0)
                                    {
                                        htmlCode.Append(str + "<br>");
                                    }
                                    str = row["AddressLine3"].ToString();
                                    if (str.Length > 0)
                                    {
                                        htmlCode.Append(str + "<br>");
                                    }
                                    str = row["City"].ToString();
                                    if (str.Length > 0)
                                    {
                                        htmlCode.Append(str + ", ");
                                        str = row["CountryID"].ToString();
                                        if (str == "1")
                                        {
                                            str = row["StateID"].ToString();
                                            htmlCode.Append("ME ");
                                        }
                                    }
                                    str = row["Zip"].ToString();
                                    if (str.Length > 0)
                                    {
                                        htmlCode.Append(str);
                                    }
                                    htmlCode.Append("</td>");
                                    htmlCode.Append("</tr><br>");
                                }
                        htmlCode.Append("</table>");
                    htmlCode.Append("</td>");
                    htmlCode.Append("<td width=33%>");
                        htmlCode.Append("<table style='text - align:center'>");
                            cmd = new SqlCommand("spGetCarrierPhone", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", CarrierID);
                            rdr = cmd.ExecuteReader();
                            dataTable = new DataTable();
                            dataTable.Load(rdr);
                            rdr.Close();

                            htmlCode.Append("<tr><td style='color: #0C77BD'><b><u>PHONE NUMBERS:</u></b><br><br></td></tr>");
                            foreach (DataRow row in dataTable.Rows)
                            {
                                    htmlCode.Append("<tr>");
                                    htmlCode.Append("<td><b><u>" + row["PhoneDescription"] + "</u></b><br>");
                                    str = row["PhoneNumber"].ToString();
                                    if (str.Length > 0)
                                    {
                                        htmlCode.Append(str + "<br>");
                                    }
                                    htmlCode.Append("</td></tr>");
                            }
                            cmd = new SqlCommand("spGetCarrierFax", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", CarrierID);
                            rdr = cmd.ExecuteReader();
                            dataTable = new DataTable();
                            dataTable.Load(rdr);
                            rdr.Close();

                            htmlCode.Append("<tr><td style='color: #0C77BD'><br><b><u>FAX NUMBERS:</u></b><br><br></td></tr>");
                            foreach (DataRow row in dataTable.Rows)
                            {
                                htmlCode.Append("<tr>");
                                htmlCode.Append("<td><b><u>" + row["FaxDescription"] + "</u></b><br>");
                                str = row["FaxNumber"].ToString();
                                if (str.Length > 0)
                                {
                                    htmlCode.Append(str + "<br>");
                                }
                                htmlCode.Append("</td></tr>");
                            }
                        htmlCode.Append("</table>");
                    htmlCode.Append("</td>");
                    htmlCode.Append("<td width=33%>");
                        htmlCode.Append("<table style='text - align:center' width='100%'>");
                            cmd = new SqlCommand("spGetCarrierWebsites", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", CarrierID);
                            rdr = cmd.ExecuteReader();
                            dataTable = new DataTable();
                            dataTable.Load(rdr);
                            rdr.Close();

                            htmlCode.Append("<tr><td style='color: #0C77BD'><b><u>WEBSITES:</u></b><br><br></td></tr>");
                            foreach (DataRow row in dataTable.Rows)
                            {
                                htmlCode.Append("<tr>");
                                htmlCode.Append("<td><b><u>" + row["WebsiteDescription"] + "</u></b><br>");
                                str = row["URL"].ToString();
                                if (str.Length > 0)
                                {
                                    htmlCode.Append("<a href = " + str + " target='_blank'>" + str + "<br>");
                                }
                                htmlCode.Append("</td></tr>");
                            }
                cmd = new SqlCommand("spGetCarrierCodes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carrierid", CarrierID);
                rdr = cmd.ExecuteReader();
                dataTable = new DataTable();
                dataTable.Load(rdr);
                rdr.Close();

                htmlCode.Append("<tr><td style='color: #0C77BD'><br><b><u>AGENCY CODES:</u></b><br><br></td></tr>");
                foreach (DataRow row in dataTable.Rows)
                {
                    htmlCode.Append("<tr>");
                    htmlCode.Append("<td><b>" + row["AgencyName"] + ":</b> " + row["CarrierCode"].ToString());
                    htmlCode.Append("</td></tr>");
                }
                conn.Close();
                htmlCode.Append("</table>");
                htmlCode.Append("</td></tr>");
                htmlCode.Append("</table>");
            }
            DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlCode.ToString() });
        }
    }
}