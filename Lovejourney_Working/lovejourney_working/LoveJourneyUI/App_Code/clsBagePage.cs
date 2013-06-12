using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APRWorld;
using BAL;
using DAL; 
using System.Data;

namespace APRWorld
{
    /// <summary>
    /// Summary description for clsBagePage
    /// </summary>
    public class clsBagePage : System.Web.UI.Page
    {
        #region Global Variables

        clsMasters _objMasters;

       // clsMasters _objMasters;
        DataSet _objDataSet;
        #endregion

        #region Constructor
        public clsBagePage()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region LoadCity
        public void fnLocalCities(ref DropDownList ddlFrom, ref DropDownList DDLTo)
        {
            try
            {
                //Load Cities
                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.citilist;
                _objDataSet = (DataSet)_objMasters.fnGetData();

                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    //From DDL
                    ddlFrom.DataSource = _objDataSet.Tables[0];
                    ddlFrom.DataValueField = "ID";
                    ddlFrom.DataTextField = "Name";
                    ddlFrom.DataBind();
                    ddlFrom.Items.Insert(0, "From City");

                    //To DDL
                    DDLTo.DataSource = _objDataSet.Tables[0];
                    DDLTo.DataValueField = "ID";
                    DDLTo.DataTextField = "Name";
                    DDLTo.DataBind();
                    DDLTo.Items.Insert(0, "To City");
                }
            }
            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
            }
            finally
            {
                _objDataSet.Dispose();
            }

        }

        #endregion 

        #region OnLoad
        /// <summary>
        /// Objective : Onload function overriding for customization 
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SetPageTitle();
        }
        #endregion

        #region LogError
        public void LogError(String ScreenName, String MethodName, DateTime Time, String ex)
        {
            try
            {
                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.LogError;
                _objMasters.ScreenName = ScreenName.ToString();
                _objMasters.MethodName = MethodName.ToString();
                _objMasters.Time = Convert.ToDateTime(Time);
                _objMasters.Exception = ex.ToString();
                _objMasters.fnInsertRecord();
            }
            catch
            { }
        }
        #endregion  

        #region Properties
        protected virtual bool AutoSetPageTitle
        {
            get
            {
                object o = ViewState["AutoSetPageTitle"];
                if (o == null)
                    return true;
                else
                    return (bool)o;
            }
            set
            {
                ViewState["AutoSetPageTitle"] = value;
            }
        }

        protected virtual string SiteMapProvider
        {
            get
            {
                string str = ViewState["SiteMapProvider"] as string;
                if (str == null)
                    return string.Empty;
                else
                    return str;
            }
            set
            {
                ViewState["SiteMapProvider"] = value;
            }
        }

        protected virtual string SiteMapNodeSeparator
        {
            get
            {
                string str = ViewState["SiteMapNodeSeparator"] as string;
                if (str == null)
                    return " :: ";
                else
                    return str;
            }
            set
            {
                ViewState["SiteMapNodeSeparator"] = value;
            }
        }
        #endregion

        #region Check Session
        /// <summary>
        /// Objective : Function to check Session is available or not
        /// </summary>
        /// <returns>true/false</returns>
        protected bool fnCheckSession()
        {
            if (HttpContext.Current.Session.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Objective : Function to Set Page Title Dynamically
        /// </summary>
        protected virtual void SetPageTitle()
        {
            if (this.AutoSetPageTitle && (string.IsNullOrEmpty(this.Title) || string.Compare(this.Title, "Untitled Page", true) == 0))
            {
                if (SiteMap.Enabled)
                {
                    // See if this page is in the SiteMap
                    SiteMapNode current = null;

                    if (string.IsNullOrEmpty(this.SiteMapProvider))
                        current = SiteMap.CurrentNode;
                    else
                        current = SiteMap.Providers[this.SiteMapProvider].CurrentNode;

                    if (current != null)
                    {
                        // Build up the title
                        SetPageTitle(current);
                        return;
                    }
                }

                // If we reach here we still do not have a title set... use the filename
                this.Title = Path.GetFileNameWithoutExtension(Request.PhysicalPath);
            }
        }

        /// <summary>
        /// Objective : Set page title based on SiteMapNode
        /// </summary>
        /// <param name="current"></param>
        protected virtual void SetPageTitle(SiteMapNode current)
        {
            if (this.AutoSetPageTitle)
            {
                StringBuilder titleBuilder = new StringBuilder(200);
                titleBuilder.Append(current.Title);

                current = current.ParentNode;

                if (current != null)
                {
                    string parentPathReverse = current.Title;

                    while (current.ParentNode != null)
                    {
                        current = current.ParentNode;

                        parentPathReverse = string.Concat(current.Title, this.SiteMapNodeSeparator, parentPathReverse);
                    }

                    titleBuilder.Append(" (").Append(parentPathReverse).Append(")");
                }

                this.Title = titleBuilder.ToString();
            }
        }
        #endregion

        #region ShowAlert()
        /// <summary>
        /// Objective : Function to Show Alert
        /// </summary>
        /// <param name="strMessage">Message to display alert</param>
        //public void ShowAlert(string strMessage)
        //{
        //    string strJscript = string.Empty;
        //    strJscript = "<script language='javascript'>";
        //    strJscript += "alert('" + strMessage + "');";
        //    strJscript += "</script>";
        //    ClientScript.RegisterStartupScript(this.GetType(), "onclick", strJscript);
        //}


        #endregion

    }

    public static class Alert
    {

        /// <summary>
        /// Shows a client-side JavaScript alert in the browser.
        /// </summary>
        /// <param name="message">The message to appear in the alert.</param>
        public static void Show(string message)
        {
            // Cleans the message to allow single quotation marks
            string cleanMessage = message.Replace("'", "\'");
            string script = "<script type=&quot;text/javascript&quot;>alert('" + cleanMessage + "');</script>";

            // Gets the executing web page
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(typeof(Alert), "alert", script);
            }
        }
    }
}