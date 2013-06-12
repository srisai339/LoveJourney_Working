using System;
using System.Net;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;

public partial class ebs_pay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Url = "https://secure.ebs.in/pg/ma/sale/pay/";
        string Method = "post";
        string FormName = "form1";
       // string secret_key = "ebskey";
        string secret_key = "91fd335602ba035c96e9ec6f427082aa";//91fd335602ba035c96e9ec6f427082aa
        string account_id = Request.Form["account_id"];
        string amount = Request.Form["amount"];
        string reference_no = Request.Form["reference_no"];
        string mode = Request.Form["mode"];
        string return_url = Request.Form["return_url"];

        string input = secret_key + "|" + account_id + "|" + amount + "|" + reference_no + "|" + return_url + "|" + mode;

        MD5 md5 = MD5.Create();

        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

        byte[] hashBytes = md5.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }

        string secure_hash = sb.ToString();

        NameValueCollection FormFields = new NameValueCollection();
        FormFields.Add("account_id", Request.Form["account_id"]);
        FormFields.Add("reference_no", Request.Form["reference_no"]);
        FormFields.Add("amount", Request.Form["amount"]);
        FormFields.Add("description", Request.Form["description"]);
        FormFields.Add("name", Request.Form["name"]);
        FormFields.Add("address", Request.Form["address"]);
        FormFields.Add("city", Request.Form["city"]);
        FormFields.Add("state", Request.Form["state"]);
        FormFields.Add("postal_code", Request.Form["postal_code"]);
        FormFields.Add("country", Request.Form["country"]);
        FormFields.Add("email", Request.Form["email"]);
        FormFields.Add("phone", Request.Form["phone"]);
        FormFields.Add("ship_name", Request.Form["ship_name"]);
        FormFields.Add("ship_address", Request.Form["ship_address"]);
        FormFields.Add("ship_city", Request.Form["ship_city"]);
        FormFields.Add("ship_state", Request.Form["ship_state"]);
        FormFields.Add("ship_postal_code", Request.Form["ship_postal_code"]);
        FormFields.Add("ship_country", Request.Form["ship_country"]);
        FormFields.Add("ship_phone", Request.Form["ship_phone"]);
        FormFields.Add("return_url", Request.Form["return_url"]);
        FormFields.Add("mode", Request.Form["mode"]);
        FormFields.Add("secure_hash", secure_hash);

        Response.Clear();
        Response.Write("<html><head>");
        Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
        Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
        for (int i = 0; i < FormFields.Keys.Count; i++)
        {
            Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", FormFields.Keys[i], FormFields[FormFields.Keys[i]]));
        }
        Response.Write("</form>");
        Response.Write("</body></html>");
        Response.End();
    }
}