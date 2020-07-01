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
using SRIRAM_MILK.DAL;

#endregion

namespace SRIRAM_MILK
{
    public partial class AddFund : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

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

        protected void UpdateExpenses(string id, String Description, double amount)
        {
            try
            {
                FundManagement objUpdate = new FundManagement();
                objUpdate.Fund_id = id;
                objUpdate.FUND_AMOUNT = Convert.ToDouble(amount);
                objUpdate.Description = Description;
                objUpdate.SpOperation = "UPDATE";
                objUpdate.SaveExpenses();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertFunds()
        {
            try
            {
                FundManagement obj = new FundManagement();
               
                obj.FUND_AMOUNT = Convert.ToDouble(txtAmount.Text);
                obj.Description = txtDescription.Text;
                obj.SpOperation = "INSERT";
                DataTable dt = new DataTable();
                dt = obj.SaveExpenses();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindGridView()
        {
            try
            {
                FundManagement objname = new FundManagement();               
                if (txtDate.Text != "")
                {
                    objname.CREATED_ON = Convert.ToDateTime(txtDate.Text);
                }
                if (txtToDate.Text != "")
                {
                    objname.To_Date = Convert.ToDateTime(txtToDate.Text);
                }
                objname.SpOperation = "SELECT";
                DataTable dtRef = new DataTable();
                dtRef = objname.SaveExpenses();
                grdExpensesReport.DataSource = dtRef;
                grdExpensesReport.DataBind();
                Session["DataSource"] = dtRef;
                if (dtRef.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                   // lblTotalExpensesAmount.Text = "0";
                    lblAvailableAmount.Text = "0";
                }
                else
                {
                    decimal Total_stock = dtRef.AsEnumerable().Sum(row => row.Field<decimal>("FUND_AMOUNT"));
                    //lblTotalExpensesAmount.Text = Total_stock.ToString();
                    lblAvailableAmount.Text = Total_stock.ToString();
                    errorMsg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteExpenses(string id)
        {
            try
            {
                FundManagement objDelete = new FundManagement();
                objDelete.Fund_id = id;
                objDelete.SpOperation = "DELETE";
                objDelete.SaveExpenses();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region "Event

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAvailableBalnce();
            if (!IsPostBack)
            {
                txtDate.Text = System.DateTime.Now.ToString("dd MMM yyyy");
                txtToDate.Text = System.DateTime.Now.ToString("dd MMM yyyy");
                BindGridView();
              
            }
        }

        protected void grdExpensesReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdExpensesReport.PageIndex = e.NewPageIndex;
            grdExpensesReport.DataSource = Session["DataSource"];
            grdExpensesReport.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InsertFunds();           
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessfuelOk();</script>");           
        }

        protected void btnSearch(object sendrt, EventArgs e)
        {
            BindGridView();
        }

        protected void btnEdit(object sender, EventArgs e)
        {

            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            GridViewRow row = grdExpensesReport.Rows[selRowIndex];

            TextBox txtAmount = (row.FindControl("txtAmount") as TextBox);
            txtAmount.Visible = true;

            TextBox txtDescription = (row.FindControl("txtDescription") as TextBox);
            txtDescription.Visible = true;

            LinkButton btnUpdate = (row.FindControl("btnUpdate") as LinkButton);
            btnUpdate.Visible = true;

            LinkButton btnCancel = (row.FindControl("btnCancel") as LinkButton);
            btnCancel.Visible = true;

            LinkButton btnEdit = (row.FindControl("btnEdit") as LinkButton);
            btnEdit.Visible = false;

            Label lblAmount = (row.FindControl("lblAmount") as Label);
            lblAmount.Visible = false;

            Label lblDescription = (row.FindControl("lblDescription") as Label);
            lblDescription.Visible = false;

        }

        protected void btnUpdate(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            GridViewRow row = grdExpensesReport.Rows[selRowIndex];

            TextBox txtAmount = (row.FindControl("txtAmount") as TextBox);
            TextBox txtDescription = (row.FindControl("txtDescription") as TextBox);

            if (txtAmount.Text == "")
            {
                txtAmount.Text = "0";
            }
            //if (Convert.ToDouble(lblAvailableAmount.Text) < Convert.ToDouble(txtAmount.Text))
            //{
            //    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningAmount();</script>");
            //}
            else
            {
                string id = grdExpensesReport.DataKeys[selRowIndex].Value.ToString();
                UpdateExpenses(Convert.ToString(id), txtDescription.Text, Convert.ToDouble(txtAmount.Text));

                BindGridView();
                //GetTotalStockExpenses();
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateOk();</script>");
            }
        }

        protected void btnDeleteConfirm(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdExpensesReport.DataKeys[selRowIndex].Value.ToString();
            Session["Gridrow_id"] = id;
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>Confirm();</script>");
        }

        protected void btnDelete(object sender, EventArgs e)
        {
            DeleteExpenses(Convert.ToString(Session["Gridrow_id"]));
            BindGridView();
            GetAvailableBalnce();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>DeleteOk();</script>");
        }

        protected void btnCancel_Click(object sendrt, EventArgs e)
        {
            Response.Redirect("~/AddFund.aspx");
        }

        #endregion
    }
}