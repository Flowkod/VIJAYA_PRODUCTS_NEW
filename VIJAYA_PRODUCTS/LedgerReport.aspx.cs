using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using Microsoft.Reporting.WebForms;
using SRIRAM_MILK.DAL;
using SparkInventory.DAL;
using KumarGas.DAL.CLIENT_RAGISTER;
using VIJAYA_PRODUCTS.DAL;

#endregion


namespace VIJAYA_PRODUCTS
{
    public partial class LedgerReport : System.Web.UI.Page
    {

        public void Party()
        {
            Client_Ragister_Management objClient = new Client_Ragister_Management();
            objClient.Customer_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
            objClient.Sp_Operation = "GET_PARTY_NAME";
            DataTable dtClient = new DataTable();
            dtClient = objClient.SaveCustomer();

            auto_ddlPartyName.DataSource = dtClient;
            auto_ddlPartyName.DataValueField = "CUSTOMER_ID";
            auto_ddlPartyName.DataTextField = "CUSTOMER_NAME";
            auto_ddlPartyName.DataBind();
            auto_ddlPartyName.Items.Insert(0, new ListItem("Select Name", "0"));
        }

        public void GetLedger()
        {
            ReportViewer1.SizeToReportContent = true;

            Ledger objLedger = new Ledger();
            objLedger.SP_OPERATION = "SELECT";
            DataTable dt = new DataTable();

            if (txtFromDate.Text != "")
            {
                objLedger.from_date = Convert.ToDateTime(txtFromDate.Text);
            }

            if (txttoDate.Text != "")
            {
                objLedger.To_date = Convert.ToDateTime(txttoDate.Text);
            }

            if (auto_ddlPartyName.SelectedItem.Text != "")
            {
                objLedger.PartyName = Convert.ToString(auto_ddlPartyName.SelectedItem.Text);
            }
            dt = objLedger.GetLedger();

            objLedger.SP_OPERATION = "OPENING_BALANCE";
            DataTable dt1 = new DataTable();
            dt1 = objLedger.GetLedger();

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Ledger.rdlc");

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(_rsource1);

            ReportDataSource _rsource = new ReportDataSource("DataSet2", dt1);
            ReportViewer1.LocalReport.DataSources.Add(_rsource);

            ReportViewer1.LocalReport.Refresh();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Party();
                //GetLedger();
            }

        }

        protected void btnSearchLedger(object sender, EventArgs e)
        {
            GetLedger();
        }

    }
}