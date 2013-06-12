using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_Recharge_RechargeSuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Status"] != null && Session["Status"].ToString() != null)
        {
            lblmsg.Text = Session["Status"].ToString();
        }
        else
        {
            lblmsg.Text = "";
        }


        if (Session["Order_Id"].ToString() != null && Session["Order_Id"] != null)
        {
            lblreqid.Text = "Your Request Id is " + Session["Order_Id"].ToString();
            lblreqid.Visible = true;
        }
        else
        {
            lblreqid.Text = "";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Masters/RechargeStatus.aspx", false);
    }
}