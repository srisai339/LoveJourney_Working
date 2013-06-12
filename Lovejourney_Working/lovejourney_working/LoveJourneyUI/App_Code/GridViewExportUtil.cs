using System;
using System.Data;
using System.Configuration; 
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using Microsoft.Office.Tools.Word;
using iTextSharp.text;
using iTextSharp.text.xml;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
//using Word = Microsoft.Office.Interop.Word;
using System.Text;



/// <summary>
/// 
/// </summary>
public class GridViewExportUtil
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="gv"></param>

    public static DataTable GetNewExportTable(DataTable oldTable, string[] arr)
    {
        try
        {
            DataTable dtNew = oldTable.Clone();

            for (int j = 0; j < oldTable.Rows.Count; j++)
            {
                dtNew.ImportRow(oldTable.Rows[j]);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                dtNew.Columns.Remove(arr[i].ToString());
            }
            return dtNew;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void ExportToExcel(string fileName, DataTable dt, bool includeGridLines)
    {
        #region OldCode
        //try
        //{
        //    HttpContext.Current.Response.Clear();
        //    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
        //    HttpContext.Current.Response.ContentType = "application/ms-excel";

        //    using (StringWriter sw = new StringWriter())
        //    {
        //        using (HtmlTextWriter htw = new HtmlTextWriter(sw))
        //        {
        //            //  Create a form to contain the grid
        //            Table table = new Table();
        //            if (includeGridLines)
        //            {
        //                table.GridLines = gv.GridLines;
        //            }

        //            //  add the header row to the table
        //            if (gv.HeaderRow != null)
        //            {
        //                GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
        //                table.Rows.Add(gv.HeaderRow);
        //            }

        //            //  add each of the data rows to the table
        //            foreach (GridViewRow row in gv.Rows)
        //            {
        //                GridViewExportUtil.PrepareControlForExport(row);
        //                table.Rows.Add(row);
        //            }

        //            //  add the footer row to the table
        //            if (gv.FooterRow != null)
        //            {
        //                GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
        //                table.Rows.Add(gv.FooterRow);
        //            }

        //            //  render the table into the htmlwriter
        //            table.RenderControl(htw);

        //            //  render the htmlwriter into the response
        //            HttpContext.Current.Response.Write(sw.ToString());
        //            HttpContext.Current.Response.End();
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        #endregion
        try
        {


            string attachment = "attachment; filename=" + fileName;

            HttpContext.Current.Response.ClearContent();


            HttpContext.Current.Response.AddHeader("content-disposition", attachment);

            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";

            string tab = "";

            foreach (DataColumn dc in dt.Columns)
            {

                HttpContext.Current.Response.Write(tab + dc.ColumnName);

                tab = "\t";

            }
            HttpContext.Current.Response.Write("\n");

            int i;

            foreach (DataRow dr in dt.Rows)
            {

                tab = "";

                for (i = 0; i < dt.Columns.Count; i++)
                {

                    HttpContext.Current.Response.Write(tab + dr[i].ToString());

                    tab = "\t";

                }

                HttpContext.Current.Response.Write("\n");

            }

            HttpContext.Current.Response.End();
        }
        catch (System.Threading.ThreadAbortException lException)
        {

            // do nothing

        }
    }

    public static void ExportToPDF(string fileName, GridView GridView1, bool includeGridLines, DataTable dt, string title)
    {
        try
        {

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = String.Empty;

            HttpContext.Current.Response.ContentType = "application/pdf";

            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename='" + fileName + "'");

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();

            HtmlTextWriter hw = new HtmlTextWriter(sw);



            GridView1.DataSource = dt;
            GridView1.DataBind();


            GridView1.RenderControl(hw);

            StringReader sr = new StringReader(sw.ToString());

            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A2, 7f, 7f, 7f, 0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);


            pdfDoc.Open();


            Chunk c = new Chunk(title + "\n\n", FontFactory.GetFont("Verdana", 15));
            Paragraph p = new Paragraph();
            p.Alignment = Element.ALIGN_CENTER;
            p.Add(c);


            pdfDoc.Add(p);

            htmlparser.Parse(sr);

            pdfDoc.Close();

            HttpContext.Current.Response.Write(pdfDoc);

            HttpContext.Current.Response.End();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static void ExportToCSV(string fileName, GridView GridView1, DataTable dt, string title)
    {
        try
        {
            HttpContext.Current.Response.Clear();

            HttpContext.Current.Response.Buffer = true;

            HttpContext.Current.Response.AddHeader("content-disposition",

             "attachment;filename=GridViewExport.csv");

            HttpContext.Current.Response.Charset = "";

            HttpContext.Current.Response.ContentType = "application/text";

            GridView1.AllowPaging = false;

            GridView1.DataBind();

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < GridView1.Columns.Count; k++)
            {

                //add separator

                sb.Append(GridView1.Columns[k].HeaderText + ',');

            }

            //append new line

            sb.Append("\r\n");

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                for (int k = 0; k < GridView1.Columns.Count; k++)
                {

                    //add separator

                    sb.Append(GridView1.Rows[i].Cells[k].Text + ',');

                }

                //append new line

                sb.Append("\r\n");

            }

            HttpContext.Current.Response.Output.Write(sb.ToString());

            HttpContext.Current.Response.Flush();

            HttpContext.Current.Response.End();



        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Replace any of the contained controls with literals
    /// </summary>
    /// <param name="control"></param>
    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }
            else if (current is Button)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as Button).Text));
            }

            if (current.HasControls())
            {
                GridViewExportUtil.PrepareControlForExport(current);
            }
        }
    }

    public static void Export(string fileName, GridView gv, bool includeGridLines)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a form to contain the grid
                Table table = new Table();
                if (includeGridLines)
                {
                    table.GridLines = gv.GridLines;
                }

                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                //  add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    GridViewExportUtil.PrepareControlForExport(row);
                    table.Rows.Add(row);
                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

  

}
