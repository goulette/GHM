using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GHM
{
    public partial class CarrierContactInfo : System.Web.UI.Page
    {
        int CarrierID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CarrierID);
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            TransferString = "~/CarrierInfo.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }
    }
}