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
using RCandJJ.DAL;
#endregion
namespace RCandJJ
{
    public partial class AddGst : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void Insert_GST()
        {
            try
            {
                Gst_Details objSite = new Gst_Details();
                objSite.Gst = Convert.ToDouble(txtGST.Text);
                objSite.SpOperation = "INSERT_GST";
                objSite.SaveGST();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindGridViewByGst()
        {
            try
            {
                Gst_Details objname = new Gst_Details();
                objname.SpOperation = "GET_GST";
                DataTable dtRef = new DataTable();
                dtRef = objname.SaveGST();
                grdGSTReport.DataSource = dtRef;
                grdGSTReport.DataBind();
                Session["DataSource"] = dtRef;

                if (grdGSTReport.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                }
                else
                {
                    errorMsg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteGst(int id)
        {
            try
            {
                Gst_Details objDelete = new Gst_Details();
                objDelete.Gst_id = id;
                objDelete.SpOperation = "DELETE";
                objDelete.SaveGST();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void UpdateGst(int id, string gst)
        {
            try
            {
                Gst_Details objUpdate = new Gst_Details();
                objUpdate.Gst_id = id;
                objUpdate.Gst = Convert.ToDouble(gst);

                objUpdate.SpOperation = "UPDATE";
                objUpdate.SaveGST();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Event"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewByGst();
            }
        }

        protected void grdGSTReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGSTReport.PageIndex = e.NewPageIndex;
            grdGSTReport.DataSource = Session["DataSource"];
            grdGSTReport.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Insert_GST();
            txtGST.Text = "";
           
            BindGridViewByGst();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
        }

        protected void btnEdit(object sender, EventArgs e)
        {

            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            GridViewRow row = grdGSTReport.Rows[selRowIndex];

            TextBox txtGst = (row.FindControl("txtGst") as TextBox);
            txtGst.Visible = true;

            LinkButton btnUpdate = (row.FindControl("btnUpdate") as LinkButton);
            btnUpdate.Visible = true;

            LinkButton btnCancel = (row.FindControl("btnCancel") as LinkButton);
            btnCancel.Visible = true;

            LinkButton btnEdit = (row.FindControl("btnEdit") as LinkButton);
            btnEdit.Visible = false;

            Label lbl = (row.FindControl("Label1") as Label);
            lbl.Visible = false;
            
        }

        protected void btnDeleteConfirm(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdGSTReport.DataKeys[selRowIndex].Value.ToString();
            Session["Gridrow_id"] = id;
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>Confirm();</script>");
        }

        protected void btnDelete(object sender, EventArgs e)
        {
            DeleteGst(Convert.ToInt32(Session["Gridrow_id"]));
            BindGridViewByGst();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>DeleteOk();</script>");
        }

        protected void btnUpdate(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            GridViewRow row = grdGSTReport.Rows[selRowIndex];

            TextBox txtGST = (row.FindControl("txtGST") as TextBox);
            
            string id = grdGSTReport.DataKeys[selRowIndex].Value.ToString();
            UpdateGst(Convert.ToInt32(id), Convert.ToString(txtGST.Text));

            BindGridViewByGst();

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateOk();</script>");

        }

        protected void btnCancel_Click(object sendrt, EventArgs e)
        {
            Response.Redirect("~/AddGst.aspx");
        }

        #endregion
    }
}