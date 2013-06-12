using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
using System.Text;
using System.IO;
using System.Web;

public partial class Agent_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["BusAgentStatus"] == null || Session["UserID"] == null || Session["Role"] == null) { Response.Redirect("~/Default.aspx", false); return; }


        this.Page.Title = "LoveJourney - Profile";
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                BindAgentDetails();
                imgAgentLogo.ImageUrl = "~/ActualImage.ashx?ID=" + Session["UserID"].ToString();
            }
            else { Response.Redirect("~/Default.aspx", false); }

            Panel men1 = (Panel)this.Master.FindControl("Menu1");
            men1.Visible = false;
        }
    }
    void BindAgentDetails()
    {
        try
        {
            DataTable dt = GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString())).Tables[0];
            DataRow dr = dt.Rows[0];

            DateTime dateTime = Convert.ToDateTime(dr["DOB"].ToString());
            string date = dateTime.ToString("MM/dd/yyyy");

            txtAgentName.Text = dr["AgentName"].ToString();
            ddlType.SelectedValue = ddlType.Items.FindByText(dr["Type"].ToString()).Value;
            txtDateOfBirth.Text = date;
            txtCity.Text = dr["City"].ToString();
            ddlState.SelectedValue = ddlState.Items.FindByText(dr["State"].ToString()).Value;
            txtAddress.Text = dr["Address"].ToString();
            txtPinCode.Text = dr["PinCode"].ToString();
            txtMobileNo.Text = dr["MobileNo"].ToString();
            txtAlternateMobileNo.Text = dr["AlternateMobileNo"].ToString();
            txtLandlineNo.Text = dr["LandlineNo"].ToString();
            txtEmailId.Text = dr["EmailId"].ToString();
            txtPAN.Text = dr["PANNo"].ToString();
            txtCommissionPercentage.Text = dr["CommisionPercentage"].ToString();
            txtUsername.Text = dr["Username"].ToString();
            btnRegister.CommandArgument = dr["AgentId"].ToString();
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    DataSet GetAgentByUserId(int id)
    {
        try
        {
            ClsBAL objManabusBal = new ClsBAL();
            return objManabusBal.GetAgentByUserId(id);
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            ClsBAL objManabusBal = new ClsBAL();
            string message = "";
            message = objManabusBal.UpdateAgentByAgent(txtAgentName.Text.Trim().ToString(),
                  ddlType.SelectedItem.Text.ToString(),
                  Convert.ToDateTime(txtDateOfBirth.Text.ToString()),
                  txtCity.Text.Trim().ToString(),
                  ddlState.SelectedItem.Text.ToString(),
                  txtAddress.Text.Trim().ToString(),
                  txtPinCode.Text.Trim().ToString(),
                  txtMobileNo.Text.Trim().ToString(),
                  txtAlternateMobileNo.Text.Trim().ToString(),
                  txtLandlineNo.Text.Trim().ToString(),
                  txtEmailId.Text.Trim().ToString(),
                  txtPAN.Text.Trim().ToString(),
                  "",
                  "",
                  "",
                  Convert.ToInt32(Session["UserID"].ToString()),
                  Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(txtCommissionPercentage.Text.ToString()));
            lblMsg.InnerHtml = message;
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void btnUploadImage_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != null)
            {
                ClsBAL obj = new ClsBAL();
                byte[] imageByte = null;
                if (fuImage.HasFile)
                {
                    HttpPostedFile postedFile = fuImage.PostedFile;
                    imageByte = new byte[postedFile.ContentLength];
                    if (postedFile.ContentLength > 102400)
                    { lblMsg.InnerHtml = "The size of image must be less than 100KB(102400 bytes)."; return; }
                    postedFile.InputStream.Read(imageByte, 0, postedFile.ContentLength);
                }
                lblMsg.InnerHtml = obj.InsertAgentLogo(Convert.ToInt32(Session["UserID"].ToString()), imageByte);

                Image img = (Image)this.Master.FindControl("imgAgentLogo");
                img.ImageUrl = imgAgentLogo.ImageUrl = "~/ActualImage.ashx?ID=" + Session["UserID"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
}