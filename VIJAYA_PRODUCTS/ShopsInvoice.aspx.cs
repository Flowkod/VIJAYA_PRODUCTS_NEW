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
using System.Configuration;
using VIJAYA_PRODUCTS.DAL;

#endregion
namespace VIJAYA_PRODUCTS
{
    public partial class ShopsInvoice : System.Web.UI.Page
    {
        #region "Variable"

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion
        public void GetInvoice_id()
        {
            Invoice_Management objInvoice = new Invoice_Management();
            objInvoice.User_Id= Convert.ToInt32(Request.Cookies["UserID"].Value);
            objInvoice.Date = Convert.ToDateTime(txtCalender.Text);
            objInvoice.Sp_Operation = "GET_INVOICE_ID";
            DataTable dtInvoice = new DataTable();
            dtInvoice = objInvoice.SaveUser();
            if(dtInvoice.Rows.Count > 0)
            {
                lblInvoiceId.Text = Convert.ToString(dtInvoice.Rows[0]["INVOICE_ID"]);
            }
        }
        public void GetClientProduct()
        {
            try
            {
                Invoice_Product_Management objProduct = new Invoice_Product_Management();
                objProduct.Sp_Operation = "GET_PRODUCT";
                objProduct.Invoice_Id = Convert.ToInt32(lblInvoiceId.Text);

                DataTable dtProduct = new DataTable();
                dtProduct = objProduct.SaveUser();

                if (dtProduct.Rows.Count > 0)
                {
                    grdProduct.DataSource = dtProduct;
                    grdProduct.DataBind();

                    Invoice_Product_Management objProductTotal = new Invoice_Product_Management();
                    
                    objProductTotal.Sp_Operation = "GET_PRODUCT_TOTAL_BY_CLIENT";
                    objProductTotal.Invoice_Id= Convert.ToInt32(lblInvoiceId.Text);

                    DataTable dtProductTotal = new DataTable();
                    dtProductTotal = objProductTotal.SaveUser();

                    if (dtProductTotal.Rows.Count > 0)
                    {
                        txtTotal.Text = Convert.ToString(dtProductTotal.Rows[0]["TOTAL"]);
                       

                        txtCGSTAmount.Text = Convert.ToString(dtProductTotal.Rows[0]["CGST"]);
                        txtSGSTAmount.Text = Convert.ToString(dtProductTotal.Rows[0]["SGST"]);

                        txtGrandTotal.Text = Convert.ToString(dtProductTotal.Rows[0]["GRAND_TOTAL"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
        public void InsertToInvoice(string is_print)
        {

            if(txtTotal.Text == "")
            {
                txtTotal.Text ="0";
            }
            if (txtGrandTotal.Text == "")
            {
                txtGrandTotal.Text = "0";
            }


            Invoice_Management objUser = new Invoice_Management();
            objUser.Invoice_Id = Convert.ToInt32(lblInvoiceId.Text);
            objUser.Customer_Name = txtName.Text;
            objUser.shop1 = txtShop1.Text;
            objUser.shop2 = txtShop2.Text;
            objUser.shop3 = txtShop3.Text;
            //objUser.Invoice_No = txtInvoiceNo.Text;
            objUser.Date = Convert.ToDateTime(txtCalender.Text);
            objUser.Product_Name = txtParticular.Text;
            objUser.Is_print = is_print;
           
            objUser.Total =Convert.ToDouble( txtTotal.Text);
            objUser.Grand_Total =Convert.ToDouble(txtGrandTotal.Text);

            if (txtCGSTAmount.Text != "")
            {
                objUser.Cgst_Per = Convert.ToDouble(txtCGSTPer.Text);
                objUser.Cgst= Convert.ToDouble(txtCGSTAmount.Text);
            }

            if (txtSGSTAmount.Text != "")
            {
                objUser.Sgst_Per = Convert.ToDouble(txtSGSTPer.Text);
                objUser.Sgst= Convert.ToDouble(txtCGSTAmount.Text);
            }

            objUser.Sp_Operation = "INSERT_INVOICE";
            objUser.SaveUser();
        }
        public void InsertInvoiceProduct(int id, double qty1, double qty2, double qty3, string Date, double rate)
        {
            try
            {
               Invoice_Product_Management objPro1 = new Invoice_Product_Management();
                objPro1.Invoice_product_id = id;
                objPro1.Invoice_Id = Convert.ToInt32(lblInvoiceId.Text);
                objPro1.Qty1 = qty1;
                objPro1.Qty2 = qty2;
                objPro1.Qty3 = qty3;
                objPro1.Rate = rate;
                //objPro1.Shop_Id = Convert.ToInt32(hidShopId.Value);
                objPro1.Date = Date;
                objPro1.Sp_Operation = "INSERT_INVOICE_PRODUCT";
                DataTable dtUser1 = new DataTable();
                dtUser1 = objPro1.SaveUser();
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
                Invoice_Product_Management objPro1 = new Invoice_Product_Management();
                objPro1.Invoice_product_id = purchase_product_id;
                objPro1.Sp_Operation = "DELETE_INVOICE_PRODUCT";
                DataTable dtUser1 = new DataTable();
                dtUser1 = objPro1.SaveUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteInvoiceIfNotSave()
        {
            try
            {
                Invoice_Management objDeletePurchase = new Invoice_Management();
                objDeletePurchase.Sp_Operation = "DELETE_INVOICE_IF_NOT_SAVE";
                objDeletePurchase.SaveUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime serverTime = DateTime.Now;
                DateTime utcTime = serverTime.ToUniversalTime();
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                string s = localTime.ToString("dd MMM yyy");
                txtCalender.Text = s;

                DeleteInvoiceIfNotSave();
                GetInvoice_id();
                GetClientProduct();
            }
        }

        protected void ProductContent_TextChange(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
            string id = grdProduct.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdProduct.Rows[selRowIndex];

            
           TextBox date= (row.FindControl("txtDate") as TextBox);
          
            TextBox qty1 = (row.FindControl("txtQty1") as TextBox);
            TextBox qty2 = (row.FindControl("txtQty2") as TextBox);
            TextBox qty3 = (row.FindControl("txtQty3") as TextBox);

            TextBox Rate = (row.FindControl("txtRate") as TextBox);
           

            if (qty1.Text == "")
            {
                qty1.Text = "0";
            }

            if (qty2.Text == "")
            {
                qty2.Text = "0";
            }

            if (qty3.Text == "")
            {
                qty3.Text = "0";
            }

            if (Rate.Text == "")
            {
                Rate.Text = "0";
            }

            double rate = Convert.ToDouble(Rate.Text);           
            

            InsertInvoiceProduct(Convert.ToInt32(id),Convert.ToDouble(qty1.Text),Convert.ToDouble(qty2.Text),Convert.ToDouble(qty3.Text), date.Text, rate);
            GetClientProduct();

            TextBox txt = sender as TextBox;
            if (txt.ID == "txtDate")
            {
                qty1.Focus();
            }

            if (txt.ID == "txtQty1")
            {
                qty2.Focus();
            }

            if (txt.ID == "txtQty2")
            {
                qty3.Focus();
            }

            if (txt.ID == "txtQty3")
            {
                Rate.Focus();
            }


            ScriptManager.RegisterStartupScript(
                       UpdatePanel1,
                       this.GetType(),
                       "MyAction",
                       "auto();",
                       true);
        }

        protected void InvoiceContentChange(object sender, EventArgs e)
        {
            InsertToInvoice("");

            Invoice_Product_Management objProductTotal = new Invoice_Product_Management();

            objProductTotal.Sp_Operation = "GET_PRODUCT_TOTAL_BY_CLIENT";
            objProductTotal.Invoice_Id = Convert.ToInt32(lblInvoiceId.Text);

            DataTable dtProductTotal = new DataTable();
            dtProductTotal = objProductTotal.SaveUser();

            if (dtProductTotal.Rows.Count > 0)
            {
                txtTotal.Text = Convert.ToString(dtProductTotal.Rows[0]["TOTAL"]);


                txtCGSTAmount.Text = Convert.ToString(dtProductTotal.Rows[0]["CGST"]);
                txtSGSTAmount.Text = Convert.ToString(dtProductTotal.Rows[0]["SGST"]);

                txtGrandTotal.Text = Convert.ToString(dtProductTotal.Rows[0]["GRAND_TOTAL"]);
            }
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertToInvoice("True");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "newpage", "customOpen('ShopInvPrint.aspx?inv=" +lblInvoiceId.Text + "');", true);
        }
        
    }
}