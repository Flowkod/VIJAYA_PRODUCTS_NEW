using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using NewStarCity.DAL.PO_DRAFT;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using AdeesEnergy.DAL.SendSMS;
using StarCity.DAL.SITE_DETAILS;
using System.Configuration;
using KumarGas.DAL.CLIENT_RAGISTER;
using SparkInventory.DAL;
using RCandJJ.DAL;
using SUPPLY_MANAGEMENT.DAL;

#endregion

namespace SparkInventory
{
    public partial class Quotation : System.Web.UI.Page
    {
        #region "Variable"

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void GetSiteDetailsAndNo()
        {
            Quotation_Management objPurchase = new Quotation_Management();
            objPurchase.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
            objPurchase.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            objPurchase.Date = Convert.ToDateTime(txtCalender.Text);
            objPurchase.Sp_Operation = "GET_SITE_DETAILS_AND_QUOTATION_NO";
            DataTable dtpo = new DataTable();
            dtpo = objPurchase.SaveUser();

            if (dtpo.Rows.Count > 0)
            {
                lblSite.Text = Convert.ToString(dtpo.Rows[0]["SITE_NAME"]);
                lblDeliveryAddress.Text = Convert.ToString(dtpo.Rows[0]["ADDRESS"]);
                //  txtContactPerson.Text = Convert.ToString(dtpo.Rows[0]["CONTACT_PERSON"]);
                txtgstno.Text = Convert.ToString(dtpo.Rows[0]["GST_NO"]);
                txtPhoneNo.Text = Convert.ToString(dtpo.Rows[0]["MOBILE_NO"]);

                hidHSNCode.Value = Convert.ToString(dtpo.Rows[0]["HSN_CODE"]);
                hidid.Value = Convert.ToString(dtpo.Rows[0]["QUOTATION_NO"]);
                //int id_count = Convert.ToInt32(dtpo.Rows[0]["QUOTATION_NO"]).ToString().Length;
                //string po_no = "";

                //for (int i = id_count; i < 4; i++)
                //{
                //    po_no += "0";
                //}

                //txtPoNo.Text = po_no + Convert.ToString(dtpo.Rows[0]["QUOTATION_NO"]);
            }
        }

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

        public void BindGst()
        {
            Gst_Details objGST = new Gst_Details();
            objGST.SpOperation = "GET_GST";
            DataTable dtGST = new DataTable();
            dtGST = objGST.SaveGST();

            //ddlGst.DataSource = dtGST;
            //ddlGst.DataTextField = "GST";
            //ddlGst.DataValueField = "GST_ID";
            //ddlGst.DataBind();
            //ddlGst.Items.Insert(0, new ListItem("GST%", "0"));
        }

