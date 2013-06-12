<%@ WebHandler Language="C#" Class="ActualImage" %>

using System;
using System.Web;
using System.Data;
using BAL;

public class ActualImage : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        String imageID = context.Request.QueryString["ID"];
        Byte[] imageBytes;
        {
            ClsBAL obj = new ClsBAL();
            
            DataTable dt = obj.GetAgentLogo(Convert.ToInt32(imageID)).Tables[0];

            imageBytes = (byte[])dt.Rows[0]["AgentLogo"];
        }
        context.Response.ContentType = "image/pjpeg";
        context.Response.AppendHeader("Content-Disposition", "filename=" + "AgentLogo" + ";");
        context.Response.Cache.SetCacheability(HttpCacheability.Public);
        context.Response.BufferOutput = false;
        context.Response.OutputStream.Write(imageBytes, 0, imageBytes.Length);
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}