using System;
using System.Net;
using System.IO;
using System.Data;
using System.Xml;


/// <summary>
/// Summary description for RechargerajaAPI
/// </summary>
public class RechargerajaAPI
{
	public RechargerajaAPI()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = ListProducts("655A4A5476B1CE78", "10");
    }

    public DataSet ListProducts(string guid, string baskedId)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create
            ("http://staging.buysmart.co.in/hydrasales/services/thirdpartyapi.asmx/ListProducts?GUID=" + guid + "&basketID=" + baskedId);
        request.Method = "GET";
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        DataSet ds = null;
        if (response.StatusCode == HttpStatusCode.OK)
        {
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string responseData = responseReader.ReadToEnd();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseData);
            XmlNodeReader xmlReader = new XmlNodeReader(doc);
            ds = new DataSet();
            ds.ReadXml(xmlReader);
        }
        return ds;
    }

}