        public void GetClientDetails(int client_id)
        {
            try
            {
                Client_Ragister_Management objCust = new Client_Ragister_Management();
                objCust.Customer_Id = client_id;
                objCust.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                objCust.Sp_Operation = "GET_EDIT_CLIENT_ID";
                DataTable dtCust = new DataTable();
                dtCust = objCust.SaveCustomer();

                if (dtCust.Rows.Count > 0)
                {
                    txtAddress.Text = Convert.ToString(dtCust.Rows[0]["ADDRESS"]);
                    txtDeliveryAddress.Text = Convert.ToString(dtCust.Rows[0]["DELIVERY_ADDRESS"]);
                    txtSupplierEmailID.Text = Convert.ToString(dtCust.Rows[0]["EMAIL_ID"]);
                    //  txtSupplierContactPerson.Text = Convert.ToString(dtCust.Rows[0]["CONTACT_PERSON"]);
                    txtSupplierPhoneNo.Text = Convert.ToString(dtCust.Rows[0]["MOBILE_NO"]);
                    txtSupplierGSTNo.Text = Convert.ToString(dtCust.Rows[0]["GST_NO"]);
                    //txtSupplierPanNo.Text = Convert.ToString(dtCust.Rows[0]["PAN_NO"]);
                    hidFSSAI.Value = Convert.ToString(dtCust.Rows[0]["FSSAI_NO"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetClientProduct()
        {
            try
            {
                Quotation_Product_Management objProduct = new Quotation_Product_Management();
                objProduct.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                objProduct.Sp_Operation = "GET_PRODUCT_BY_QUOTATION";
                objProduct.Quotation_Id = Convert.ToInt32(hidid.Value);

                DataTable dtProduct = new DataTable();
                dtProduct = objProduct.SaveUser();

                if (dtProduct.Rows.Count > 0)
                {
                    grdProduct.DataSource = dtProduct;
                    grdProduct.DataBind();

                    Quotation_Product_Management objProductTotal = new Quotation_Product_Management();
                    objProductTotal.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                    objProductTotal.Sp_Operation = "GET_PRODUCT_TOTAL_BY_CLIENT";
                    objProductTotal.Quotation_Id = Convert.ToInt32(hidid.Value);

                    DataTable dtProductTotal = new DataTable();
                    dtProductTotal = objProductTotal.SaveUser();

                    if (dtProductTotal.Rows.Count > 0)
                    {
                        txtTotal.Text = Convert.ToString(dtProductTotal.Rows[0]["TOTAL"]);
                        txtNet.Text = Convert.ToString(dtProductTotal.Rows[0]["NET_TOTAL"]);

                        txtCGSTAmount.Text = Convert.ToString(dtProductTotal.Rows[0]["CGST_AMOUNT"]);
                        txtSGSTAmount.Text = Convert.ToString(dtProductTotal.Rows[0]["SGST_AMOUNT"]);

                        txtGrandTotal.Text = Convert.ToString(dtProductTotal.Rows[0]["GRAND_TOTAL"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertToPurchaseOrder(string is_print)
        {
            Quotation_Management objUser = new Quotation_Management();
            objUser.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            objUser.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
            objUser.Customer_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
            objUser.Quotation_No = txtPoNo.Text;
            objUser.Quotation_id = Convert.ToInt32(hidid.Value);
            objUser.Date = Convert.ToDateTime(txtCalender.Text);
            objUser.Phone_no = txtPhoneNo.Text;
            objUser.Is_print = is_print;

            //if (txtNetAmountDiscount.Text == "")
            //{
            //    txtNetAmountDiscount.Text = "0";
            //}

            //objUser.Discount = Convert.ToDouble(txtNetAmountDiscount.Text);
            //objUser.transport = txtTransport.Text;
            //objUser.Delivery_Period = txtDelieveryPeriod.Text;
            //objUser.Payment_Terms = txtPaymentTermas.Text;
            //   objUser.Gst_no = txtGST.Text;

            if (txtRoundOff.Text == "")
            {
                txtRoundOff.Text = "0";
            }

            objUser.Round_off = Convert.ToDouble(txtRoundOff.Text);
            //objUser.Note = txtNote.Text;
            //objUser.Gst_id = Convert.ToInt32(ddlGst.SelectedItem.Value);
            objUser.Sp_Operation = "INSERT_QUOTATION_DETAIL";
            objUser.SaveUser();
        }

        public void InsertPurchaseOrderProduct(int id, int product_id, double qty, string unit, string hsncode, double rate,string due_on, int gst_id)
        {
            try
            {
                Quotation_Product_Management objPro1 = new Quotation_Product_Management();
                objPro1.Quotation_product_id = id;
                objPro1.Product_id = product_id;
                objPro1.Qty = qty;
                objPro1.Unit = unit;
                objPro1.Rate = rate;
                objPro1.Due_on = due_on;
                objPro1.Gst_id = gst_id;
                objPro1.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                objPro1.Customer_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objPro1.Quotation_no = txtPoNo.Text;
                objPro1.Quotation_Id = Convert.ToInt32(hidid.Value);
                objPro1.Sp_Operation = "INSERT_QUOTATION_PRODUCT";
                DataTable dtUser1 = new DataTable();
                dtUser1 = objPro1.SaveUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetPoDetailsByPo_no()
        {
            try
            {
                Quotation_Management objUser = new Quotation_Management();
                objUser.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                objUser.Quotation_id = Convert.ToInt32(hidid.Value);
                objUser.Sp_Operation = "GET_QUOTATION_BY_QUOTATION_NO";
                DataTable dtUser = new DataTable();
                dtUser = objUser.SaveUser();

                if (dtUser.Rows.Count > 0)
                {
                    txtPoNo.Text = Convert.ToString(dtUser.Rows[0]["QUOTATION_NO"]);
                    txtPhoneNo.Text = Convert.ToString(dtUser.Rows[0]["COM_PHONE"]);
                    //txtContactPerson.Text = Convert.ToString(dtUser.Rows[0]["CONTACT_PERSON"]);
                    txtCalender.Text = Convert.ToDateTime(dtUser.Rows[0]["DATE"]).ToString("dd MMM yyyy");
                    //txtNote.Text = Convert.ToString(dtUser.Rows[0]["NOTE"]);
                    //txtPaymentTermas.Text = Convert.ToString(dtUser.Rows[0]["PAYMENT_TERMS"]);
                    //txtTransport.Text = Convert.ToString(dtUser.Rows[0]["TRANSPORT"]);
                    //txtGST.Text = Convert.ToString(dtUser.Rows[0]["GST_NO"]);
                    //txtDelieveryPeriod.Text = Convert.ToString(dtUser.Rows[0]["DELIVERY_PERIOD"]);
                    //txtNetAmountDiscount.Text = Convert.ToString(dtUser.Rows[0]["DISCOUNT"]);
                    //txtGstAmount.Text = Convert.ToString(dtUser.Rows[0]["GST_AMOUNT"]);
                    txtRoundOff.Text = Convert.ToString(dtUser.Rows[0]["ROUND_OFF"]);
                    //ddlGst.ClearSelection();

                    //if (Convert.ToString(dtUser.Rows[0]["GST_ID"]) != "")
                    //{
                    //    ddlGst.Items.FindByValue(Convert.ToString(dtUser.Rows[0]["GST_ID"])).Selected = true;
                    //}
                    //else
                    //{
                    //    ddlGst.Items.FindByValue("0").Selected = true;
                    //}

                    if (Convert.ToString(dtUser.Rows[0]["GST"]) != "")
                    {
                        txtCGSTPer.Text = Convert.ToString(Convert.ToDouble(dtUser.Rows[0]["GST"]) / 2);
                        txtSGSTPer.Text = Convert.ToString(Convert.ToDouble(dtUser.Rows[0]["GST"]) / 2);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCustomerData(string save)
        {
            try
            {
                Client_Ragister_Management objClient = new Client_Ragister_Management();
                objClient.Customer_Id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objClient.Customer_Name = auto_select1.SelectedItem.Text;
                objClient.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                objClient.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
                objClient.Address = txtAddress.Text;
                objClient.Mobile_No = txtSupplierPhoneNo.Text;
                objClient.Email_Id = txtSupplierEmailID.Text;
                objClient.Gst_No = txtSupplierGSTNo.Text;
                objClient.DELIVERY_ADDRESS1 = txtDeliveryAddress.Text;
                objClient.FSSAI_NO = hidFSSAI.Value;
                objClient.Sp_Operation = "INSERT_NEW_CUSTOMER";

                DataTable dtClient = new DataTable();
                dtClient = objClient.SaveCustomer();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveProduct(int purchase_product_id)
        {
            try
            {
                Quotation_Product_Management objPro1 = new Quotation_Product_Management();
                objPro1.Quotation_product_id = purchase_product_id;
                objPro1.Sp_Operation = "DELETE_QUOTATION_PRODUCT";
                DataTable dtUser1 = new DataTable();
                dtUser1 = objPro1.SaveUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveMaterial(string material_name)
        {
            Material_management objMaterial = new Material_management();
            objMaterial.Material_name = material_name;
            objMaterial.Created_by = Convert.ToInt32(Request.Cookies["UserID"].Value);
            objMaterial.SpOperation = "INSERT";
            objMaterial.SaveMaterial();

            Material_management objGetMaterial = new Material_management();
            objGetMaterial.Material_name = material_name;
            objGetMaterial.SpOperation = "GET_MATERIAL_NAME";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objGetMaterial.SaveMaterial();

            return Convert.ToInt32(dtMaterial.Rows[0]["MATERIAL_ID"]);
        }

        public int InsertCustomer(string name)
        {
            try
            {
                Client_Ragister_Management objClient = new Client_Ragister_Management();
                objClient.Customer_Id = Convert.ToInt32(Session["CustomerID"]);
                objClient.Site_Id = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                objClient.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
                objClient.Customer_Name = name;
                objClient.Mobile_No = txtSupplierPhoneNo.Text;
                objClient.Email_Id = txtSupplierEmailID.Text;
                objClient.Gst_No = txtSupplierGSTNo.Text;
                objClient.DELIVERY_ADDRESS1 = txtDeliveryAddress.Text;
                objClient.Sp_Operation = "INSERT_NEW_CUSTOMER";

                DataTable dtClient = new DataTable();
                dtClient = objClient.SaveCustomer();

                if (dtClient.Rows.Count > 0)
                {
                    return Convert.ToInt32(dtClient.Rows[0]["CUSTOMER_ID"]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletePurchaseOrderIfNotSave()
        {
            try
            {
                Quotation_Management objDeletePurchase = new Quotation_Management();
                objDeletePurchase.Sp_Operation = "DELETE_QUOTATION_IF_NOT_SAVE";
                objDeletePurchase.SaveUser();
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
            if (Request.Cookies["UserId"] == null)
            {
                Response.Redirect("index.aspx");
            }

            if (Request.Cookies["SiteID"] == null)
            {
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {
                DateTime serverTime = DateTime.Now;
                DateTime utcTime = serverTime.ToUniversalTime();
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                string s = localTime.ToString("dd MMM yyy");
                txtCalender.Text = s;

                DeletePurchaseOrderIfNotSave();
                GetSiteDetailsAndNo();
                BindClient();
                BindGst();

                if (Request.QueryString["po_no"] != null)
                {
                    hidid.Value = Convert.ToString(Request.QueryString["po_no"]);
                    //txtPoNo.Text = Convert.ToString(Request.QueryString["po_no"]);
                    auto_select1.SelectedItem.Value = Convert.ToString(Request.QueryString["cid"]);
                    auto_select1.SelectedItem.Text = Convert.ToString(Request.QueryString["cname"]);
                    GetClientDetails(Convert.ToInt32(auto_select1.SelectedItem.Value));
                    GetPoDetailsByPo_no();
                }
                GetClientProduct();
            }
        }

        protected void ClientName_SelectedIndexchange(object sender, EventArgs e)
        {
            int client_id = 0;

            if (auto_select1.SelectedItem.Value == "")
            {
                client_id = InsertCustomer(hidSearchtext.Value);
                BindClient();
                auto_select1.ClearSelection();
                auto_select1.Items.FindByValue(Convert.ToString(client_id)).Selected = true;
            }
            else
            {
                client_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
            }

            GetClientDetails(client_id);
        }

        protected void Product_SelectedIndexChange(object sender, EventArgs e)
        {
            InsertToPurchaseOrder("");
            int selRowIndex = ((GridViewRow)(((DropDownList)sender).Parent.Parent)).RowIndex;
            string id = grdProduct.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdProduct.Rows[selRowIndex];

            DropDownList Product_id = (row.FindControl("auto_selectProduct") as DropDownList);
            TextBox hsn = (row.FindControl("txthsn") as TextBox);
            TextBox qty = (row.FindControl("txtQty") as TextBox);
            TextBox unit = (row.FindControl("txtUnit") as TextBox);
            TextBox Rate = (row.FindControl("txtRate") as TextBox);
            TextBox Due_on = (row.FindControl("txtDueOn") as TextBox);
            DropDownList ddlgst_id = (row.FindControl("ddlGstRate") as DropDownList);

            hidGstValue.Value = ddlgst_id.SelectedItem.Text;
            hidGstID.Value = ddlgst_id.SelectedItem.Value;

            if (ddlgst_id.SelectedItem.Value != "0")
            {
                txtCGSTPer.Text = Convert.ToString(Convert.ToDouble(ddlgst_id.SelectedItem.Text) / 2);
                txtSGSTPer.Text = Convert.ToString(Convert.ToDouble(ddlgst_id.SelectedItem.Text) / 2);
            }

            //TextBox discount = (row.FindControl("txtDiscount") as TextBox);

            if (qty.Text == "")
            {
                qty.Text = "0";
            }

            if (Rate.Text == "")
            {
                Rate.Text = "0";
            }

            int p_id = 0;

            if (Product_id.SelectedItem.Value == "0")
            {
                p_id = SaveMaterial(hidSearchtext.Value);
            }
            else
            {
                p_id = Convert.ToInt32(Product_id.SelectedItem.Value);
            }

            double quantity = Convert.ToDouble(qty.Text);
            string hsncode = hsn.Text;
            double rate = Convert.ToDouble(Rate.Text);
            //double disc = Convert.ToDouble(discount.Text);
            int gst_id = Convert.ToInt32(ddlgst_id.SelectedItem.Value);

            InsertPurchaseOrderProduct(Convert.ToInt32(id), p_id, quantity, unit.Text, hsncode, rate,Due_on.Text, gst_id);
            GetClientProduct();
            qty.Focus();
            ScriptManager.RegisterStartupScript(
                        UpdatePanel1,
                        this.GetType(),
                        "MyAction",
                        "auto();",
                        true);
        }

        protected void ProductContent_TextChange(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
            string id = grdProduct.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdProduct.Rows[selRowIndex];

            DropDownList Product_id = (row.FindControl("auto_selectProduct") as DropDownList);
            TextBox hsn = (row.FindControl("txthsn") as TextBox);
            TextBox qty = (row.FindControl("txtQty") as TextBox);
            TextBox unit = (row.FindControl("txtUnit") as TextBox);
            TextBox Rate = (row.FindControl("txtRate") as TextBox);
            TextBox Due_on = (row.FindControl("txtDueOn") as TextBox);
            DropDownList ddlgst_id = (row.FindControl("ddlGstRate") as DropDownList);
            //TextBox discount = (row.FindControl("txtDiscount") as TextBox);

            if (qty.Text == "")
            {
                qty.Text = "0";
            }

            if (Rate.Text == "")
            {
                Rate.Text = "0";
            }

            //if (discount.Text == "")
            //{
            //    discount.Text = "0";
            //}

            int p_id = Convert.ToInt32(Product_id.SelectedItem.Value);
            double quantity = Convert.ToDouble(qty.Text);
            string hsncode = hsn.Text;
            double rate = Convert.ToDouble(Rate.Text);
            // double disc = Convert.ToDouble(discount.Text);
            int gst_id = Convert.ToInt32(ddlgst_id.SelectedItem.Value);

            InsertPurchaseOrderProduct(Convert.ToInt32(id), p_id, quantity, unit.Text, hsncode, rate,Due_on.Text, gst_id);
            GetClientProduct();

            TextBox txt = sender as TextBox;
            if (txt.ID == "txtUnit")
            {
                qty.Focus();
            }
            if (txt.ID == "txtQty")
            {
                Rate.Focus();
            }
            //if (txt.ID == "txtRate")
            //{
            //    discount.Focus();
            //}

            ScriptManager.RegisterStartupScript(
                       UpdatePanel1,
                       this.GetType(),
                       "MyAction",
                       "auto();",
                       true);
        }

        protected void RemoveProduct(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdProduct.DataKeys[selRowIndex].Value.ToString();
            RemoveProduct(Convert.ToInt32(id));
            GetClientProduct();
            ScriptManager.RegisterStartupScript(
                        UpdatePanel1,
                        this.GetType(),
                        "MyAction",
                        "auto();",
                        true);
        }

        protected void grdProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlProduct = (e.Row.FindControl("auto_selectProduct") as DropDownList);
                DropDownList ddlGst = (e.Row.FindControl("ddlGstRate") as DropDownList);

                Material_management objMaterial = new Material_management();
                objMaterial.SpOperation = "SELECT";
                DataTable dtMaterial = new DataTable();
                dtMaterial = objMaterial.SaveMaterial();

                ddlProduct.DataSource = dtMaterial;
                ddlProduct.DataValueField = "MATERIAL_ID";
                ddlProduct.DataTextField = "MATERIAL_NAME";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("Select Product ", "0"));

                Gst_Details objGST = new Gst_Details();
                objGST.SpOperation = "GET_GST";
                DataTable dtGST = new DataTable();
                dtGST = objGST.SaveGST();
                ddlGst.DataSource = dtGST;
                ddlGst.DataTextField = "GST";
                ddlGst.DataValueField = "GST_ID";
                ddlGst.DataBind();
                ddlGst.Items.Insert(0, new ListItem("- GST% - ", "0"));

                Label lblProductName = (e.Row.FindControl("lblProductName") as Label);
                Label lblProduct_id = (e.Row.FindControl("lblProduct_id") as Label);

                Label lblGst = (e.Row.FindControl("lblGst") as Label);
                Label lblGst_id = (e.Row.FindControl("lblGst_id") as Label);

                if (hidGstID.Value == "" || hidGstID.Value == "0")
                {
                    hidGstID.Value = lblGst_id.Text;
                    hidGstValue.Value = lblGst.Text;
                }

                if (lblProduct_id.Text != "")
                {
                    ddlProduct.ClearSelection();
                    ddlProduct.Items.FindByValue(lblProduct_id.Text).Selected = true;
                }

                if (hidGstID.Value != "")
                {
                    ddlGst.ClearSelection();
                    ddlGst.Items.FindByValue(hidGstID.Value).Selected = true;
                }

                if (ddlGst.SelectedItem.Value != "0")
                {
                    txtCGSTPer.Text = Convert.ToString(Convert.ToDouble(ddlGst.SelectedItem.Text) / 2);
                    txtSGSTPer.Text = Convert.ToString(Convert.ToDouble(ddlGst.SelectedItem.Text) / 2);
                }

                TextBox txtHsn = (e.Row.FindControl("txthsn") as TextBox);

                if (txtHsn.Text == "")
                {
                    if (hidHSNCode.Value != "")
                    {
                        txtHsn.Text = hidHSNCode.Value;
                    }
                }
            }

        }

        protected void txtContent_Textchanged(object sender, EventArgs e)
        {
            InsertToPurchaseOrder("");
            GetClientProduct();
            ScriptManager.RegisterStartupScript(
                       UpdatePanel1,
                       this.GetType(),
                       "MyAction",
                       "auto();",
                       true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UpdateCustomerData("True");
            InsertToPurchaseOrder("True");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "newpage", "customOpen('QuotationFormPrint.aspx?po_no=" + hidid.Value + "');", true);
        }

        #endregion
    }
}