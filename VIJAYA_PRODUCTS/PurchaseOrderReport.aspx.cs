using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using StarCity.DAL.SITE_DETAILS;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using KumarGas.DAL.CLIENT_RAGISTER;
using SUPPLY_MANAGEMENT.DAL;
using SparkInventory.DAL;

#endregion

namespace SparkInventory
{
    public partial class QuotationReport : System.Web.UI.Page
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
                Quotation_Management objUser = new Quotation_Management();
                objUser.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);

                if (txtSearchPO.Text != "")
                {
                    objUser.Quotation_No = txtSearchPO.Text;
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

                objUser.Sp_Operation = "GET_QUOTATION_BY_QUOTATION_NO";
                DataTable dtUser = new DataTable();
                dtUser = objUser.SaveUser();

                if (dtUser.Rows.Count == 0)
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningOk();</script>");
                }

                grdPOReport.DataSource = dtUser;
                grdPOReport.DataBind();

                Session["DataSource"] = dtUser;

                if (dtUser.Rows.Count > 0)
                {
                    decimal total_amt = dtUser.AsEnumerable().Sum(row => row.Field<decimal>("TOTAL"));
                    decimal cgst = dtUser.AsEnumerable().Sum(row => row.Field<decimal>("CGST_AMOUNT"));
                    decimal sgst = dtUser.AsEnumerable().Sum(row => row.Field<decimal>("SGST_AMOUNT"));
                    decimal grand_total = dtUser.AsEnumerable().Sum(row => row.Field<decimal>("GRAND_TOTAL"));

                    lblTotal.Text = total_amt.ToString();
                    lblCgst.Text = cgst.ToString();
                    lblSgst.Text = sgst.ToString();
                    lblGrandTotal.Text = grand_total.ToString();
                    total.Visible = true;
                    //btnPrintAll.Visible = true;
                }
                else
                {
                    total.Visible = false;
                    lblTotal.Text = "";
                    lblCgst.Text = "";
                    lblSgst.Text = "";
                    lblGrandTotal.Text = "";
                    //btnPrintAll.Visible = false;
                }
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
            auto_select1.Items.Insert(0, new ListItem("Customer Name", ""));
        }

        public void DeletePurchaseOrder(int id)
        {
            try
            {
                Quotation_Management objPurchase = new Quotation_Management();
                objPurchase.Quotation_id =id;
                objPurchase.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                objPurchase.Sp_Operation = "DELETE_QUOTATION";
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
                Quotation_Management objDeletePurchase = new Quotation_Management();
                objDeletePurchase.Sp_Operation = "DELETE_QUOTATION_IF_NOT_SAVE";
                objDeletePurchase.SaveUser();
            }
            catch (Exception ex)
            {
                throw ex;
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

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "newpage", "customOpen('QuotationFormPrint.aspx?po_no=" + PoNo + "');", true);
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
            DeletePurchaseOrder(Convert.ToInt32(Session["Gridrow_id"]));
            GetPoReport();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>DeleteOk();</script>");
        }

        protected void btnPrintAll_Click(object sender, EventArgs e)
        {
            string po_no = string.Empty, cid = string.Empty, from = string.Empty, to = string.Empty;

            if (txtSearchPO.Text != "")
            {
                po_no = "po_no=" + txtSearchPO.Text;
            }

            if (auto_select1.SelectedItem.Value != "")
            {
                cid = "cid=" + auto_select1.SelectedItem.Value;
            }

            if (txtFromDate.Text != "")
            {
                from = "from+" + txtFromDate.Text;
            }

            if (txttoDate.Text != "")
            {
                to = "to=" + txttoDate.Text;
            }

            Response.Redirect("PrintAllInvoice.aspx?" + po_no + "&" + cid + "&" + from + "&" + to);
        }
    }
}