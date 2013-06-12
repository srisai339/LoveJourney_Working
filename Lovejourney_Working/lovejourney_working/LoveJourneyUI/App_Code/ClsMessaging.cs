using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ClsMessaging
/// </summary>
public class ClsMessaging
{
    #region Declarations

    public static string ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["LoveJourney"].ConnectionString;

    #endregion

    public static DataTable ShowAdminQueries(string Option, string AssociateID, string Read_UnRead, string Queries_Responses, string FromID, string FromDate, string ToDate)
    {
        try
        {
            if (Option == "ALL")
            {
                DataTable dt = new DataTable();

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.Add("@Option", SqlDbType.VarChar);
                cmd.Parameters["@Option"].Value = Option;

                cmd.Parameters.Add("@AssoID", SqlDbType.VarChar);
                cmd.Parameters["@AssoID"].Value = System.DBNull.Value;

                cmd.Parameters.Add("@Read_UnRead", SqlDbType.VarChar);
                cmd.Parameters["@Read_UnRead"].Value = Read_UnRead;

                cmd.Parameters.Add("@Queries_Responses", SqlDbType.VarChar);
                cmd.Parameters["@Queries_Responses"].Value = Queries_Responses;

                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc_Admin_ShowAdminQueries";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                da.Dispose();
                cmd.Dispose();
                conn.Close();
                return dt;

            }
            else
            {
                DataTable dt = new DataTable();

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.Add("@Option", SqlDbType.VarChar);
                cmd.Parameters["@Option"].Value = Option;

                cmd.Parameters.Add("@AssoID", SqlDbType.VarChar);
                cmd.Parameters["@AssoID"].Value = AssociateID;

                cmd.Parameters.Add("@Read_UnRead", SqlDbType.VarChar);
                cmd.Parameters["@Read_UnRead"].Value = Read_UnRead;

                cmd.Parameters.Add("@Queries_Responses", SqlDbType.VarChar);
                cmd.Parameters["@Queries_Responses"].Value = Queries_Responses;

                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc_Admin_ShowAdminQueries";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                da.Dispose();
                cmd.Dispose();
                conn.Close();
                return dt;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public static DataTable ShowAdminStatisticsQueries(string Option, string AssociateID, string Read_UnRead, string Queries_Responses, string FromDate, string ToDate)
    {
        try
        {
            DataTable dtAll = new DataTable();
            DataTable dt = new DataTable();
            DataTable dtFinal = new DataTable();
            if (Option == "ALL")
            {
                dtFinal.Columns.Add(new DataColumn("From"));
                dtFinal.Columns.Add(new DataColumn("TotalQueriesCount"));
                if (Queries_Responses == "0")
                {
                    dtFinal.Columns.Add(new DataColumn("QueriesCount"));
                }
                else if (Queries_Responses == "1")
                {
                    dtFinal.Columns.Add(new DataColumn("ResponsesCount"));
                }
                else if (Queries_Responses == "All")
                {
                    dtFinal.Columns.Add(new DataColumn("AllCount"));
                }
                dtFinal.Columns.Add(new DataColumn("ReadCount"));
                dtFinal.Columns.Add(new DataColumn("UnReadCount"));

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.Add("@Option", SqlDbType.VarChar);
                cmd.Parameters["@Option"].Value = Option;

                cmd.Parameters.Add("@AssoID", SqlDbType.VarChar);
                cmd.Parameters["@AssoID"].Value = "";

                cmd.Parameters.Add("@replysequence", SqlDbType.VarChar);
                cmd.Parameters["@replysequence"].Value = "";

                cmd.Parameters.Add("@Read_Unread", SqlDbType.VarChar);
                cmd.Parameters["@Read_Unread"].Value = "";

                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc_Admin_ShowAdminStatisticsQueries";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtAll);
                da.Dispose();
                cmd.Dispose();
                conn.Close();

                for (int i = 0; i < dtAll.Rows.Count; i++)
                {
                    AssociateID = dtAll.Rows[i][0].ToString();

                    SqlCommand cmdAssociateID = new SqlCommand();

                    cmdAssociateID.Parameters.Add("@Option", SqlDbType.VarChar);
                    cmdAssociateID.Parameters["@Option"].Value = Option;

                    cmdAssociateID.Parameters.Add("@AssoID", SqlDbType.VarChar);
                    cmdAssociateID.Parameters["@AssoID"].Value = AssociateID;
                    
                    cmdAssociateID.Parameters.Add("@replysequence", SqlDbType.VarChar);
                    cmdAssociateID.Parameters["@replysequence"].Value = Queries_Responses;

                    cmdAssociateID.Parameters.Add("@Read_Unread", SqlDbType.VarChar);
                    cmdAssociateID.Parameters["@Read_Unread"].Value = Read_UnRead;

                    conn.Open();
                    cmdAssociateID.Connection = conn;
                    cmdAssociateID.CommandType = CommandType.StoredProcedure;
                    cmdAssociateID.CommandText = "proc_Admin_ShowAdminStatisticsQueries";
                    SqlDataAdapter da1 = new SqlDataAdapter(cmdAssociateID);
                    da1.Fill(dt);
                    da1.Dispose();
                    cmdAssociateID.Dispose();
                    conn.Close();
                    if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
                        dtFinal.Rows.Add(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString());
                    dt.Clear();
                    dt.Dispose();
                }
                dtAll.Clear();
                dtAll.Dispose();
            }
            else
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.Add("@Option", SqlDbType.VarChar);
                cmd.Parameters["@Option"].Value = Option;

                cmd.Parameters.Add("@AssoID", SqlDbType.VarChar);
                cmd.Parameters["@AssoID"].Value = AssociateID;

                cmd.Parameters.Add("@replysequence", SqlDbType.VarChar);
                cmd.Parameters["@replysequence"].Value = Queries_Responses;

                cmd.Parameters.Add("@Read_Unread", SqlDbType.VarChar);
                cmd.Parameters["@Read_Unread"].Value = Read_UnRead;

                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc_Admin_ShowAdminStatisticsQueries";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtFinal);
                da.Dispose();
                cmd.Dispose();
                conn.Close();
                return dtFinal;
            }
            return dtFinal;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static Boolean SaveAdminQueries(string QueryID, string ReplySequence, string FromID, string FromMailID, string MailBody, string ToID)
    {
        try
        {
            int ReplySeq = Convert.ToInt16(ReplySequence) + 1;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@QueryID", SqlDbType.VarChar);

            cmd.Parameters["@QueryID"].Value = QueryID;
            cmd.Parameters.Add("@ReplySequence", SqlDbType.VarChar);

            cmd.Parameters["@ReplySequence"].Value = ReplySeq;
            cmd.Parameters.Add("@FromID", SqlDbType.VarChar);

            cmd.Parameters["@FromID"].Value = FromID;
            cmd.Parameters.Add("@FromMailID", SqlDbType.VarChar);

            cmd.Parameters["@FromMailID"].Value = FromMailID;
            cmd.Parameters.Add("@MailBody", SqlDbType.VarChar);

            cmd.Parameters["@MailBody"].Value = MailBody;
            cmd.Parameters.Add("@ToID", SqlDbType.VarChar);

            cmd.Parameters["@ToID"].Value = ToID;

            SqlConnection conn = new SqlConnection(ConStr);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_Admin_SaveAdminQueries";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            return true;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public static Boolean SaveAssociateOtherQueries(string QryID, string AssociateID, string SatMailID, string Query, string ToID)
    {
        try
        {
            if (QryID == "")
            {
                QryID = Guid.NewGuid().ToString().Substring(0, 4);
            }
            return insertquery(QryID, "0", AssociateID, SatMailID, Query, 1, ToID);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static Boolean ReplyAssociateOtherQueries(string QryID, string AssociateID, string SatMailID, string Query, string ToID)
    {
        try
        {
            if (QryID == "")
            {
                QryID = Guid.NewGuid().ToString().Substring(0, 4);
            }
            return insertquery(QryID, "1", AssociateID, SatMailID, Query, 1, ToID);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static Boolean _SendMailQueries(string strmailId, string randpass, string mcc, int flag)
    {

        try
        {
            if (flag == 0)
                executeQuery("exec SP_SendMailQueries '" + strmailId + "','" + randpass + "','Users Query','" + mcc + "' ");
            else
                executeQuery("exec SP_SendMailQueries '" + strmailId + "','" + randpass + "','Admin Response','" + mcc + "' ");
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static Boolean insertquery(string QryID, string replysequence, string AssociateID, string SatMailID, string Query, int read_unread, string ToID)//created this for DBscreens naveen forupdate execise date
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@QryID", SqlDbType.VarChar);

            cmd.Parameters["@QryID"].Value = QryID;
            cmd.Parameters.Add("@replysequence", SqlDbType.VarChar);

            cmd.Parameters["@replysequence"].Value = replysequence;
            cmd.Parameters.Add("@AssociateID", SqlDbType.VarChar);

            cmd.Parameters["@AssociateID"].Value = AssociateID;
            cmd.Parameters.Add("@SatMailID", SqlDbType.VarChar);

            cmd.Parameters["@SatMailID"].Value = SatMailID;
            cmd.Parameters.Add("@Query", SqlDbType.VarChar);

            cmd.Parameters["@Query"].Value = Query;
            cmd.Parameters.Add("@read_unread", SqlDbType.VarChar);

            cmd.Parameters["@read_unread"].Value = read_unread;
            cmd.Parameters.Add("@ToID", SqlDbType.VarChar);

            cmd.Parameters["@ToID"].Value = ToID;
            SqlConnection conn = new SqlConnection(ConStr);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_clseolfunctions_insertquery";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            return true;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public static DataTable LoadAssociateOtherQueries(string AssociateID)
    {
        try
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@AssociateID", SqlDbType.VarChar);
            cmd.Parameters["@AssociateID"].Value = AssociateID;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConStr);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_admin_loadassotherqueries";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            da.Dispose();
            cmd.Dispose();
            conn.Close();
            return dt;
            //mystocksDLayer.clsDlReport.ExecuteAdapter(cmd, CommandType.StoredProcedure, "proc_admin_loadassotherqueries", ConStr).Tables[0];
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static DataTable LoadAssociateNewQueries(string AssociateID)
    {
        try
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@AssociateID", SqlDbType.VarChar);
            cmd.Parameters["@AssociateID"].Value = AssociateID;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConStr);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_admin_loadassnewqueries";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            da.Dispose();
            cmd.Dispose();
            conn.Close();
            return dt;
            //mystocksDLayer.clsDlReport.ExecuteAdapter(cmd, CommandType.StoredProcedure, "proc_admin_loadassotherqueries", ConStr).Tables[0];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static DataTable LoadAdminNewQueries()
    {
        try
        {

            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConStr);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_admin_loadadmnewqueries";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            da.Dispose();
            cmd.Dispose();
            conn.Close();
            return dt;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static Boolean executeQuery(string query)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConStr);
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
            return true;
        }

        catch (SqlException ex)
        {
            //fnLogErrorInFile("MyStocks.Connectivity", "commandexe()", ex.Message.ToString());                
            return false;
        }
    }
}
