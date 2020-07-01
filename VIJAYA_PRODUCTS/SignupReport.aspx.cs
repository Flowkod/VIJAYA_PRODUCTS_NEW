using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StarCity.DAL.LOGIN_DETAILS;
using System.Data;

namespace RCandJJ
{
    public partial class SignupReport : System.Web.UI.Page
    {

        #region Public Function

        public void GetLoginReport()
        {
            try
            {
                LoginManagement objUser = new LoginManagement();
                objUser.Sp_Operation = "GET_LOGIN_REPORT";
                DataTable dtTd = new DataTable();
                dtTd = objUser.SaveUser();

                grdLoginReport.DataSource = dtTd;
                grdLoginReport.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteLoginUser(int user_id)
        {
            try
            {
                LoginManagement objUser = new LoginManagement();
                objUser.Sp_Operation = "DELETE_LOGIN_USER";
                objUser.User_Id = user_id;
                DataTable dtTd = new DataTable();
                dtTd = objUser.SaveUser();                
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
                GetLoginReport();
            }
        }

        protected void btnDeleteConfirm(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdLoginReport.DataKeys[selRowIndex].Value.ToString();
            Session["Gridrow_id"] = id;
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>Confirm();</script>");
        }

        protected void btnDelete(object sender, EventArgs e)
        {
            DeleteLoginUser(Convert.ToInt32(Session["Gridrow_id"]));
            GetLoginReport();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>DeleteOk();</script>");
        }
    }
}