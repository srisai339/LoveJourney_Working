using System;
using System.IO;
using System.Text;
using System.Web;
using BAL;
using System.Xml;
using System.Data;
using System.Xml.Linq;

public partial class BitlaCallBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string httpMethod = HttpContext.Current.Request.HttpMethod.ToString();
        if (httpMethod.ToUpper().ToString() == "POST")
        {
            StringBuilder sb = new StringBuilder();
            int streamRead;
            Stream s = HttpContext.Current.Request.InputStream;
            Byte[] streamArray = new Byte[Convert.ToInt32(s.Length)];
            streamRead = s.Read(streamArray, 0, Convert.ToInt32(s.Length));
            for (int i = 0; i < Convert.ToInt32(s.Length); i++)
            {
                sb.Append(Convert.ToChar(streamArray[i]));
            }
            string strRequestBody = sb.ToString();

            string[] strValues = strRequestBody.Split('&');
            string travel_id = ""; string sync_reservation_ids = "";

            if (strValues.Length >= 1)
            {
                if (strValues[0].ToString().Split('=')[1] != null)
                {
                    sync_reservation_ids = strValues[0].ToString().Split('=')[1].ToString();
                }
            }
            if (strValues.Length >= 2)
            {
                if (strValues[1].ToString().Split('=')[1] != null)
                {
                    travel_id = strValues[1].ToString().Split('=')[1].ToString();
                }
            }
            string DirectoryPath = Server.MapPath("~/App_Data/XMLfiles");
            DirectoryInfo dir = new DirectoryInfo(DirectoryPath);
            if (!dir.Exists)
            {
                dir.Create();
            }
            string filepath = "~/App_Data/XMLfiles/" + "Callback.xml";
            string DirectoryPath1 = Server.MapPath(filepath);
            DirectoryInfo dir1 = new DirectoryInfo(DirectoryPath1);
            if (dir1.Exists == true)
            {
                DataSet ds1 = new DataSet();
                ds1.EnforceConstraints = false;
                XmlDataDocument XmlDoc = new XmlDataDocument(ds1);
                // Write down the XML declaration
                // XmlDeclaration xmlDeclaration = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                // Create the root element
                XmlElement rootNode = XmlDoc.CreateElement("CallBack");
                //XmlDoc.InsertBefore(xmlDeclaration, XmlDoc.DocumentElement);
                XmlDoc.AppendChild(rootNode);
                XmlDoc.Save(Server.MapPath(filepath));

            }
            XmlTextReader refreader = new XmlTextReader(Server.MapPath("~/App_Data/XMLfiles/" + "Callback.xml"));
            refreader.Read();
            XmlDocument Refdoc = new XmlDocument();
            Refdoc.Load(refreader);
            refreader.Close();
           string[] reservations= sync_reservation_ids.Split(',');
           foreach (string res in reservations)
           {
               XmlNode Refnode;
               XmlElement Refroot = Refdoc.DocumentElement;
               Refnode = Refroot.SelectSingleNode("/NewDataSet/callback[sync_reservation_ids='" + res + "']");
               if (Refnode != null) { Refnode.ParentNode.RemoveChild(Refnode); }

               //create node and add value
               XmlNode node = Refdoc.CreateNode(XmlNodeType.Element, "callback", null);
               node.InnerXml = "<travel_id>" + travel_id + "</travel_id><sync_reservation_ids>" + res + "</sync_reservation_ids><status>" + 0 + "</status><date>" + System.DateTime.Now + "</date>";
               //add to elements collection
               Refdoc.DocumentElement.AppendChild(node);
               
           }
           Refdoc.Save(Server.MapPath("~/App_Data/XMLfiles/" + "Callback.xml"));
            //ClsBAL obj = new ClsBAL();
           // bool b = obj.BitlaCallback("", strRequestBody);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.StatusCode = 200;
            Response.Write("OK");

        }

      
 
       

    }
}