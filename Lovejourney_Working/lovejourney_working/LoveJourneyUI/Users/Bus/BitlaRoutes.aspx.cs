using System;
using System.Data;
using BusAPILayer;
using BAL;
using System.IO;
using System.Xml;
using System.Data;
using System.Xml.Linq;
using System.Web;
using LJ.CLB.Buses;

public partial class Users_BitlaRoutes : System.Web.UI.Page
{
    ClsBAL objBAL;
    DataSet ObjDataset;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        this.Page.Title = "LoveJourney - Bus - BitlaRoutes";

        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                CheckPermission("Bitla Routes", Session["Role"].ToString());

                divroutes.Visible = true;
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }

        }
    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            pnlMain.Visible = true;
            tdmsg.Style.Add("background-color:#E77471;", "");
            lblMainMsg.Text = " No Permission to this page. Please contact Administrator for further details.";
            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                pnlMain.Visible = false;

                ClsBAL objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(Session["UserID"]);
                objBAL.screenName = pageName;
                DataSet objDataSet = (DataSet)objBAL.GetPerByUser();
                if (objDataSet != null)
                {
                    if (objDataSet.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UserPermissions"] = objDataSet.Tables[0];
                        ViewState["Book"] = objDataSet.Tables[0].Rows[0]["Book"].ToString();
                    }
                    else { ViewState["UserPermissions"] = null; }
                }
                else { ViewState["UserPermissions"] = null; }

                if (ViewState["UserPermissions"] != null)
                {
                    if (ViewState["Book"] != null)
                    {
                        if (ViewState["Book"].ToString() == "1")
                        {
                            pnlMain.Visible = true;
                            tdmsg.Visible = false;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet DsSub = new DataSet();
            string JourneyDate = txtDate.Text.ToString();
            BitlaAPI objbitla = new BitlaAPI();
            IBitlaAPILayer objBitlaAPILayer = null;
            objBitlaAPILayer = new BitlaAPILayer();
            objBitlaAPILayer.URL = BitlaConstants.URL;
            objBitlaAPILayer.ApiKey = BitlaConstants.API_KEY;
            objBitlaAPILayer.Date = JourneyDate;
            DataSet dsBitlaAllAvailableRoutes = null;

            dsBitlaAllAvailableRoutes = objbitla.GetAllAvailableRoutes(objBitlaAPILayer.URL,objBitlaAPILayer.ApiKey, objBitlaAPILayer.Date);
            dsBitlaAllAvailableRoutes.WriteXml(Server.MapPath("~/Routes/" + JourneyDate + ".xml"));
            lblMsg.Text = " Submitted. ";
            XmlDataDocument XmlDocRef = new XmlDataDocument();
            // StreamWriter XmlDataRef = new StreamWriter(Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data\\XMLfiles\\" + "RefCallback.xml"), false);
            XmlDocRef.Load(Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data\\XMLfiles\\" + "RefCallback.xml"));
            foreach (DataRow row in dsBitlaAllAvailableRoutes.Tables[1].Rows)
            {
                string DirectoryPath = Server.MapPath("~/App_Data/XMLfiles");
                DirectoryInfo dir = new DirectoryInfo(DirectoryPath);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                string filepath = "~/App_Data/XMLfiles/" + "RefCallback.xml";
                string DirectoryPath1 = Server.MapPath(filepath);
                DirectoryInfo dir1 = new DirectoryInfo(DirectoryPath1);

                if (dir1.Exists == true)
                {
                    DataSet ds1 = new DataSet();
                    DataTable dt = new DataTable("Refcal");
                    dt.Columns.Add("Date");
                    dt.Columns.Add("id");
                    dt.Columns.Add("travel_id");
                    dt.Columns.Add("reservation_id");
                    DataRow dr1;
                    dr1 = dt.NewRow();
                    dr1["Date"] = JourneyDate;
                    dr1["id"] = row["reservation_id"];
                    dr1["travel_id"] = row["travel_id"];
                    dr1["reservation_id"] = row["reservation_id"];
                    dt.Rows.Add(dr1);
                    ds1.Tables.Add(dt);
                    ds1.EnforceConstraints = false;
                    XmlDataDocument XmlDoc = new XmlDataDocument(ds1);
                    // Write down the XML declaration
                    // XmlDeclaration xmlDeclaration = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                    // Create the root element
                    //XmlElement rootNode = XmlDoc.CreateElement("CallBack");
                    //XmlDoc.InsertBefore(xmlDeclaration, XmlDoc.DocumentElement);
                   // XmlDoc.AppendChild(rootNode);
                    XmlDoc.Save(Server.MapPath(filepath));

                }
                else
                {
                    //create node and add value
                    XmlNode node = XmlDocRef.CreateNode(XmlNodeType.Element, "Refcal", null);
                    node.InnerXml = "<Date>" + JourneyDate + "</Date><id>" + row["id"] + "</id><travel_id>" + row["travel_id"] + "</travel_id><reservation_id>" + row["reservation_id"] + "</reservation_id>";
                    //add to elements collection
                    XmlDocRef.DocumentElement.AppendChild(node);
                    //DsSub.ReadXml(Server.MapPath("~/App_Data/XMLfiles/" + "RefCallback.xml"));
                    //DataRow dr;
                    //dr = DsSub.Tables[0].NewRow();
                    //dr["Date"] = JourneyDate;
                    //dr["id"] = row["id"];
                    //dr["travel_id"] = row["travel_id"];
                    //dr["reservation_id"] = row["reservation_id"];
                    //DsSub.Tables[0].Rows.Add(dr);
                }
           
            }
            XmlDocRef.Save(Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data\\XMLfiles\\" + "RefCallback.xml"));
            //DataSet ds2 = new DataSet();
            //ds2.EnforceConstraints = false;
            //XmlDataDocument XmlDoc1 = new XmlDataDocument(ds2);
            //StreamWriter XmlData1 = new StreamWriter(Server.MapPath("~/App_Data/XMLfiles/" + "RefCallback.xml"), false);
            //DsSub.WriteXml(XmlData1);
            //XmlData1.Close();


          
        }
        catch (Exception)
        {
           // throw;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath("~/Routes"));
            FileInfo[] fileInfo = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);

            string FileToDelete = "";
            FileToDelete = Server.MapPath("~/Routes/2012-08-02.xml");
            //File.Delete(Server.MapPath("~/Routes/2012-08-02.xml").ToString());

            StreamWriter sw = new StreamWriter(Server.MapPath("~/Routes/2012-08-02.xml"));
            sw.Write("del " + Server.MapPath("~/Routes/2012-08-02.xml"));
            sw.Close();
            System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo(Server.MapPath("~/Routes/2012-08-02.xml").ToString());
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = p;
            proc.Start();
            proc.WaitForExit();

        }
        catch (Exception)
        {
            throw;
        }
    }
}