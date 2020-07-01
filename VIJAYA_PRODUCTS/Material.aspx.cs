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
using SUPPLY_MANAGEMENT.DAL;
using RCandJJ.DAL;

#endregion

namespace RCandJJ
{
    public partial class Material : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void SaveMaterial()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.Material_name = txtMaterialName.Text;
            objMaterial.Gst = Convert.ToDouble(ddlGst.SelectedValue);
            objMaterial.Unit = txtUnit.Text;
            objMaterial.Hsn_Code = txtHsnCode.Text;
            objMaterial.Created_by = Convert.ToInt32(Request.Cookies["UserID"].Value);
            objMaterial.SpOperation = "INSERT";
            objMaterial.SaveMaterial();
        }

        public void DeleteMaterial(int id)
        {
            try
            {
                Material_management objMaterial = new Material_management();
                objMaterial.Material_id = id;
                objMaterial.SpOperation = "DELETE";
                objMaterial.SaveMaterial();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateMaterial(int id, String MaterialName, double rate, double gst, string unit, string hsn_code)
        {
            try
            {
                Material_management objMaterial = new Material_management();
                objMaterial.Material_id = id;
                objMaterial.Material_name = MaterialName;
                objMaterial.Gst = gst;
                objMaterial.Unit = unit;
                objMaterial.Hsn_Code = hsn_code;
                objMaterial.Created_by = Convert.ToInt32(Request.Cookies["UserID"].Value);
                objMaterial.SpOperation = "UPDATE";
                objMaterial.SaveMaterial();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetMaterialReport()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.Material_name = txtSearchMaterialName.Text;
            objMaterial.SpOperation = "SELECT";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            Session["DataSource"] = dtMaterial;

            grdMaterialReport.DataSource = dtMaterial;
            grdMaterialReport.DataBind();

            grdStockUpdate.DataSource = dtMaterial;
            grdStockUpdate.DataBind();

            if (dtMaterial.Rows.Count == 0)
            {
                errorMsg.Visible = true;
            }
            else
            {
                errorMsg.Visible = false;
            }
        }

        public bool CheckMaterialName()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "GET_MATERIAL_NAME";
            objMaterial.Material_name = txtMaterialName.Text;
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            if (dtMaterial.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetGSTPercentage()
        {
            Gst_Details objGST = new Gst_Details();
            objGST.SpOperation = "GET_GST";

            DataTable dtGST = new DataTable();
            dtGST = objGST.SaveGST();
            ddlGst.DataSource = dtGST;
            ddlGst.DataTextField = "GST";
            ddlGst.DataValueField = "GST_ID";
            ddlGst.DataBind();
            ddlGst.Items.Insert(0, new ListItem("- Select GST% - ", "0"));
        }

        #endregion

        #region "Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetGSTPercentage();
                GetMaterialReport();
            }
        }

        protected void grdMaterialReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMaterialReport.PageIndex = e.NewPageIndex;
            grdMaterialReport.DataSource = Session["DataSource"];
            grdMaterialReport.DataBind();
        }

        protected void grdUpdateStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStockUpdate.PageIndex = e.NewPageIndex;
            grdStockUpdate.DataSource = Session["DataSource"];
            grdStockUpdate.DataBind();
        }

      protected void StockRowDatabind(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAvailableQty = (e.Row.FindControl("lblAvailableQty") as Label);
                TextBox txtLOW_QTY = (e.Row.FindControl("txtLOW_QTY") as TextBox);
                if (lblAvailableQty.Text == "")
                {
                    lblAvailableQty.Text = "0";
                }

                if (txtLOW_QTY.Text == "")
                {
                    txtLOW_QTY.Text = "0";
                }

                if (Convert.ToDouble(txtLOW_QTY.Text) >=Convert.ToDouble(lblAvailableQty.Text))
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;   // This will make row back color red
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckMaterialName() == false)
            {
                SaveMaterial();
                GetMaterialReport();
                txtMaterialName.Text = "";
                ddlGst.ClearSelection();
                //txtRate.Text = "";
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningOk();</script>");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetMaterialReport();
        }

        protected void btnEdit(object sender, EventArgs e)
        {

            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            GridViewRow row = grdMaterialReport.Rows[selRowIndex];

            TextBox txtName = (row.FindControl("txtMaterialName") as TextBox);
            txtName.Visible = true;

            // TextBox txtAddress = (row.FindControl("txtRate") as TextBox);
            //txtAddress.Visible = true;

            TextBox txtUnit = (row.FindControl("txtUnit") as TextBox);
            txtUnit.Visible = true;

            TextBox txtHsnCode = (row.FindControl("txtHsnCode") as TextBox);
            txtHsnCode.Visible = true;

            DropDownList ddlGST1 = (row.FindControl("ddlGST1") as DropDownList);
            ddlGST1.Visible = true;

            LinkButton btnUpdate = (row.FindControl("btnUpdate") as LinkButton);
            btnUpdate.Visible = true;

            LinkButton btnCancel = (row.FindControl("btnCancel") as LinkButton);
            btnCancel.Visible = true;

            LinkButton btnEdit = (row.FindControl("btnEdit") as LinkButton);
            btnEdit.Visible = false;

            Label lbl = (row.FindControl("lblMaterialName") as Label);
            lbl.Visible = false;

            Label lblGST = (row.FindControl("lblGST") as Label);
            lblGST.Visible = false;

            Label lblGSTID = (row.FindControl("lblGSTID") as Label);

            Gst_Details objGST1 = new Gst_Details();
            objGST1.SpOperation = "GET_GST";

            DataTable dtGST1 = new DataTable();
            dtGST1 = objGST1.SaveGST();
            ddlGST1.DataSource = dtGST1;
            ddlGST1.DataTextField = "GST";
            ddlGST1.DataValueField = "GST_ID";
            ddlGST1.DataBind();
            ddlGST1.Items.Insert(0, new ListItem("- GST% - ", "0"));

            if (lblGSTID.Text == "")
            {
                lblGSTID.Text = "0";
            }

            ddlGST1.ClearSelection();
            ddlGST1.Items.FindByValue(lblGSTID.Text).Selected = true;

            //ddlGST1.SelectedItem.Value = lblGSTID.Text;
            //ddlGST1.SelectedItem.Text = lblGST.Text;

        }

        protected void btnDeleteConfirm(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdMaterialReport.DataKeys[selRowIndex].Value.ToString();
            Session["Gridrow_id"] = id;
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>Confirm();</script>");
        }

        protected void btnDelete(object sender, EventArgs e)
        {
            DeleteMaterial(Convert.ToInt32(Session["Gridrow_id"]));
            GetMaterialReport();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>DeleteOk();</script>");
        }

        protected void btnUpdate(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            GridViewRow row = grdMaterialReport.Rows[selRowIndex];

            TextBox txtName = (row.FindControl("txtMaterialName") as TextBox);
            //TextBox txtRate = (row.FindControl("txtRate") as TextBox);
            TextBox txtUnit = (row.FindControl("txtUnit") as TextBox);
            TextBox txtHsnCode = (row.FindControl("txtHsnCode") as TextBox);
            DropDownList ddlGst = (row.FindControl("ddlGST1") as DropDownList);

            //if (txtRate.Text == "")
            //{
            //    txtRate.Text = "0";
            //}


            string id = grdMaterialReport.DataKeys[selRowIndex].Value.ToString();
            UpdateMaterial(Convert.ToInt32(id), txtName.Text, Convert.ToDouble(txtRate.Text), Convert.ToDouble(ddlGst.SelectedItem.Value), txtUnit.Text, txtHsnCode.Text);
            GetMaterialReport();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateOk();</script>");

        }

        protected void btnCancel_Click(object sendrt, EventArgs e)
        {
            Response.Redirect("~/Material.aspx");
        }

        protected void txtUpdateStockQty(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
            string id = grdStockUpdate.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdStockUpdate.Rows[selRowIndex];
            TextBox txtAddQty = (row.FindControl("txtAddQty") as TextBox);

            if (txtAddQty.Text == "")
            {
                txtAddQty.Text = "0";
            }

            Material_management objMaterial = new Material_management();
            objMaterial.Material_id = Convert.ToInt32(id);
            objMaterial.Qty_in_Stock = Convert.ToDouble(txtAddQty.Text);
            objMaterial.SpOperation = "UPDATE_STOCK_QTY";
            objMaterial.SaveMaterial();
            txtAddQty.Text = "";
            GetMaterialReport();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateStockOk();</script>");
        }

        protected void txtUpdatelowQty(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
            string id = grdStockUpdate.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdStockUpdate.Rows[selRowIndex];
            TextBox txtLOW_QTY = (row.FindControl("txtLOW_QTY") as TextBox);

            if (txtLOW_QTY.Text == "")
            {
                txtLOW_QTY.Text = "0";
            }

            Material_management objMaterial = new Material_management();
            objMaterial.Material_id = Convert.ToInt32(id);
            objMaterial.LOW_QTY = Convert.ToDouble(txtLOW_QTY.Text);
            objMaterial.SpOperation = "UPDATE_LOW_QTY";
            objMaterial.SaveMaterial();
            GetMaterialReport();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateLowQtyOk();</script>");

        }
        #endregion

    }
}

