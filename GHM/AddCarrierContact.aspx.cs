using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GHM
{
    public partial class AddCarrierContact : System.Web.UI.Page
    {
        int CarrierID;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CarrierID);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            TransferString = "~/EditCarrier.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }
    }
}