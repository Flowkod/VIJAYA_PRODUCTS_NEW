using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewStarCity.DAL.USER_AUTHENTICATE_LINK;
using System.Data;

namespace RCandJJ
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public void GetAuthenticateLink()
        {
            try
            {
                User_Authenticate_Link_Management objLinkid = new User_Authenticate_Link_Management();
                objLinkid.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
                objLinkid.Sp_Operation = "GET_AUTHENTICATE_LINK";
                DataTable dtLink = new DataTable();
                dtLink = objLinkid.SaveUser();

                if (dtLink.Rows.Count > 0)
                {
                    if (Convert.ToString(dtLink.Rows[0]["COLUMN_1"]) == "NO")
                    {
                        gst.Visible = false;
                    }
                    else
                    {
                        gst.Visible = true;
                    }                   
                    

                    if (Convert.ToString(dtLink.Rows[0]["COLUMN_4"]) == "NO")
                    {
                        client.Visible = false;
                    }
                    else
                    {
                        client.Visible = true;
                    }                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("Index.aspx");
            }         
            
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            HttpCookie UserIDCookie = new HttpCookie("UserID");
            UserIDCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(UserIDCookie);

            Session["UserID"] = null;

            Response.Redirect("~/Index.aspx");
        }
    }
}