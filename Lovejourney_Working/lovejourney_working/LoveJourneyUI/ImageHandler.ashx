<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

public class ImageHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        //occurs when request is from UserImageUpload page
        string imageid = context.Request.QueryString["ImID"];
        //occurs when request is from UserProfilePicturesUpload page
        string imagesid = context.Request.QueryString["ImgID"];
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        SqlCommand command = null;
        //command.CommandTimeout = 100;
        //Console.WriteLine("CommandTimeout: {0}", command.CommandTimeout);
        if (imageid != null && imageid != "")
            command = new SqlCommand("select Img from Adv_Images where ID=" + imageid, connection);
        else if (imagesid != null && imagesid != "")
            command = new SqlCommand("select FileImage from UserPictures where ID=" + imagesid, connection);
        SqlDataReader dr = command.ExecuteReader();
        if (dr.HasRows)
        {
            dr.Read();
            context.Response.BinaryWrite((Byte[])dr[0]);
            context.Response.End();
        }
        connection.Close();
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}