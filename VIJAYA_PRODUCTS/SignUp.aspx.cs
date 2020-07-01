using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using StarCity.DAL.SITE_DETAILS;
using StarCity.DAL.LOGIN_DETAILS;
using NewStarCity.DAL.USER_AUTHENTICATE_LINK;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;

#endregion
namespace RCandJJ
{
    public partial class SignUp : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public function

        public void SiteNameBind()
        {
            try
            {
                SiteManagement bindref = new SiteManagement();
                bindref.SpOperation = "BIND_SITE_NAME";
                DataTable dtRef = new DataTable();
                dtRef = bindref.SaveSite();
                ddlSite.DataSource = dtRef;
                ddlSite.DataTextField = "SITE_NAME";
                ddlSite.DataValueField = "SITE_ID";
                ddlSite.DataBind();
                ddlSite.Items.Insert(0, new ListItem("-Select Site Name-", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertUser()
        {
            try
            {
                LoginManagement objUser = new LoginManagement();
                objUser.User_Name = txtName.Text;
                objUser.Email_Id = txtEmailId.Text;
                objUser.Mobile_No = txtMobileNo.Text;
                objUser.Site_Id = Convert.ToInt32(ddlSite.SelectedItem.Value);
                objUser.Password = txtPassword.Text;

                objUser.Sp_Operation = "INSERT_NEW_USER";
                DataTable dtTd = new DataTable();
                dtTd = objUser.SaveUser();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertAuthenticateLink()
        {
            try
            {
                User_Authenticate_Link_Management objLink = new User_Authenticate_Link_Management();

                if (checkMarketing.Checked)
                {
                    objLink.Column_1 = "YES";
                }
                else
                {
                    objLink.Column_1 = "NO";
                }

                if (checkPurchase.Checked)
                {
                    objLink.Column_2 = "YES";
                }
                else
                {
                    objLink.Column_2 = "NO";
                }

                if (checkSite.Checked)
                {
                    objLink.Column_3 = "YES";
                }
                else
                {
                    objLink.Column_3 = "NO";
                }

                if (checkEngineering.Checked)
                {
                    objLink.Column_4 = "YES";
                }
                else
                {
                    objLink.Column_4 = "NO";
                }

                objLink.Sp_Operation = "INSER_AUTHENTICATE_LINK";
                DataTable dtlink = new DataTable();
                dtlink = objLink.SaveUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetUserDetails()
        {
            try
            {
                LoginManagement objUser = new LoginManagement();
                objUser.User_Id = Convert.ToInt32(Request.QueryString["userid"]);
                objUser.Sp_Operation = "GET_LOGIN_REPORT";
                DataTable dtTd = new DataTable();
                dtTd = objUser.SaveUser();

                if (dtTd.Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(dtTd.Rows[0]["USER_NAME"]);
                    txtEmailId.Text = Convert.ToString(dtTd.Rows[0]["EMAIL_ID"]);
                    txtMobileNo.Text = Convert.ToString(dtTd.Rows[0]["MOBILE_NO"]);

                    txtPassword.Attributes.Add("Value", Convert.ToString(dtTd.Rows[0]["PASSWORD"]));

                    ddlSite.SelectedItem.Value = Convert.ToString(dtTd.Rows[0]["SITE_ID"]);
                    ddlSite.SelectedItem.Text = Convert.ToString(dtTd.Rows[0]["SITE_NAME"]);

                    if (Convert.ToString(dtTd.Rows[0]["COLUMN_1"]) == "YES")
                    {
                        checkMarketing.Checked = true;
                    }

                    if (Convert.ToString(dtTd.Rows[0]["COLUMN_2"]) == "YES")
                    {
                        checkPurchase.Checked = true;
                    }

                    if (Convert.ToString(dtTd.Rows[0]["COLUMN_3"]) == "YES")
                    {
                        checkSite.Checked = true;
                    }

                    if (Convert.ToString(dtTd.Rows[0]["COLUMN_4"]) == "YES")
                    {
                        checkEngineering.Checked = true;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateLoginDetails()
        {
            try
            {
                LoginManagement objUser = new LoginManagement();
                objUser.User_Name = txtName.Text;
                objUser.Email_Id = txtEmailId.Text;
                objUser.Mobile_No = txtMobileNo.Text;
                objUser.Site_Id = Convert.ToInt32(ddlSite.SelectedItem.Value);
                objUser.Password = txtPassword.Text;
                objUser.User_Id = Convert.ToInt32(Request.QueryString["userid"]);
                objUser.Sp_Operation = "UPDATE_USER";
                objUser.SaveUser();

                User_Authenticate_Link_Management objLink = new User_Authenticate_Link_Management();

                if (checkMarketing.Checked)
                {
                    objLink.Column_1 = "YES";
                }
                else
                {
                    objLink.Column_1 = "NO";
                }

                if (checkPurchase.Checked)
                {
                    objLink.Column_2 = "YES";
                }
                else
                {
                    objLink.Column_2 = "NO";
                }

                if (checkSite.Checked)
                {
                    objLink.Column_3 = "YES";
                }
                else
                {
                    objLink.Column_3 = "NO";
                }

                if (checkEngineering.Checked)
                {
                    objLink.Column_4 = "YES";
                }
                else
                {
                    objLink.Column_4 = "NO";
                }

                objLink.Sp_Operation = "UPDATE_AUTHENTICATE";
                objLink.User_Id = Convert.ToInt32(Request.QueryString["userid"]);
                objLink.SaveUser();
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
                SiteNameBind();

                if (Request.QueryString["userid"] != null)
                {
                    GetUserDetails();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (checkMarketing.Checked == false && checkPurchase.Checked == false && checkSite.Checked == false && checkEngineering.Checked == false)
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningOk();</script>");
            }
            else
            {
                if (Request.QueryString["userid"] != null)
                {
                    UpdateLoginDetails();
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateOk();</script>");
                }
                else
                {
                    InsertUser();
                    InsertAuthenticateLink();
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
                }
                txtName.Text = "";
                txtMobileNo.Text = "";
                txtEmailId.Text = "";
                txtPassword.Text = "";
                txtPassword.Attributes.Add("Value", "");
                txtConfirmPassword.Text = "";
                ddlSite.SelectedItem.Value = "0";
                ddlSite.SelectedItem.Text = "-Select Site Name-";
                
            }
        }

        #endregion
    }
}