using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace INVOICE_DEMO.DAL
{
    public class Purchase_Register_Managment
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        public int Purchase_reg_id { get; set; }
        public string Invoice_no { get; set; }
        public string Invoice_Date { get; set; }
        public string To_Date { get; set; }
        public string Party_Name { get; set; }
        public string Gst_no { get; set; }
        public string Place_of_Supply { get; set; }
        public string e_Comm_Gstin { get; set; }
        public string Category { get; set; }
        public string Commodity { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public string Hsn { get; set; }
        public string Invoice_Value { get; set; }
        public string Taxable_Value { get; set; }
        public string Igst_Amt { get; set; }
        public string Cgst_Rate { get; set; }
        public string Cgst_Amt { get; set; }
        public string Sgst_Rate { get; set; }
        public string Sgst_Amt { get; set; }
        public string Cess_Rate { get; set; }
        public string Cess_Amt { get; set; }
        public string Rounded_off { get; set; }
        public string Total_Value { get; set; }
        public string Sp_Operation { get; set; }

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Purchase_reg_id > 0)
                Command.Parameters.Add(new SqlParameter("@PURCHASE_REG_ID", SqlDbType.Int)).Value = Purchase_reg_id;
            else
                Command.Parameters.Add(new SqlParameter("@PURCHASE_REG_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Invoice_no != string.Empty && Invoice_no != null)
                Command.Parameters.Add(new SqlParameter("@INVOICE_NO", SqlDbType.VarChar)).Value = Invoice_no;
            else
                Command.Parameters.Add(new SqlParameter("@INVOICE_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Invoice_Date != string.Empty && Invoice_Date != null)
                Command.Parameters.Add(new SqlParameter("@INVOICE_DATE", SqlDbType.VarChar)).Value = Invoice_Date;
            else
                Command.Parameters.Add(new SqlParameter("@INVOICE_DATE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (To_Date != string.Empty && To_Date != null)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.VarChar)).Value = To_Date;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Party_Name != string.Empty && Party_Name != null)
                Command.Parameters.Add(new SqlParameter("@PARTY_NAME", SqlDbType.VarChar)).Value = Party_Name;
            else
                Command.Parameters.Add(new SqlParameter("@PARTY_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Gst_no != string.Empty && Gst_no != null)
                Command.Parameters.Add(new SqlParameter("@GST_NO", SqlDbType.VarChar)).Value = Gst_no;
            else
                Command.Parameters.Add(new SqlParameter("@GST_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Place_of_Supply != string.Empty && Place_of_Supply != null)
                Command.Parameters.Add(new SqlParameter("@PLACE_OF_SUPPLY", SqlDbType.VarChar)).Value = Place_of_Supply;
            else
                Command.Parameters.Add(new SqlParameter("@PLACE_OF_SUPPLY", SqlDbType.VarChar)).Value = DBNull.Value;

            if (e_Comm_Gstin != string.Empty && e_Comm_Gstin != null)
                Command.Parameters.Add(new SqlParameter("@E_COMM_GSTIN", SqlDbType.VarChar)).Value = e_Comm_Gstin;
            else
                Command.Parameters.Add(new SqlParameter("@E_COMM_GSTIN", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Category != string.Empty && Category != null)
                Command.Parameters.Add(new SqlParameter("@CATEGORY", SqlDbType.VarChar)).Value = Category;
            else
                Command.Parameters.Add(new SqlParameter("@CATEGORY", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Commodity != string.Empty && Commodity != null)
                Command.Parameters.Add(new SqlParameter("@COMMODITY", SqlDbType.VarChar)).Value = Commodity;
            else
                Command.Parameters.Add(new SqlParameter("@COMMODITY", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Unit != string.Empty && Unit != null)
                Command.Parameters.Add(new SqlParameter("@UNIT", SqlDbType.VarChar)).Value = Unit;
            else
                Command.Parameters.Add(new SqlParameter("@UNIT", SqlDbType.VarChar)).Value = DBNull.Value;        

            if (Quantity != string.Empty && Quantity != null)
                Command.Parameters.Add(new SqlParameter("@QUANTITY", SqlDbType.VarChar)).Value = Quantity;
            else
                Command.Parameters.Add(new SqlParameter("@QUANTITY", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Hsn != string.Empty && Hsn != null)
                Command.Parameters.Add(new SqlParameter("@HSN", SqlDbType.VarChar)).Value = Hsn;
            else
                Command.Parameters.Add(new SqlParameter("@HSN", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Invoice_Value != string.Empty && Invoice_Value != null)
                Command.Parameters.Add(new SqlParameter("@INVOICE_VALUE", SqlDbType.VarChar)).Value = Invoice_Value;
            else
                Command.Parameters.Add(new SqlParameter("@INVOICE_VALUE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Taxable_Value != string.Empty && Taxable_Value != null)
                Command.Parameters.Add(new SqlParameter("@TAXABLE_VALUE", SqlDbType.VarChar)).Value = Taxable_Value;
            else
                Command.Parameters.Add(new SqlParameter("@TAXABLE_VALUE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Igst_Amt != string.Empty && Igst_Amt != null)
                Command.Parameters.Add(new SqlParameter("@IGST_AMT", SqlDbType.VarChar)).Value = Igst_Amt;
            else
                Command.Parameters.Add(new SqlParameter("@IGST_AMT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Cgst_Amt != string.Empty && Cgst_Amt != null)
                Command.Parameters.Add(new SqlParameter("@CGST_AMT", SqlDbType.VarChar)).Value = Cgst_Amt;
            else
                Command.Parameters.Add(new SqlParameter("@CGST_AMT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Cgst_Rate != string.Empty && Cgst_Rate != null)
                Command.Parameters.Add(new SqlParameter("@CGST_RATE", SqlDbType.VarChar)).Value = Cgst_Rate;
            else
                Command.Parameters.Add(new SqlParameter("@CGST_RATE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Sgst_Amt != string.Empty && Sgst_Amt != null)
                Command.Parameters.Add(new SqlParameter("@SGST_AMT", SqlDbType.VarChar)).Value = Sgst_Amt;
            else
                Command.Parameters.Add(new SqlParameter("@SGST_AMT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Sgst_Rate != string.Empty && Sgst_Rate != null)
                Command.Parameters.Add(new SqlParameter("@SGST_RATE", SqlDbType.VarChar)).Value = Sgst_Amt;
            else
                Command.Parameters.Add(new SqlParameter("@SGST_RATE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Cess_Rate != string.Empty && Cess_Rate != null)
                Command.Parameters.Add(new SqlParameter("@CESS_RATE", SqlDbType.VarChar)).Value = Cess_Rate;
            else
                Command.Parameters.Add(new SqlParameter("@CESS_RATE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Cess_Amt != string.Empty && Cess_Amt != null)
                Command.Parameters.Add(new SqlParameter("@CESS_AMT", SqlDbType.VarChar)).Value = Cess_Amt;
            else
                Command.Parameters.Add(new SqlParameter("@CESS_AMT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Rounded_off != string.Empty && Rounded_off != null)
                Command.Parameters.Add(new SqlParameter("@ROUNDED_OFF", SqlDbType.VarChar)).Value = Rounded_off;
            else
                Command.Parameters.Add(new SqlParameter("@ROUNDED_OFF", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Total_Value != string.Empty && Total_Value != null)
                Command.Parameters.Add(new SqlParameter("@TOTAL_VALUE", SqlDbType.VarChar)).Value = Total_Value;
            else
                Command.Parameters.Add(new SqlParameter("@TOTAL_VALUE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Sp_Operation != string.Empty && Sp_Operation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = Sp_Operation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SavePurchase()
        {
            cmd = new SqlCommand("PURCHASE_REGISTER_MANAGEMENT", con);
            AddwithParameter(cmd);
            DataTable DataTableMaterial = new DataTable();

            cmd.CommandType = CommandType.StoredProcedure;

            sda = new SqlDataAdapter(cmd);
            sda.Fill(DataTableMaterial);

            return DataTableMaterial;

        }
        #endregion
    }
}