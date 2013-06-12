using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using APRWorld;
using BAL;
using System.Data;
using System.Drawing;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Text;
using System.Web.Security;
using System.Drawing.Design;
using COM;
using System.Data.SqlClient;
using System;
using System.Xml;

public partial class Agent_Recharge_RechargeStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnlstatus_Click(object sender, EventArgs e)
    {
        string Hash = "10118" + txtstatus.Text + "A8JW8FX7KQ7PY5ZT2S1V";
        string Pwhash  = FormsAuthentication.HashPasswordForStoringInConfigFile(Hash,"sha1");

         HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/RealStatus");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string postData = "PartnerId=10118&TransId=" + txtstatus.Text + "&Hash=" + Pwhash;
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
            string[] s = result.Split('|');

            lblmsg.Visible = true;
            lblmsg.Text = s[4].ToString();

            if (s[4].ToString().Trim() == "Transaction Successful")
            {
                lblmsg.Text = "Successfully Recharge";
            }

            stream.Dispose();
            reader.Dispose();

        
   

       
      //  HttpWebRequest request = (HttpWebRequest)WebRequest.Create
      //("http://api.buysmart.co.in/hydrasales/services/thirdpartyapi.asmx/TransactionStatus?GUID=" + "FCC4FE618FD28CE4" + "&UID=" + txtstatus.Text);
      //  request.Method = "GET";
      //  HttpWebResponse response = (HttpWebResponse)request.GetResponse();
      //  DataSet ds4 = null;
      //  if (response.StatusCode == HttpStatusCode.OK)
      //  {
      //      StreamReader responseReader = new StreamReader(response.GetResponseStream());
      //      string responseData = responseReader.ReadToEnd();
      //      XmlDocument doc = new XmlDocument();
      //      doc.LoadXml(responseData);
      //      XmlNodeReader xmlReader = new XmlNodeReader(doc);
      //      ds4 = new DataSet();
      //      ds4.ReadXml(xmlReader);


        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create
        //  ("http://api.buysmart.co.in/hydrasales/services/thirdpartyapi.asmx/TransactionStatus?GUID=" + "FCC4FE618FD28CE4" + "&UID=" + txtstatus.Text);
        //request.Method = "GET";
        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //DataSet ds4 = null;
        //if (response.StatusCode == HttpStatusCode.OK)
        //{
        //    StreamReader responseReader = new StreamReader(response.GetResponseStream());
        //    string responseData = responseReader.ReadToEnd();
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(responseData);
        //    XmlNodeReader xmlReader = new XmlNodeReader(doc);
        //    ds4 = new DataSet();
        //    ds4.ReadXml(xmlReader);

          // Session["GetStatus"] = ds4.Tables["TransactionDetails"].Rows[0]["TransactionStatus"].ToString();
            //if (Session["GetStatus"].ToString() == "Error")
            //{
            //    lblmsg.Visible = true;
            //    lblmsg.Text = "Error";

            //}
            //else if (Session["GetStatus"].ToString() == "Success")
            //{
            //    lblmsg.Visible = true;
            //    lblmsg.Text = "Recharge Successfully";
            //}
            //else if (Session["GetStatus"].ToString() == "Failed")
            //{
            //    lblmsg.Visible = true;
            //    lblmsg.Text = "Recharge Failure";
            //}


        }
    
}