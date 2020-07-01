using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion
namespace VIJAYA_PRODUCTS.DAL
{
    public class Invoice_Management
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region"Properties"

       
        public int Invoice_Id { get;set; }
        public int User_Id { get; set; }
        public string Customer_Name { get; set; }
        public string Product_Name { get; set; }
        public string Invoice_No {  get; set; }
        public DateTime Date {  get; set; }
        public DateTime To_date { get; set; }
        public double Gst { get; set; }
        public double Total  { get; set; }
        public double Net_Total {  get; set; }
        public double Round_Off { get; set; }
        public double Grand_Total { get;  set; }
        public double Cgst_Per { get; set; }
        public double Sgst_Per { get; set; }
        public double Cgst { get; set; }
        public double Sgst { get; set; }
        public string shop1 { get; set; }
        public string shop2 { get; set; }
        public string shop3 { get; set; }
        public string Sp_Operation { get; set; }
        public string Is_print { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Invoice_Id > 0)
                Command.Parameters.Add(new SqlParameter("@INVOICE_ID", SqlDbType.Int)).Value = Invoice_Id;
            else
                Command.Parameters.Add(new SqlParameter("@INVOICE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (User_Id > 0)
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = User_Id;
            else
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Customer_Name != String.Empty && Customer_Name != null)
                Command.Parameters.Add(new SqlParameter("@CUSTOMER_NAME", SqlDbType.VarChar)).Value = Customer_Name;
            else
                Command.Parameters.Add(new SqlParameter("@CUSTOMER_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Product_Name != String.Empty && Product_Name != null)
                Command.Parameters.Add(new SqlParameter("@PRODUCT_NAME", SqlDbType.VarChar)).Value = Product_Name;
            else
                Command.Parameters.Add(new SqlParameter("@PRODUCT_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Date != null && Date != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.DateTime)).Value = Date;
            else
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (To_date != null && To_date != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = To_date;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (Invoice_No != String.Empty && Invoice_No != null)
                Command.Parameters.Add(new SqlParameter("@INVOICE_NO", SqlDbType.VarChar)).Value = Invoice_No;
            else
                Command.Parameters.Add(new SqlParameter("@INVOICE_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Total >= 0)
                Command.Parameters.Add(new SqlParameter("@TOTAL", SqlDbType.Decimal)).Value = Total;
            else
                Command.Parameters.Add(new SqlParameter("@TOTAL", SqlDbType.Decimal)).Value = DBNull.Value;
            if (Net_Total > 0)
                Command.Parameters.Add(new SqlParameter("@NET_TOTAL", SqlDbType.Decimal)).Value = Net_Total;
            else
                Command.Parameters.Add(new SqlParameter("@NET_TOTAL", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Round_Off > 0)
                Command.Parameters.Add(new SqlParameter("@ROUND_OFF", SqlDbType.Decimal)).Value = Round_Off;
            else
                Command.Parameters.Add(new SqlParameter("@ROUND_OFF", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Grand_Total >= 0)
                Command.Parameters.Add(new SqlParameter("@GRAND_TOTAL", SqlDbType.Decimal)).Value = Grand_Total;
            else
                Command.Parameters.Add(new SqlParameter("@GRAND_TOTAL", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Cgst > 0)
                Command.Parameters.Add(new SqlParameter("@CGST", SqlDbType.Decimal)).Value = Cgst;
            else
                Command.Parameters.Add(new SqlParameter("@CGST", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Sgst > 0)
                Command.Parameters.Add(new SqlParameter("@SGST", SqlDbType.Decimal)).Value = Sgst;
            else
                Command.Parameters.Add(new SqlParameter("@SGST", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Sgst_Per > 0)
                Command.Parameters.Add(new SqlParameter("@SGST_PER", SqlDbType.Decimal)).Value = Sgst_Per;
            else
                Command.Parameters.Add(new SqlParameter("@SGST_PER", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Cgst_Per > 0)
                Command.Parameters.Add(new SqlParameter("@CGST_PER", SqlDbType.Decimal)).Value = Cgst_Per;
            else
                Command.Parameters.Add(new SqlParameter("@CGST_PER", SqlDbType.Decimal)).Value = DBNull.Value;

            if (shop1 != String.Empty && shop1 != null)
                Command.Parameters.Add(new SqlParameter("@SHOP1", SqlDbType.VarChar)).Value = shop1;
            else
                Command.Parameters.Add(new SqlParameter("@SHOP1", SqlDbType.VarChar)).Value = DBNull.Value;
            if (shop2 != String.Empty && shop2 != null)
                Command.Parameters.Add(new SqlParameter("@SHOP2", SqlDbType.VarChar)).Value = shop2;
            else
                Command.Parameters.Add(new SqlParameter("@SHOP2", SqlDbType.VarChar)).Value = DBNull.Value;
            if (shop3 != String.Empty && shop3 != null)
                Command.Parameters.Add(new SqlParameter("@SHOP3", SqlDbType.VarChar)).Value = shop3;
            else
                Command.Parameters.Add(new SqlParameter("@SHOP3", SqlDbType.VarChar)).Value = DBNull.Value;
            if (Is_print != String.Empty && Is_print != null)
                Command.Parameters.Add(new SqlParameter("@IS_PRINT", SqlDbType.VarChar)).Value = Is_print;
            else
                Command.Parameters.Add(new SqlParameter("@IS_PRINT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Sp_Operation != string.Empty && Sp_Operation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = Sp_Operation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveUser()
        {
            cmd = new SqlCommand("INVOICE_MANAGEMENT", con);
            AddwithParameter(cmd);
            DataTable dtUser = new DataTable();

            cmd.CommandType = CommandType.StoredProcedure;

            sda = new SqlDataAdapter(cmd);
            sda.Fill(dtUser);

            return dtUser;

        }

        #endregion
    }
}