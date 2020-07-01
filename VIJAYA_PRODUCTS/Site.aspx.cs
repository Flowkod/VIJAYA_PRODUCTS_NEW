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

#endregion

namespace RCandJJ
{
    public partial class Site : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void Insert_Site_Name()
        {
            try
            {
                SiteManagement objSite = new SiteManagement();
                objSite.site_Name = txtName.Text;
                objSite.Address = txtAddress.Text;
                objSite.MOBILE_NO = txtMobile.Text;
                objSite.GST_NO = txtGst.Text;
                objSite.Hsn_Code = txthsnCode.Text;
               // objSite.Contact_Person = txtContact.Text;
                objSite.SpOperation = "INSERT_SITE_NAME";
                objSite.SaveSite();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindGridViewBySiteName()
        {
            try
            {
                SiteManagement objname = new SiteManagement();
                objname.SpOperation = "GET_SITE_DETAIL";
                DataTable dtRef = new DataTable();
                dtRef = objname.SaveSite();
                grdSiteName.DataSource = dtRef;
                grdSiteName.DataBind();
                Session["DataSource"] = dtRef;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSIteName(int id)
        {
            try
            {
                SiteManagement objDelete = new SiteManagement();
                objDelete.Site_id = id;
                objDelete.SpOperation = "DELETE_SITE_NAME_PRIMARY";
                objDelete.SaveSite();

                if (id == Convert.ToInt32(Request.Cookies["SiteID"].Value))
                {
                    Response.Redirect("~/Index.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GetSiteDetails()
        {
            try
            {
                SiteManagement objname = new SiteManagement();
                objname.Site_id = Convert.ToInt32(Request.QueryString["sid"]);
                objname.SpOperation = "GET_SITE_DETAIL";
                DataTable dtRef = new DataTable();
                dtRef = objname.SaveSite();

                if (dtRef.Rows.Count > 0)
                {
                    txtAddress.Text = Convert.ToString(dtRef.Rows[0]["ADDRESS"]);
                    txtGst.Text = Convert.ToString(dtRef.Rows[0]["GST_NO"]);
                    txtMobile.Text = Convert.ToString(dtRef.Rows[0]["MOBILE_NO"]);
                    txtName.Text = Convert.ToString(dtRef.Rows[0]["SITE_NAME"]);
                    txthsnCode.Text = Convert.ToString(dtRef.Rows[0]["HSN_CODE"]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void UpdateSiteName()
        {
            try
            {
                SiteManagement objUpdate = new SiteManagement();
                objUpdate.Site_id = Convert.ToInt32(Request.QueryString["sid"]);
                objUpdate.site_Name = txtName.Text;
                objUpdate.Address = txtAddress.Text;
                objUpdate.MOBILE_NO = txtMobile.Text;
                objUpdate.GST_NO = txtGst.Text;
                objUpdate.Hsn_Code = txthsnCode.Text;
                objUpdate.SpOperation = "UPDATE_SITE_NAME_PRIMARY";
                objUpdate.SaveSite();
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
                BindGridViewBySiteName();

                if (Request.QueryString["sid"] != null)
                {
                    GetSiteDetails();
                }

            }
        }

        protected void grdSiteName_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSiteName.PageIndex = e.NewPageIndex;
            grdSiteName.DataSource = Session["DataSource"];
            grdSiteName.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["sid"] != null)
            {
                UpdateSiteName();
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateOk();</script>");
            }
            else
            {
                Insert_Site_Name();
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
            }
            txtAddress.Text = "";
          //  txtContact.Text = "";
            txtName.Text = "";
            txtGst.Text = "";
            txtMobile.Text = "";
            txthsnCode.Text = "";
            BindGridViewBySiteName();
            
        }

        protected void btnEdit(object sender, EventArgs e)
        {

            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            GridViewRow row = grdSiteName.Rows[selRowIndex];
            string id = grdSiteName.DataKeys[selRowIndex].Value.ToString();

            Response.Redirect("Site.aspx?sid=" + id + "");
           
        }

        protected void btnDeleteConfirm(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdSiteName.DataKeys[selRowIndex].Value.ToString();
            Session["Gridrow_id"] = id;
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>Confirm();</script>");
        }

        protected void btnDelete(object sender, EventArgs e)
        {
            DeleteSIteName(Convert.ToInt32(Session["Gridrow_id"]));
            BindGridViewBySiteName();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>DeleteOk();</script>");
        }       

        protected void btnCancel_Click(object sendrt, EventArgs e)
        {
            Response.Redirect("~/site.aspx");
        }

        #endregion
    }
}