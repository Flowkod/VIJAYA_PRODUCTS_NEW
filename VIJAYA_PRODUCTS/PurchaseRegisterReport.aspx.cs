using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using INVOICE_DEMO.DAL;
using System.Data;
using System.IO;
using System.Drawing;

namespace INVOICE_DEMO
{
    public partial class PurchaseRegisterReport : System.Web.UI.Page
    {
        public void GetReport()
        {
            try
            {
                Purchase_Register_Managment objPurchase = new Purchase_Register_Managment();
                objPurchase.Invoice_no = txtSearchPO.Text;
                objPurchase.Invoice_Date = txtFromDate.Text;
                objPurchase.To_Date = txttoDate.Text;
                objPurchase.Sp_Operation = "SELECT";

                DataTable dt = new DataTable();
                dt = objPurchase.SavePurchase();

                grdPOReport.DataSource = dt;
                grdPOReport.DataBind();

                grdPoPrint.DataSource = dt;
                grdPoPrint.DataBind();

                Session["DataSource"] = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletePurchase(int id)
        {
            try
            {
                Purchase_Register_Managment objPurchase = new Purchase_Register_Managment();
                objPurchase.Purchase_reg_id = id;
                objPurchase.Sp_Operation = "DELETE";
                objPurchase.SavePurchase();               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveInExcel()
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=PurchaseRegisterReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages

                grdPoPrint.AllowPaging = false;
                grdPoPrint.DataSource = Session["DataSource"];
                grdPoPrint.DataBind();

                grdPoPrint.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdPoPrint.HeaderRow.Cells)
                {
                    cell.BackColor = grdPoPrint.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdPoPrint.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdPoPrint.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdPoPrint.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdPoPrint.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetReport();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void btnSearchReport(object sender, EventArgs e)
        {
            GetReport();
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
            DeletePurchase(Convert.ToInt32(Session["Gridrow_id"]));
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>DeleteOk();</script>");
        }

        protected void btnExcelExportClick(object sender, EventArgs e)
        {
            SaveInExcel();
        }
    }
}