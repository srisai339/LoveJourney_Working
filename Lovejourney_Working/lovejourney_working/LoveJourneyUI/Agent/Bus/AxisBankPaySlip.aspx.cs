using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Agent_Bus_AxisBankPaySlip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdngAgentName.InnerText=Request.QueryString["Name"];
        hdngAgentCode.InnerText=Request.QueryString["Code"];
    }
}