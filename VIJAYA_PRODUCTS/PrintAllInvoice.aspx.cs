using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using NewStarCity.DAL.PURCHASE_ORDER;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using AdeesEnergy.DAL.SendSMS;
using NewStarCity.DAL;
using YOGESH_INVOICE.DAL;
using Microsoft.Reporting.WebForms;

#endregion

namespace SparkInventory
{
    public partial class PrintAllInvoice : System.Web.UI.Page
    {
        #region "Variable"

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        public void Get()
        {
            NoInWord obj = new NoInWord();

            ReportViewer1.SizeToReportContent = true;

            if (Convert.ToInt32(Request.Cookies["SiteID"].Value) == 1)
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Invoice.rdlc");
            }

            Purches_Order_Management objPurchase = new Purches_Order_Management();

            if (Request.QueryString["po_no"]!=null)
            {
                objPurchase.Po_No = Request.QueryString["po_no"];
            }

            if (Request.QueryString["cid"]!=null)
            {
                objPurchase.Customer_id = Convert.ToInt32(Request.QueryString["cid"]);
            }

            if (Request.QueryString["from"]!=null)
            {
                objPurchase.Date = Convert.ToDateTime(Request.QueryString["from"]);
            }

            if (Request.QueryString["to"]!=null)
            {
                objPurchase.to_date = Convert.ToDateTime(Request.QueryString["to"]);
            }
           
            objPurchase.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            objPurchase.Sp_Operation = "GET_PO_FOR_PRINT";
            DataTable dt = new DataTable();
            dt = objPurchase.SaveUser();

           
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dt);
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

            Response.AppendHeader("Content-Disposition", "inline; filename=SparkInvoice");
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.Flush();
            Response.End();
        }
    }
}