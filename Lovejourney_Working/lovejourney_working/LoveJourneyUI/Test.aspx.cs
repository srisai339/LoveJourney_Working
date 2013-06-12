using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusAPILayer;
using System.Text;
using System.Net;
using System.Data;
using System.IO;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            Session["Role"] = Request["Role"].ToString();
            Response.Redirect("Default.aspx");
        }

        //DataSet ds = new DataSet();
        //ds.ReadXml("E:\\Response.xml");
        //BitlaAPILayer objBitlaAPILayer = new BitlaAPILayer();
        //objBitlaAPILayer.URL = BitlaConstants.URL;
        //objBitlaAPILayer.ApiKey = BitlaConstants.API_KEY;
        //objBitlaAPILayer.ReservationId = "36943";
        //DataSet ddd = objBitlaAPILayer.GetServiceDetails();
    }
}