using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using YOGESH_INVOICE.DAL;
using Microsoft.Reporting.WebForms;
using SparkInventory.DAL;

#endregion

namespace SparkInventory
{
    public partial class CashMemoPrint : System.Web.UI.Page
    {
        public void Get()
        {
            NoInWord obj = new NoInWord();

            ReportViewer1.SizeToReportContent = true;

            if (Convert.ToInt32(Request.Cookies["SiteID"].Value) == 1)
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CashMemoReceipt.rdlc");
            }

            Cash_Memo_Management objCashMemo = new Cash_Memo_Management();

            if (Request.QueryString["cashmemo"] != null)
            {
                objCashMemo.Cash_Memo_id = Convert.ToInt32(Request.QueryString["cashmemo"]);
            }

            if (Request.QueryString["from"] != null)
            {
                objCashMemo.date = Convert.ToDateTime(Request.QueryString["from"]);
            }

            if (Request.QueryString["to"] != null)
            {
                objCashMemo.ToDate = Convert.ToDateTime(Request.QueryString["to"]);
            }

            objCashMemo.SpOperation = "SELECT_FOR_PRINT";
            DataTable dtCashMemo = new DataTable();
            dtCashMemo= objCashMemo.SaveCashMemo();           
            
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dtCashMemo);
            ReportViewer1.LocalReport.DataSources.Add(_rsource1);          

            ReportViewer1.LocalReport.Refresh();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Get();
            }

            Warning[] warnings;
            string[] streamIds;
            string mimeType = "application/pdf";
            string encoding = string.Empty;
            string extension = string.Empty;

            byte[] bytes = ReportViewer1.LocalReport.Render(
                "PDF",
                null,
                out mimeType,
                out encoding,
                out extension,
                out streamIds,
                out warnings);

            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;

            Response.AppendHeader("Content-Disposition", "inline; filename=CashMemo");
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.Flush();
            Response.End();
        }
    }
}