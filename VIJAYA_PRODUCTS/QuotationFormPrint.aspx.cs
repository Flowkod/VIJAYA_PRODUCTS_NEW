using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using SparkInventory.DAL;
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
    public partial class QuotationFormPrint : System.Web.UI.Page
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
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Quotation.rdlc");
            }

            Quotation_Management objPurchase = new Quotation_Management();
            objPurchase.Quotation_id = Convert.ToInt32(Request.QueryString["po_no"]);
            objPurchase.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            objPurchase.Sp_Operation = "GET_QUOTATION_BY_QUOTATION_NO";
            DataTable dt = new DataTable();
            dt = objPurchase.SaveUser();


            string amountinworld = obj.Rupees(Convert.ToInt64(dt.Rows[0]["GRAND_TOTAL"]));
            string TaxInWorld = obj.Rupees(Convert.ToInt64(dt.Rows[0]["GST_AMOUNT"]));

            dt.Columns.Add("TOTAL_IN_WORLD", typeof(System.String));

            dt.Columns[35].ReadOnly = false;
            dt.Rows[0]["TOTAL_IN_WORLD"] = amountinworld;
            dt.Columns.Add("TAX_IN_WORLD", typeof(System.String));

            dt.Columns[38].ReadOnly = false;
            dt.Rows[0]["TAX_IN_WORLD"] = TaxInWorld;

            Quotation_Product_Management objProduct = new Quotation_Product_Management();
            objProduct.Quotation_Id = Convert.ToInt32(Request.QueryString["po_no"]);
            objProduct.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            objProduct.Sp_Operation = "GET_PRODUCT_REPORT_BY_QUOTATION";
            DataTable dt1 = new DataTable();
            dt1 = objProduct.SaveUser();

            int count = dt1.Rows.Count;
            if (count < 5)
            {
                for (int i = count; i < 2; i++)
                {
                    DataRow dtr = dt1.NewRow();
                    //dtr[0] = string.Empty;
                    dt1.Rows.InsertAt(dtr, count);
                }
            }
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(_rsource1);

            ReportDataSource _rsource = new ReportDataSource("DataSet2", dt1);
            ReportViewer1.LocalReport.DataSources.Add(_rsource);

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

            Response.AppendHeader("Content-Disposition", "inline; filename= Quotation.pdf");
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.Flush();
            Response.End();
        }
    }
}