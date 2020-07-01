using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using SparkInventory.DAL;
using System.Data;
using SRIRAM_MILK.DAL;

#endregion

namespace SparkInventory
{
    public partial class Expenses : System.Web.UI.Page
    {
        #region "Variable"
        #endregion

        #region "Public Function"

        public void GetAvailableBalnce()
        {
            try
            {
                FundManagement obj = new FundManagement();

                obj.SpOperation = "AVAITABLE_BALANCE";
                DataTable dt = new DataTable();
                dt = obj.SaveExpenses();

                if (dt.Rows.Count > 0)
                {
                    lblAvailableBalance.Text = Convert.ToString(dt.Rows[0]["AVAILABLE_AMOUNT"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void InsertCashMemo()
        {
            try
            {
                Cash_Memo_Management objCashMemo = new Cash_Memo_Management();
                objCashMemo.SpOperation = "INSERT";
                DataTable dtCashMemo = new DataTable();
                dtCashMemo = objCashMemo.SaveCashMemo();

                if (dtCashMemo.Rows.Count > 0)
                {
                    //txtSrNo.Text = Convert.ToString(dtCashMemo.Rows[0]["SRNO"]);
                    hidCashMemoID.Value = Convert.ToString(dtCashMemo.Rows[0]["CASH_MEMO_ID"]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCashMemo()
        {
            try
            {
                Cash_Memo_Management objCashMemo = new Cash_Memo_Management();
                objCashMemo.Cash_Memo_id = Convert.ToInt32(hidCashMemoID.Value);
                objCashMemo.Srno = txtSrNo.Text;
                objCashMemo.date = Convert.ToDateTime(txtDate.Text);
                objCashMemo.PartyName = txtPartyName.Text;
                objCashMemo.Address = "Kalptaru Colony (B), Karve Nagar, Pune - 411052";
                objCashMemo.Grand_Total = Convert.ToDouble(lblGrandTotal.Text);
                objCashMemo.SpOperation = "UPDATE";
                DataTable dtCashMemo = new DataTable();
                objCashMemo.SaveCashMemo();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveCashMemoDescription(int Description_id, string Description, double qty, double rate)
        {
            try
            {
                Cash_Memo_Description_Management objCashDescription = new Cash_Memo_Description_Management();
                objCashDescription.Description_id = Convert.ToInt32(Description_id);
                objCashDescription.Cash_Memo_id = Convert.ToInt32(hidCashMemoID.Value);
                objCashDescription.Description = Description;
                objCashDescription.Quantity = qty;
                objCashDescription.Rate = rate;
                objCashDescription.SpOperation = "INSERT";
                objCashDescription.SaveCashMemoDescription();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetCashMemoDescription()
        {
            try
            {
                Cash_Memo_Description_Management objCashDescription = new Cash_Memo_Description_Management();
                objCashDescription.Cash_Memo_id = Convert.ToInt32(hidCashMemoID.Value);
                objCashDescription.SpOperation = "SELECT";
                DataTable dt = new DataTable();
                dt = objCashDescription.SaveCashMemoDescription();
                grdCashMemo.DataSource = dt;
                grdCashMemo.DataBind();

                if (dt.Rows.Count > 0)
                {
                    lblGrandTotal.Text = Convert.ToString(dt.Rows[0]["GRAND_TOTAL"]);
                }
                else
                {
                    lblGrandTotal.Text = "0";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetCahsMemoReport()
        {
            try
            {
                Cash_Memo_Management objCash = new Cash_Memo_Management();

                if (txttoDate.Text != "")
                {
                    objCash.ToDate = Convert.ToDateTime(txttoDate.Text);
                }

                if (txtFromDate.Text != "")
                {
                    objCash.date = Convert.ToDateTime(txtFromDate.Text);
                }

                //objCash.PartyName = auto_select1.SelectedItem.Text;

                objCash.SpOperation = "SELECT";
                DataTable dtCahMemo = new DataTable();
                dtCahMemo = objCash.SaveCashMemo();
                grdCashMemoReport.DataSource = dtCahMemo;
                grdCashMemoReport.DataBind();

                Session["DataSource"] = dtCahMemo;

                if (dtCahMemo.Rows.Count > 0)
                {
                    btnPrint.Visible = true;

                    //Calculate Sum and display in Footer Row
                    decimal total = dtCahMemo.AsEnumerable().Sum(row => row.Field<decimal>("Grand_Total"));
                    grdCashMemoReport.FooterRow.Cells[1].Text = "Total";
                    grdCashMemoReport.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    grdCashMemoReport.FooterRow.Cells[2].Text = total.ToString("N2");
                }
                else
                {
                    btnPrint.Visible = false;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCashMemo(int id)
        {
            try
            {
                Cash_Memo_Management objCashMemo = new Cash_Memo_Management();
                objCashMemo.Cash_Memo_id = id;
                objCashMemo.SpOperation = "DELETE";
                objCashMemo.SaveCashMemo();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindClient()
        {
            Cash_Memo_Management objClient = new Cash_Memo_Management();

            objClient.SpOperation = "GET_PARTY_NAME";
            DataTable dtClient = new DataTable();
            dtClient = objClient.SaveCashMemo();

            auto_select1.DataSource = dtClient;
            auto_select1.DataValueField = "CASH_MEMO_ID";
            auto_select1.DataTextField = "PARTY_NAME";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Party Name", ""));
        }

        #endregion

        #region "Event"

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAvailableBalnce();
            if (!IsPostBack)
            {
                DateTime serverTime = DateTime.Now;
                DateTime utcTime = serverTime.ToUniversalTime();
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                string s = localTime.ToString("dd MMM yyy");
                txtDate.Text = s;
              
                InsertCashMemo();
                GetCashMemoDescription();
                GetCahsMemoReport();
                BindClient();
            }
        }

        protected void grdCashMemoReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCashMemoReport.PageIndex = e.NewPageIndex;
            grdCashMemoReport.DataSource = Session["DataSource"];
            grdCashMemoReport.DataBind();
        }

        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
            string id = grdCashMemo.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdCashMemo.Rows[selRowIndex];

            TextBox txtDescription = (row.FindControl("txtDescription") as TextBox);
            //TextBox txtQty = (row.FindControl("txtQty") as TextBox);
            TextBox txtRate = (row.FindControl("txtRate") as TextBox);


            if (txtRate.Text == "")
            {
                txtRate.Text = "0";
            }

            //if (txtQty.Text == "")
            //{
            //    txtQty.Text = "0";
            //}

            SaveCashMemoDescription(Convert.ToInt32(id), txtDescription.Text, 1, Convert.ToDouble(txtRate.Text));
            GetCashMemoDescription();
            TextBox txt = sender as TextBox;

            //if (txt.ID == "txtDescription")
            //{
            //    txtQty.Focus();
            //}

            if (txt.ID == "txtQty")
            {
                txtRate.Focus();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateCashMemo();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");

        }

        protected void btnDelete(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdCashMemo.DataKeys[selRowIndex].Value.ToString();

            if (id != "")
            {
                Cash_Memo_Description_Management objDescDelete = new Cash_Memo_Description_Management();
                objDescDelete.Description_id = Convert.ToInt32(id);
                objDescDelete.SpOperation = "DELETE";
                objDescDelete.SaveCashMemoDescription();
                GetCashMemoDescription();
            }
        }

        protected void btnDeleteConfirm(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdCashMemoReport.DataKeys[selRowIndex].Value.ToString();
            Session["Gridrow_id"] = id;
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>Confirm();</script>");
        }

        protected void btnDeleteCashMemo(object sender, EventArgs e)
        {
            DeleteCashMemo(Convert.ToInt32(Session["Gridrow_id"]));
            GetCahsMemoReport();
            GetAvailableBalnce();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>DeleteOk();</script>");
        }

        protected void btnSearchCashMemo(object sender, EventArgs e)
        {
            GetCahsMemoReport();
        }

        protected void btnPrintCashMemo(object sender, EventArgs e)
        {
            string from=string.Empty, to=string.Empty;

            if (txtFromDate.Text != "")
            {
                from ="from="+txtFromDate.Text;
            }

            if (txttoDate.Text != "")
            {
                to = "to="+txttoDate.Text;
            }

            Response.Redirect("CashMemoPrint.aspx?" + from + "&" + to + "");
        }

        #endregion
    }
}