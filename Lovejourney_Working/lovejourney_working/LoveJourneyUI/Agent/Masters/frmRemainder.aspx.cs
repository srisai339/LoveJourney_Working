using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class Agent_Masters_frmRemainder : System.Web.UI.Page
{
    Class1 ObjBal;
    DataSet ObjDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindRemainder();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ObjBal = new Class1();
            ObjBal.Description1 = txtDescription.Text;
            ObjBal.ScreenInd = Master123.Remainders;


            if (ObjBal.fnInsertRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully insertd Your Remainder";
                txtDescription.Text = "";
            }
            else
            {
                lblmsg.Text = "You can not Inserted Your details";
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void BindRemainder()
    {
        try
        {
            ObjBal = new Class1();
            ObjDataSet = new DataSet();

            ObjBal.ScreenInd = Master123.GetRemainder;
            ObjDataSet = (DataSet)ObjBal.fnGetData();
            if (ObjDataSet.Tables[0] != null)
            {
                if (ObjDataSet.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;
                    gvRemainders.DataSource = ObjDataSet.Tables[0];
                    gvRemainders.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }


//    protected void gvRemainders_RowCommand(object sender, GridViewCommandEventArgs e)
//    {
//        if (e.CommandName == "Update")
//        {
//            int id = Convert.ToInt32(e.CommandArgument);


//        }
//    }
}
