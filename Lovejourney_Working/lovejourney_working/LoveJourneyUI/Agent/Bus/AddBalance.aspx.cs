using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Text;

public partial class Agent_Bus_AddBalance : System.Web.UI.Page
{
   
    ClsBAL objManabusBAL = new ClsBAL();
    DataSet Objdataset;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Status"] != null)
            {
               
                updatebalance();
            }
            Panel pnl = (Panel)this.Master.FindControl("Menu1");
            pnl.Visible = false;
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      
        Session["RechargeAmount"] = txtAmount.Text;
        Session["Order_Id"] =   "RVPG" + GenerateRandomNumber(7);
       Response.Redirect("~/Pay.aspx", false);
    
     
      
     
    }

    protected string GenerateRandomNumber(int count)
    {
        try
        {

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            int number;
            for (int i = 0; i < count; i++)
            {
                number = random.Next(10);
                builder.Append(number);
            }

            return builder.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void updatebalance()
    {
          DataSet ds = new DataSet();
          ds =  objManabusBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
          if (ds != null)
          {
              if (ds.Tables.Count > 0)
              {
                  if (ds.Tables[0].Rows.Count > 0)
                  {
                      ClsBAL objBal = new ClsBAL();
                          DateTime? dtime = null;


                      //    string msg = objBal.AddAgentDeposit(Convert.ToInt32(Session["UserID"].ToString())
                      //, Convert.ToDouble(Session["RechargeAmount"].ToString()), "", Convert.ToInt32(Session["UserID"].ToString())
                      //, "Payment Gateway", Session["Order_Id"].ToString().ToString(), "");

                      //    lblMsg.InnerText = msg;
                          lblMsg.InnerText = objBal.InsertDepositUpdateRequest(Convert.ToInt32(Session["UserID"].ToString()), Convert.ToDouble(Session["RechargeAmount"].ToString()),
                              Convert.ToString(""), Session["Order_Id"].ToString(), "Payment Gateway",
                            "", "", System.DateTime.Now,
                             "", Convert.ToInt32(Session["UserID"].ToString()), "Deposited");
                          if (lblMsg.InnerText.ToString() == "Your request has been submitted successfully. Our Team will get back to you.")
                          {
                              lblmessage.Text = "your Amount added Successfully";

                              objBal.Upstatus(Convert.ToInt32(Session["UserID"].ToString()), Convert.ToDouble((Session["RechargeAmount"].ToString())));
                          }
                      
                  }
              }
          }
    }
}