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
    public class Invoice_Product_Management
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region"Properties"

        public int Invoice_product_id { get; set; }
        public int Invoice_Id { get; set; }
        public string Date { get; set; }
        public double Qty1 { get; set; }
        public double Qty2 { get; set; }
        public double Qty3 { get; set; }
        public string Unit { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double disscount { get; set; }
        public string Sp_Operation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Invoice_product_id > 0)
                Command.Parameters.Add(new SqlParameter("@INVOICE_PRODUCT_ID", SqlDbType.Int)).Value = Invoice_product_id;
            else
                Command.Parameters.Add(new SqlParameter("@INVOICE_PRODUCT_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Invoice_Id > 0)
                Command.Parameters.Add(new SqlParameter("@INVOICE_ID", SqlDbType.Int)).Value = Invoice_Id;
            else
                Command.Parameters.Add(new SqlParameter("@INVOICE_ID", SqlDbType.Int)).Value = DBNull.Value;           

            if (Date != null && Date != string.Empty)
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.VarChar)).Value = Date;
            else
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Qty1 > 0)
                Command.Parameters.Add(new SqlParameter("@QTY1", SqlDbType.Decimal)).Value = Qty1;
            else
                Command.Parameters.Add(new SqlParameter("@QTY1", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Qty2 > 0)
                Command.Parameters.Add(new SqlParameter("@QTY2", SqlDbType.Decimal)).Value = Qty2;
            else                                             
                Command.Parameters.Add(new SqlParameter("@QTY2", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Qty3 > 0)
                Command.Parameters.Add(new SqlParameter("@QTY3", SqlDbType.Decimal)).Value = Qty3;
            else
                Command.Parameters.Add(new SqlParameter("@QTY3", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Unit != String.Empty && Unit != null)
                Command.Parameters.Add(new SqlParameter("@UNIT", SqlDbType.VarChar)).Value = Unit;
            else
                Command.Parameters.Add(new SqlParameter("@UNIT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Rate > 0)
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = Rate;
            else
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = DBNull.Value;
            if (Amount > 0)
                Command.Parameters.Add(new SqlParameter("@AMOUNT", SqlDbType.Decimal)).Value = Amount;
            else
                Command.Parameters.Add(new SqlParameter("@AMOUNT", SqlDbType.Decimal)).Value = DBNull.Value;

            if (disscount > 0)
                Command.Parameters.Add(new SqlParameter("@DISCOUNT", SqlDbType.Decimal)).Value = disscount;
            else
                Command.Parameters.Add(new SqlParameter("@DISCOUNT", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Sp_Operation != string.Empty && Sp_Operation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = Sp_Operation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }
        public DataTable SaveUser()
        {
            cmd = new SqlCommand("INVOICE_PRODUCT_MANAGEMENT", con);
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