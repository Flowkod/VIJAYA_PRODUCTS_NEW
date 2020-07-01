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
using VIJAYA_PRODUCTS.DAL;

#endregion

namespace VIJAYA_PRODUCTS
{
    public partial class ShopInvoice_Report : System.Web.UI.Page
    {
        #region "Public Function"

        public void GetReport()
        {
            try
            {
                Invoice_Management objInvoice = new Invoice_Management();
                if(txtInvoiceNo.Text != "")
                {
                    objInvoice.Invoice_No = txtInvoiceNo.Text;
                }

                if (txtFromDate.Text != "")
                {
                    objInvoice.Date = Convert.ToDateTime(txtFromDate.Text);
                }

                if (txttoDate.Text != "")
                {
                    objInvoice.To_date = Convert.ToDateTime(txttoDate.Text);
                }
                objInvoice.Sp_Operation = "GET_INVOICE_BY_INVOICE_NO";
                DataTable DtInvoice = new DataTable();
                DtInvoice = objInvoice.SaveUser();

                if (DtInvoice.Rows.Count == 0)
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningOk();</script>");
                }

                grdPOReport.DataSource = DtInvoice;
                grdPOReport.DataBind();

              

                Session["DataSource"] = DtInvoice;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteInvoice(int id)
        {
            Invoice_Management objinv = new Invoice_Management();
            objinv.Invoice_Id = id;
            DataTable DTDelete = new DataTable();
            objinv.Sp_Operation = "DELETE_INVOICE";
            DTDelete = objinv.SaveUser();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            GetReport();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetReport();
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string InvoiceNo = grdPOReport.DataKeys[selRowIndex].Value.ToString();

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "newpage", "customOpen('ShopInvPrint.aspx?inv=" + InvoiceNo + "');", true);
        }
        protected void btnDeleteConfirm(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdPOReport.DataKeys[selRowIndex].Value.ToString();
            Session["Gridrow_id"] = id;
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>Confirm();</script>");
        }

        protected void btnDelete(object sender, EventArgs e)
        {
            DeleteInvoice(Convert.ToInt32(Session["Gridrow_id"]));
            GetReport();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>DeleteOk();</script>");
        }

    }
}