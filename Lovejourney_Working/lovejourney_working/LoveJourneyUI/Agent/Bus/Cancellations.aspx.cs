using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
using System.Text;
using System.IO;

public partial class Agent_Cancellations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "LoveJourney - Bus - Cancellations";
        if (!IsPostBack)
        {

        }
    }
}