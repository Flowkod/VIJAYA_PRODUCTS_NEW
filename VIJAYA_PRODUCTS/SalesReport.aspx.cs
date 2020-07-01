using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using NewStarCity.DAL.PURCHASE_ORDER;
using StarCity.DAL.SITE_DETAILS;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using KumarGas.DAL.CLIENT_RAGISTER;
using System.IO;
using System.Drawing;

#endregion

namespace SRIRAM_MILK
{
    public partial class SalesReport : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function

        public void GetPoReport()
        {
            try
            {
                Purches_Order_Management objUser = new Purches_Order_Management();
                objUser.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);

                if (txtSearchPO.Text != "")
                {
                    objUser.Po_No = txtSearchPO.Text;
                }

                if (auto_select1.SelectedItem.Value != "")
                {
                    objUser.Customer_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (txtFromDate.Text != "")
                {
                    objUser.Date = Convert.ToDateTime(txtFromDate.Text);
                }

                if (txttoDate.Text != "")
                {
                    objUser.to_date = Convert.ToDateTime(txttoDate.Text);
                }

                objUser.Sp_Operation = "GET_PURCHASE_ORDER_BY_PO";
                DataTable dtUser = new DataTable();
                dtUser = objUser.SaveUser();

                if (dtUser.Rows.Count == 0)
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningOk();</script>");
                }

                grdPOReport.DataSource = dtUser;
                grdPOReport.DataBind();

                Session["DataSource"] = dtUser;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindClient()
        {
            Client_Ragister_Management objClient = new Client_Ragister_Management();
            objClient.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            objClient.Sp_Operation = "GET_CLIENT_REPORT";
            DataTable dtClient = new DataTable();
            dtClient = objClient.SaveCustomer();

            auto_select1.DataSource = dtClient;
            auto_select1.DataValueField = "CUSTOMER_ID";
            auto_select1.DataTextField = "CUSTOMER_NAME";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Supplier Name", ""));
        }

        public void DeletePurchaseOrder(string id)
        {
            try
            {
                Purches_Order_Management objPurchase = new Purches_Order_Management();
                objPurchase.Po_No = id;
                objPurchase.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                objPurchase.Sp_Operation = "DELETE_PURCHASE_ORDER";
                objPurchase.SaveUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletePurchaseOrderIfNotSave()
        {
            try
            {
                Purches_Order_Management objDeletePurchase = new Purches_Order_Management();
                objDeletePurchase.Sp_Operation = "DELETE_PURCHASE_ORDER_IF_NOT_SAVE";
                objDeletePurchase.SaveUser();
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
            Response.AddHeader("content-disposition", "attachment;filename=SalesRegisterReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages

                grdPOReport.AllowPaging = false;
                grdPOReport.DataSource = Session["DataSource"];
                grdPOReport.DataBind();

                grdPOReport.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdPOReport.HeaderRow.Cells)
                {
                    cell.BackColor = grdPOReport.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdPOReport.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdPOReport.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdPOReport.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdPOReport.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DeletePurchaseOrderIfNotSave();
                BindClient();
                GetPoReport();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void grdPOReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPOReport.PageIndex = e.NewPageIndex;
            grdPOReport.DataSource = Session["DataSource"];
            grdPOReport.DataBind();
        }

        //protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlDate.SelectedItem.Value == "1")
        //    {
        //        txtSearchPO.Visible = true;
        //        text2.Visible = false;
        //        text1.Visible = true;
        //        grdPOReport.Visible = true;
        //    }
        //    else if (ddlDate.SelectedItem.Value == "2")
        //    {
        //        txtSearchPO.Visible = false;
        //        text1.Visible = false;
        //        text2.Visible = true;
        //        grdPOReport.Visible = true;
        //    }
        //}

        protected void txtSearchPO_TextChanged(object sender, EventArgs e)
        {
            GetPoReport();
            auto_select1.ClearSelection();
        }

        protected void ClientName_SelectedIndexchange(object sender, EventArgs e)
        {
            txtSearchPO.Text = "";
            GetPoReport();
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string PoNo = grdPOReport.DataKeys[selRowIndex].Value.ToString();

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "newpage", "customOpen('POFormPrint.aspx?po_no=" + PoNo + "');", true);
        }
       
        protected void btnExcelExportClick(object sender, EventArgs e)
        {
            SaveInExcel();
        }
    }
}