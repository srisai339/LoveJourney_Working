using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_Recharge_Failure : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Status"] != null && Session["Status"].ToString() != null) 
        {
            lblStrmessage.Text = Session["Status"].ToString();

            lblerror.Text = "Error No :" + "" + Session["errorcode"].ToString() + " ," + "Error Message :" + Session["errorDecsription"].ToString();
        }
        else
        {
            lblStrmessage.Text = "";
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
}