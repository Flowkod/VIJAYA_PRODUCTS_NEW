using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YOGESH_INVOICE.DAL;
using VIJAYA_PRODUCTS.DAL;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;

namespace VIJAYA_PRODUCTS
{
    public partial class ShopInvPrint : System.Web.UI.Page
    {
        public void Get()
        {
            NoInWord obj = new NoInWord();

            ReportViewer1.SizeToReportContent = true;

            
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ShopInvoice.rdlc");
         

           Invoice_Management  objPurchase = new Invoice_Management();
            objPurchase.Invoice_Id = Convert.ToInt32(Request.QueryString["inv"]);
            objPurchase.Sp_Operation = "GET_INVOICE_REPORT";
            DataTable dt = new DataTable();
            dt = objPurchase.SaveUser();

            string amountinworld = obj.Rupees(Convert.ToInt64(dt.Rows[0]["GRAND_TOTAL"]));
           

            dt.Columns.Add("TOTAL_IN_WORD", typeof(System.String));

            //dt.Columns[19].ReadOnly = false;
            dt.Rows[0]["TOTAL_IN_WORD"] = amountinworld;

            Invoice_Product_Management objPro = new Invoice_Product_Management();
            objPro.Invoice_Id= Convert.ToInt32(Request.QueryString["inv"]);
            objPro.Sp_Operation = "GET_IVOICE_PRODUCT_REPORT";
            DataTable dt1 = new DataTable();
            dt1 = objPro.SaveUser();



            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(_rsource1);

            ReportDataSource _rsource2 = new ReportDataSource("DataSet2", dt1);
            ReportViewer1.LocalReport.DataSources.Add(_rsource2);

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