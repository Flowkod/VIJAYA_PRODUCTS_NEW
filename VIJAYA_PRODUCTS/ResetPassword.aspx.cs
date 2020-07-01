using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


#region "Additional Namespaces"

using StarCity.DAL.LOGIN_DETAILS;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;

#endregion

namespace Nation52Admin
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void GetOldPassword()
        {
            try
            {
                LoginManagement obj = new LoginManagement();
                obj.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
                obj.Password = txtOldPassword.Text;
                obj.Sp_Operation = "CHECK_OLD_PASSWORD";
                DataTable dt = new DataTable();
                dt = obj.SaveUser();

                if (dt.Rows.Count > 0)
                {
                    UpdatePassword();
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");                    
                }
                else
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>ErrorOk();</script>");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePassword()
        {
            try
            {
                LoginManagement obj = new LoginManagement();
                obj.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
                obj.Password = txtNewPassword.Text;
                obj.Sp_Operation = "RESET_PASSWORD";
                DataTable dt = new DataTable();
                dt = obj.SaveUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Events"

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            GetOldPassword();            
        }
        #endregion

       
    }
}