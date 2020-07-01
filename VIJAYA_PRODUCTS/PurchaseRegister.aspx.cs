using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using INVOICE_DEMO.DAL;

namespace INVOICE_DEMO
{
    public partial class PurchaseRegister : System.Web.UI.Page
    {
        public void SavePurchase()
        {
            try
            {
                Purchase_Register_Managment objPurchase = new Purchase_Register_Managment();
                objPurchase.Invoice_no = txtinvoicenumber.Text;
                objPurchase.Invoice_Date = txtinvoicedate.Text;
                objPurchase.Party_Name = txtpartyname.Text;
                objPurchase.Gst_no = txtgstno.Text;
                //objPurchase.Place_of_Supply = txtplaceofsupply.Text;
                //objPurchase.e_Comm_Gstin = txtecommercegstin.Text;
                //objPurchase.Category = txtCategory.Text;
                //objPurchase.Commodity = txtcommodity.Text;
                objPurchase.Unit = txtunit.Text;
                objPurchase.Quantity = txtquantity.Text;
                objPurchase.Hsn = txtsupply.Text;
                objPurchase.Invoice_Value = txttotalinvoicevalue.Text;
                objPurchase.Taxable_Value = txtnettaxablevalue.Text;
                //objPurchase.Igst_Amt = txtigstamount.Text;
                objPurchase.Cgst_Amt = txtcgstamount.Text;
                objPurchase.Cgst_Rate = txtcgstrate.Text;
                objPurchase.Sgst_Amt = txtsgstamount.Text;
                objPurchase.Sgst_Rate = txtsgstrate.Text;
                objPurchase.Cess_Rate = TXTcessrate.Text;
                objPurchase.Cess_Amt = txtcessamount.Text;
                objPurchase.Rounded_off = txtroundedoff.Text;
                objPurchase.Total_Value = txttotalinvoicevalue.Text;
                objPurchase.Sp_Operation = "INSERT";
                objPurchase.SavePurchase();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SavePurchase();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
        }
    }
}