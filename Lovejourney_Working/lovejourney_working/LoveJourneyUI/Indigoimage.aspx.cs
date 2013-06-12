using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Indigoimage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblmsg.Text = Server.MapPath("~/images/indigo.png");
            img.ImageUrl = @"C:\inetpub\vhosts\lovejourney.in\subdomains\bus\httpdocs\images\indigo.png";
        }
    }
}