using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using KumarGas.DAL.CLIENT_RAGISTER;
using KumarGas.DAL.CLIENT_RATE_PRODUCT;
using SUPPLY_MANAGEMENT.DAL;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

#endregion

namespace RCandJJ
{
    public partial class CustomerReport1 : System.Web.UI.Page
    {

        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function

        public void BindGridViewByClient()
        {
            try
            {
                Client_Ragister_Management objname = new Client_Ragister_Management();
                objname.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                objname.Sp_Operation = "GET_CLIENT_REPORT";
                DataTable dtRef = new DataTable();
                dtRef = objname.SaveCustomer();
                grdClientReport.DataSource = dtRef;
                grdClientReport.DataBind();

                Session["DataSource"] = dtRef;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteClientReport(int id)
        {
            try
            {
                Client_Ragister_Management objDelete = new Client_Ragister_Management();
                objDelete.Customer_Id = id;
                objDelete.Sp_Operation = "DELETE_CLIENT_REPORT";
                objDelete.SaveCustomer();
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
            if (!IsPostBack)
            {
                BindGridViewByClient();
            }
        }
        
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionListName(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;

                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "SELECT CUSTOMER_NAME FROM CUSTOMER_RAGISTRATION WHERE CUSTOMER_NAME LIKE '%'+@NAME+'%' AND SITE_ID=" + Convert.ToInt32(HttpContext.Current.Request.Cookies["SiteID"].Value) + " ORDER BY CUSTOMER_NAME ASC";

                    com.Parameters.AddWithValue("@NAME", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> MemberName = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            MemberName.Add(sdr["CUSTOMER_NAME"].ToString());
                        }
                    }
                    con.Close();
                    return MemberName;
                }
            }

        }

        protected void grdClientReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClientReport.PageIndex = e.NewPageIndex;
            grdClientReport.DataSource = Session["DataSource"];
            grdClientReport.DataBind();
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {

            Client_Ragister_Management obj = new Client_Ragister_Management();

            int selRowIndex = ((GridViewRow)(((Button)sender).Parent.Parent)).RowIndex;
            string id = grdClientReport.DataKeys[selRowIndex].Value.ToString();

            lblClientID1.Text = id;

            obj.Sp_Operation = "GET_DATA";
            obj.Customer_Id = Convert.ToInt32(id);
            obj.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            DataTable dt = new DataTable();
            dt = obj.SaveCustomer();
            if (dt.Rows.Count > 0)
            {
                lblName.Text = Convert.ToString(dt.Rows[0]["CUSTOMER_NAME"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["ADDRESS"]);
                lblGstNo.Text = Convert.ToString(dt.Rows[0]["GST_NO"]);
                lblEmail.Text = Convert.ToString(dt.Rows[0]["EMAIL_ID"]);
                lblMobileno.Text = Convert.ToString(dt.Rows[0]["MOBILE_NO"]);
                lblDeliveryAddress.Text = Convert.ToString(dt.Rows[0]["DELIVERY_ADDRESS"]);
              //  lblPanNo.Text = Convert.ToString(dt.Rows[0]["PAN_NO"]);

            }

            ClientRateProductManagement objview = new ClientRateProductManagement();

            lblClientID.Text = id;

            objview.Sp_Operation = "GET_PRODUCT_BY_PRIMARY";
            objview.Customer_Id = Convert.ToInt32(id);
            objview.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            DataTable dtroll = new DataTable();
            dtroll = objview.SaveUser();


            grdPopupDetails.DataSource = dtroll;
            grdPopupDetails.DataBind();

            Session["DataSource"] = dtroll;

            myModal.Style.Add("display", "block");
            //fade.Style.Add("display", "block");
        }

        protected void btnDeleteConfirm(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdClientReport.DataKeys[selRowIndex].Value.ToString();
            Session["Gridrow_id"] = id;
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>Confirm();</script>");
        }

        protected void btnDelete(object sender, EventArgs e)
        {
            DeleteClientReport(Convert.ToInt32(Session["Gridrow_id"]));
            BindGridViewByClient();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>DeleteOk();</script>");
        }

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            Client_Ragister_Management objname = new Client_Ragister_Management();
            objname.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            objname.Customer_Name = Convert.ToString(txtClientName.Text);
            objname.Sp_Operation = "GET_CLIENT_NAME";
            DataTable dtRef = new DataTable();
            dtRef = objname.SaveCustomer();
            grdClientReport.DataSource = dtRef;
            grdClientReport.DataBind();

            Session["DataSource"] = dtRef;

        }

        #endregion
    }
}