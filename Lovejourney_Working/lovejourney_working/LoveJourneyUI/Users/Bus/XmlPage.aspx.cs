using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Xml;

public partial class Users_Bus_XmlPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    public void FnLocationtoXml()
    {
        string Constring = System.Configuration.ConfigurationManager.ConnectionStrings["LoveJourney"].ConnectionString;
        SqlConnection con = new SqlConnection(Constring);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_WebAPI_GetCities", con);
            cmd.CommandType = CommandType.StoredProcedure;
          //  cmd.Parameters.Add("@TableName", "DomAirportCodes");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DsLoc = new DataSet();
            da.Fill(DsLoc);

            string DirectoryPath = Server.MapPath("~/App_Data");
            DirectoryInfo dir = new DirectoryInfo(DirectoryPath);
            if (!dir.Exists)
            {
                dir.Create();
            }
            string filepath = "~/App_Data/" + "Buses.xml";
            string DirectoryPath1 = Server.MapPath(filepath);
            DirectoryInfo dir1 = new DirectoryInfo(DirectoryPath1);
            if (!dir1.Exists)
            {
                DataSet ds1 = new DataSet();
                ds1.EnforceConstraints = false;
                XmlDataDocument XmlDoc = new XmlDataDocument(ds1);
                // Write down the XML declaration
                XmlDeclaration xmlDeclaration = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                // Create the root element
                XmlElement rootNode = XmlDoc.CreateElement("Buses");
                XmlDoc.InsertBefore(xmlDeclaration, XmlDoc.DocumentElement);
                XmlDoc.AppendChild(rootNode);
                XmlDoc.Save(Server.MapPath(filepath));

            }


            StreamWriter XmlData = new StreamWriter(Server.MapPath("~/App_Data/" + "Buses.xml"), false);
            DsLoc.WriteXml(XmlData);
            XmlData.Close();
            lblmsg.Visible = true;
            lblmsg.Text = " All Buses list Uploaded to XML Successfully";

        }
        finally
        {
            con.Close();
        }

    }
    public void FnAPIProviderstoXml()
    {
        string Constring = System.Configuration.ConfigurationManager.ConnectionStrings["LoveJourney"].ConnectionString;
        SqlConnection con = new SqlConnection(Constring);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getAPIProviders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TableName", "getAPIProvider");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DsLoc = new DataSet();
            da.Fill(DsLoc);

            string DirectoryPath = Server.MapPath("~/App_Data");
            DirectoryInfo dir = new DirectoryInfo(DirectoryPath);
            if (!dir.Exists)
            {
                dir.Create();
            }
            string filepath = "~/App_Data/" + "APIProviders.xml";
            string DirectoryPath1 = Server.MapPath(filepath);
            DirectoryInfo dir1 = new DirectoryInfo(DirectoryPath1);
            if (!dir1.Exists)
            {
                DataSet ds1 = new DataSet();
                ds1.EnforceConstraints = false;
                XmlDataDocument XmlDoc = new XmlDataDocument(ds1);
                // Write down the XML declaration
                XmlDeclaration xmlDeclaration = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                // Create the root element
                XmlElement rootNode = XmlDoc.CreateElement("APIProviders");
                XmlDoc.InsertBefore(xmlDeclaration, XmlDoc.DocumentElement);
                XmlDoc.AppendChild(rootNode);
                XmlDoc.Save(Server.MapPath(filepath));

            }


            StreamWriter XmlData = new StreamWriter(Server.MapPath("~/App_Data/" + "APIProviders.xml"), false);
            DsLoc.WriteXml(XmlData);
            XmlData.Close();
            lblmsg.Visible = true;
            lblmsg.Text = " All Buses list Uploaded to XML Successfully";

        }
        finally
        {
            con.Close();
        }

    }
    public void FnRSourcesAPIoXml()
    {
        string Constring = System.Configuration.ConfigurationManager.ConnectionStrings["LoveJourney"].ConnectionString;
        SqlConnection con = new SqlConnection(Constring);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getAPIProviders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TableName", "getRSourceAPI");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DsLoc = new DataSet();
            da.Fill(DsLoc);

            string DirectoryPath = Server.MapPath("~/App_Data");
            DirectoryInfo dir = new DirectoryInfo(DirectoryPath);
            if (!dir.Exists)
            {
                dir.Create();
            }
            string filepath = "~/App_Data/" + "SourcesAPI.xml";
            string DirectoryPath1 = Server.MapPath(filepath);
            DirectoryInfo dir1 = new DirectoryInfo(DirectoryPath1);
            if (!dir1.Exists)
            {
                DataSet ds1 = new DataSet();
                ds1.EnforceConstraints = false;
                XmlDataDocument XmlDoc = new XmlDataDocument(ds1);
                // Write down the XML declaration
                XmlDeclaration xmlDeclaration = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                // Create the root element
                XmlElement rootNode = XmlDoc.CreateElement("SourcesAPI");
                XmlDoc.InsertBefore(xmlDeclaration, XmlDoc.DocumentElement);
                XmlDoc.AppendChild(rootNode);
                XmlDoc.Save(Server.MapPath(filepath));

            }


            StreamWriter XmlData = new StreamWriter(Server.MapPath("~/App_Data/" + "SourcesAPI.xml"), false);
            DsLoc.WriteXml(XmlData);
            XmlData.Close();
            lblmsg.Visible = true;
            lblmsg.Text = " All Buses list Uploaded to XML Successfully";

        }
        finally
        {
            con.Close();
        }

    }
    protected void btnclikc_Click(object sender, EventArgs e)
    {
        try
        {
            FnLocationtoXml();
            FnAPIProviderstoXml();
            FnRSourcesAPIoXml();
        }
        catch (Exception ex)
        {

            //throw;
        }
    }
}