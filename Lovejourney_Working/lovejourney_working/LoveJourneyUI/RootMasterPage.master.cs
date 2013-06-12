using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class RootMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowMenu("Guest");
    }
    void ShowMenu(string role)
    {
        try
        {
            Guest.Visible = Admin.Visible = Agent.Visible = User.Visible = false;
            if (role == "Admin") { Admin.Visible = true; }
            else if (role == "CSE") { Admin.Visible = true; }
            else if (role == "Agent") { Agent.Visible = true; }
            else if (role == "User") { User.Visible = true; }
            else if (role == "Guest") { Guest.Visible = true; }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "Log out")
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    Session["UserID"] = null;
                    Session.Abandon();
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
