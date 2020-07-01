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
using SRIRAM_MILK.DAL;
using KumarGas.DAL.CLIENT_RAGISTER;
using VIJAYA_PRODUCTS.DAL;

#endregion


namespace VIJAYA_PRODUCTS
{
    public partial class CreditDebit : System.Web.UI.Page
    {
        #region "Variable

        public DataTable dt { get; set; }
        public int id { get; set; }
        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

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
            auto_select1.Items.Insert(0, new ListItem("", ""));
        }

        public void SaveCredit()
        {
            creditentry objentry = new creditentry();
            objentry.PartyName = txtPartyName.Text;
            objentry.Type = ddlType.Text;
            objentry.Date = txtDate.Text;
            objentry.Amount = Convert.ToDouble(txtAmount.Text);
            objentry.Description = txtDescription.Text;
            objentry.SP_OPERATION = "INSERT";
            objentry.SaveEntry();
        }

        public void GetCreditReport()
        {
            creditentry objentry = new creditentry();

            objentry.SP_OPERATION = "SELECT";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objentry.SaveEntry();
            grdCreditDebitReport.DataSource = dtMaterial;
            grdCreditDebitReport.DataBind();


            if (dtMaterial.Rows.Count == 0)
            {
                errorMsg.Visible = true;
            }
            else
            {
                errorMsg.Visible = false;
            }
        }

        public void Delete(int id)
        {
            try
            {
                creditentry objentry = new creditentry();
                objentry.SP_OPERATION = "DELETE";
                objentry.id = id;
                //objentry.SaveEntry();
                dt = objentry.SaveEntry();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GetCreditDebitReport()
        {
            try
            {
                creditentry objentry = new creditentry();

                if (txttoDate.Text != "")
                {
                    objentry.To_Date = Convert.ToString(txttoDate.Text);
                }

                if (txtFromDate.Text != "")
                {
                    objentry.Date = Convert.ToString(txtFromDate.Text);
                }

                objentry.SP_OPERATION = "SELECT_DATE";
                DataTable dtCahMemo = new DataTable();
                dtCahMemo = objentry.SaveEntry();
                grdCreditDebitReport.DataSource = dtCahMemo;
                grdCreditDebitReport.DataBind();

                Session["DataSource"] = dtCahMemo;



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
                GetCreditReport();
                BindClient();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveCredit();
            Response.Redirect("~/CreditDebit.aspx");
        }

        protected void btnDelete(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            int id = Convert.ToInt32(grdCreditDebitReport.DataKeys[selRowIndex].Values[0]);
            Delete(id);
            GetCreditReport();
        }

        protected void btnSearchCreditDebit(object sender, EventArgs e)
        {
            GetCreditDebitReport();
        }

        protected void Name_SelectedIndexchange(object sender, EventArgs e)
        {
            txtPartyName.Text = auto_select1.SelectedItem.Text;

        }

        #endregion
    }
}