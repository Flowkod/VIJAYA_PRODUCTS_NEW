using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using KumarGas.DAL.CLIENT_RAGISTER;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Configuration;
using KumarGas.DAL.CLIENT_RATE_PRODUCT;
using SUPPLY_MANAGEMENT.DAL;
using RCandJJ.DAL;
#endregion

namespace RCandJJ
{
    public partial class AddCustomer1 : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public string CreateRabdomString()
        {
            sda = new SqlDataAdapter("SELECT MAX(CLIENT_ID) AS CLIENT_ID FROM CUSTOMER_RAGISTRATION", scon);
            DataTable dtCl = new DataTable();
            sda.Fill(dtCl);

            if (Convert.ToString(dtCl.Rows[0]["CLIENT_ID"]) != "")
            {

                string id = Convert.ToString(dtCl.Rows[0]["CLIENT_ID"]).Substring(2);

                int id_count = Convert.ToInt32(id).ToString().Length;

                string substring = "YS";

                for (int i = id_count; i < 5; i++)
                {
                    substring += "0";
                }

                return substring + Convert.ToString(Convert.ToInt32(id) + 1);
            }
            else
            {
                return "YS00001";
            }
        }

        public void InsertCustomer(string save)
        {
            try
            {
                Client_Ragister_Management objClient = new Client_Ragister_Management();
                objClient.Customer_Id = Convert.ToInt32(Session["CustomerID"]);
                objClient.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                objClient.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
                objClient.Customer_Name = txtCustomerName.Text;
                objClient.Address = txtAddress.Text;
                objClient.Mobile_No = txtMobileNo.Text;
                objClient.Email_Id = txtEmailId.Text;
                objClient.Gst_No = txtGSTNo.Text;
                objClient.FSSAI_NO = txtFssai.Text;
                objClient.DELIVERY_ADDRESS1 = txtDeliveryAddress.Text;
                //objClient.Contact_Person = txtContactPerson.Text;
                //objClient.Pan_no = txtPanNo.Text;

                objClient.Sp_Operation = "INSERT_NEW_CUSTOMER";

                DataTable dtClient = new DataTable();
                dtClient = objClient.SaveCustomer();

                if (dtClient.Rows.Count > 0)
                {
                    Session["CustomerID"] = dtClient.Rows[0]["CUSTOMER_ID"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertSessionData()
        {
            try
            {
                ClientRateProductManagement obj = new ClientRateProductManagement();
                obj.Sp_Operation = "INSERT_SESSION_DATA";
                DataTable dt = new DataTable();
                dt = obj.SaveUser();

                if (dt.Rows.Count > 0)
                {
                    lblID.Text = Convert.ToString(dt.Rows[0]["ID"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindGridData()
        {
            try
            {
                ClientRateProductManagement obj = new ClientRateProductManagement();
                obj.Sp_Operation = "BIND_GRID_DATA_BY_CUSTOMER";
                obj.Customer_Id = Convert.ToInt32(Session["CustomerID"]);
                obj.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                DataTable dt = new DataTable();
                dt = obj.SaveUser();

                if (dt.Rows.Count > 0)
                {
                    DataRow dtr = dt.NewRow();
                    dt.Rows.InsertAt(dtr, dt.Rows.Count + 1);

                    grdCustomerProduct.DataSource = dt;
                    grdCustomerProduct.DataBind();
                }
                else
                {
                    sda = new SqlDataAdapter("SELECT 0 AS ID,NULL AS MATERIAL_NAME,NULL AS RATE,NULL AS GST_id,NULL AS GST", scon);
                    dt = new DataTable();
                    sda.Fill(dt);
                    grdCustomerProduct.DataSource = dt;
                    grdCustomerProduct.DataBind();
                }

                Session["DataSource"] = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetCustomerData()
        {
            try
            {
                Client_Ragister_Management objCust = new Client_Ragister_Management();
                objCust.Customer_Id = Convert.ToInt32(Request.QueryString["cid"]);
                objCust.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                objCust.Sp_Operation = "GET_EDIT_CLIENT_ID";
                DataTable dtCust = new DataTable();
                dtCust = objCust.SaveCustomer();

                if (dtCust.Rows.Count > 0)
                {
                    txtAddress.Text = Convert.ToString(dtCust.Rows[0]["ADDRESS"]);
                    txtDeliveryAddress.Text = Convert.ToString(dtCust.Rows[0]["DELIVERY_ADDRESS"]);
                    txtCustomerName.Text = Convert.ToString(dtCust.Rows[0]["CUSTOMER_NAME"]);
                    txtEmailId.Text = Convert.ToString(dtCust.Rows[0]["EMAIL_ID"]);
                    txtMobileNo.Text = Convert.ToString(dtCust.Rows[0]["MOBILE_NO"]);
                    //txtContactPerson.Text = Convert.ToString(dtCust.Rows[0]["CONTACT_PERSON"]);
                    txtGSTNo.Text = Convert.ToString(dtCust.Rows[0]["GST_NO"]);
                   // txtPanNo.Text = Convert.ToString(dtCust.Rows[0]["PAN_NO"]);
                    txtFssai.Text = Convert.ToString(dtCust.Rows[0]["FSSAI_NO"]);
                    Session["CustomerID"] = Convert.ToInt32(Request.QueryString["cid"]);
                    BindGridData();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetMaterialid(string material_name)
        {
            Material_management objMaterial = new Material_management();
            objMaterial.Material_name = material_name;
            objMaterial.SpOperation = "GET_MATERIAL_NAME";

            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            if (dtMaterial.Rows.Count > 0)
            {
                return Convert.ToInt32(dtMaterial.Rows[0]["MATERIAL_ID"]);
            }
            else
            {
                return 0;
            }
        }

        public void InsertCustomerProduct(int id, string Product_name, double rate)
        {
            ClientRateProductManagement objPro = new ClientRateProductManagement();
            objPro.Id = id;
            objPro.Customer_Id = Convert.ToInt32(Session["CustomerID"]);
            objPro.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            objPro.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
            objPro.Material_Id = GetMaterialid(Product_name);
            objPro.Rate = rate;
         //   objPro.Gst_id = gst;

            objPro.Sp_Operation = "INSERT_NEW_CLIENT_RATE_PRODUCT";

            DataTable dtPro = new DataTable();
            dtPro = objPro.SaveUser();

            BindGridData();
        }

        #endregion

        #region "Event"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["SiteID"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            if (!IsPostBack)
            {
                Session["CustomerID"] = null;
                BindGridData();

                if (Request.QueryString["cid"] != null)
                {
                    GetCustomerData();
                }
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;

                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "SELECT MATERIAL_NAME from MATERIAL WHERE MATERIAL_NAME LIKE '%'+@MATARIALTYPE+'%' ORDER BY MATERIAL_NAME ASC";

                    com.Parameters.AddWithValue("@MATARIALTYPE", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> MemberName = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            MemberName.Add(sdr["MATERIAL_NAME"].ToString());
                        }
                    }
                    con.Close();
                    return MemberName;
                }
            }

        }

        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerName.Text != "")
            {
                InsertCustomer("");
                int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
                string id = grdCustomerProduct.DataKeys[selRowIndex].Value.ToString();
                GridViewRow row = grdCustomerProduct.Rows[selRowIndex];

                TextBox txtProductName = (row.FindControl("txtProductName") as TextBox);
                TextBox txtRate = (row.FindControl("txtRate") as TextBox);
                //DropDownList ddlGst = (row.FindControl("ddlGst") as DropDownList);

                if (id == "")
                {
                    id = "0";
                }

                if (txtRate.Text == "")
                {
                    txtRate.Text = "0";
                }

                //if (txtGst.Text == "")
                //{
                //    txtGst.Text = "0";
                //}

                InsertCustomerProduct(Convert.ToInt32(id), txtProductName.Text, Convert.ToDouble(txtRate.Text));


                for (int i = 0; i < grdCustomerProduct.Rows.Count - 1; i++)
                {
                    TextBox nexTextbox = grdCustomerProduct.Rows[i + 1].Cells[0].FindControl("txtProductName") as TextBox;
                    nexTextbox.Focus();
                }
            }

            BindGridData();
        }

        protected void txtGst_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerName.Text != "")
            {
                int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
                string id = grdCustomerProduct.DataKeys[selRowIndex].Value.ToString();
                GridViewRow row = grdCustomerProduct.Rows[selRowIndex];

                TextBox txtProductName = (row.FindControl("txtProductName") as TextBox);
                TextBox txtRate = (row.FindControl("txtRate") as TextBox);
                TextBox txtGst = (row.FindControl("txtGst") as TextBox);

                if (id == "")
                {
                    id = "0";
                }

                if (txtRate.Text == "")
                {
                    txtRate.Text = "0";
                }

                if (txtGst.Text == "")
                {
                    txtGst.Text = "0";
                }

                InsertCustomerProduct(Convert.ToInt32(id), txtProductName.Text, Convert.ToDouble(txtRate.Text));


                for (int i = 0; i < grdCustomerProduct.Rows.Count - 1; i++)
                {
                    TextBox nexTextbox = grdCustomerProduct.Rows[i + 1].Cells[0].FindControl("txtProductName") as TextBox;
                    nexTextbox.Focus();
                }
            }

            BindGridData();
        }

        protected void ddlGst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txtCustomerName.Text != "")
            //{
            //    int selRowIndex = ((GridViewRow)(((DropDownList)sender).Parent.Parent)).RowIndex;
            //    string id = grdCustomerProduct.DataKeys[selRowIndex].Value.ToString();
            //    GridViewRow row = grdCustomerProduct.Rows[selRowIndex];

            //    TextBox txtProductName = (row.FindControl("txtProductName") as TextBox);
            //    TextBox txtRate = (row.FindControl("txtRate") as TextBox);
            //    DropDownList ddlGst = (row.FindControl("ddlGst") as DropDownList);

            //    if (id == "")
            //    {
            //        id = "0";
            //    }

            //    if (txtRate.Text == "")
            //    {
            //        txtRate.Text = "0";
            //    }

            //    //if (txtGst.Text == "")
            //    //{
            //    //    txtGst.Text = "0";
            //    //}

            //    InsertCustomerProduct(Convert.ToInt32(id), txtProductName.Text, Convert.ToDouble(txtRate.Text));

            //    for (int i = 0; i < grdCustomerProduct.Rows.Count - 1; i++)
            //    {
            //        TextBox nexTextbox = grdCustomerProduct.Rows[i + 1].Cells[0].FindControl("txtProductName") as TextBox;
            //        nexTextbox.Focus();
            //    }
            //}

            BindGridData();
        }

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerName.Text != "")
            {
                int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
                string id = grdCustomerProduct.DataKeys[selRowIndex].Value.ToString();
                GridViewRow row = grdCustomerProduct.Rows[selRowIndex];

                TextBox txtProductName = (row.FindControl("txtProductName") as TextBox);
                TextBox txtRate = (row.FindControl("txtRate") as TextBox);
               // DropDownList ddlGst = (row.FindControl("ddlGst") as DropDownList);

                if (id == "")
                {
                    id = "0";
                }

                if (txtRate.Text == "")
                {
                    txtRate.Text = "0";
                }

                //if (txtGst.Text == "")
                //{
                //    txtGst.Text = "0";
                //}

                InsertCustomerProduct(Convert.ToInt32(id), txtProductName.Text, Convert.ToDouble(txtRate.Text));



                for (int i = 0; i < grdCustomerProduct.Rows.Count - 1; i++)
                {
                    TextBox nexTextbox = grdCustomerProduct.Rows[i + 1].Cells[0].FindControl("txtProductName") as TextBox;
                    nexTextbox.Focus();
                }
            }

            BindGridData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InsertCustomer("True");
            txtCustomerName.Text = "";
            txtMobileNo.Text = "";
            txtEmailId.Text = "";
            txtGSTNo.Text = "";
            txtAddress.Text = "";
            //txtContactPerson.Text = "";           
            Session["CustomerID"] = null;
            BindGridData();

            if (Request.QueryString["cid"] != null)
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdatedOk();</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
            }
        }

        protected void btnDelete(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdCustomerProduct.DataKeys[selRowIndex].Value.ToString();

            if (id != "")
            {
                ClientRateProductManagement objProduct = new ClientRateProductManagement();
                objProduct.Id = Convert.ToInt32(id);
                objProduct.Sp_Operation = "DELETE_PRODUCT";
                objProduct.SaveUser();
                BindGridData();
            }
        }

        protected void grdCustomerProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
              //  DropDownList ddlGst = (e.Row.FindControl("ddlGst") as DropDownList);
               // ddlGst.Visible = true;

                Label lblGST = (e.Row.FindControl("lblGST") as Label);

                Label lblGST_ID = (e.Row.FindControl("lblGST_ID") as Label);

                Gst_Details objPro = new Gst_Details();
                objPro.SpOperation = "GET_GST";
                DataTable dtRef = new DataTable();
                dtRef = objPro.SaveGST();
                //ddlGst.DataSource = dtRef;
                //ddlGst.DataTextField = "GST";
                //ddlGst.DataValueField = "GST_ID";
                //ddlGst.DataBind();
                //ddlGst.Items.Insert(0, new ListItem("- Select GST% -", "0"));

                //if (lblGST.Text != "")
                //{
                //    ddlGst.SelectedItem.Text = lblGST.Text;
                //    ddlGst.SelectedItem.Value = lblGST_ID.Text;
                //}
            }

        }

        #endregion
    }
}