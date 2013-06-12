using System;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Role"] != null)
        //{
        //    ShowMenu(Session["Role"].ToString());
        //}
        //else { ShowMenu("Guest"); }
        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "Agent")
                {
                    //Response.Redirect("~/Agent/Masters/AgentDashBoard.aspx", false);
                }
                else if (Session["Role"].ToString() == "Admin")
                {
                    ///Response.Redirect("~/Users/AdminDb/AdminDb.aspx", false);
                }
            }
        }
    }
    void ShowMenu(string role)
    {
        try
        {
            //GuestMenu.Visible = AdminMenu.Visible = AgentMenu.Visible = UserMenu.Visible = footerMenu.Visible = false;
            ////lblUsername.Text = role;
            //if (role == "Admin") { AdminMenu.Visible = true; }
            //else if (role == "Agent") { AgentMenu.Visible = true; }
            //else if (role == "User") { UserMenu.Visible = true; }
            //else if (role == "Guest") { GuestMenu.Visible = true; footerMenu.Visible = true; }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
