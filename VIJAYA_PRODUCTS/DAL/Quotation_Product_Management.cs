using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace SparkInventory.DAL
{
    public class Quotation_Product_Management
    {

        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region"Properties"

        public int Quotation_product_id { get; set; }

        private int QUOTATION_ID;
        public int Quotation_Id
        {
            get { return QUOTATION_ID; }
            set { QUOTATION_ID = value; }
        }

        private int SITE_ID;
        public int Site_Id
        {
            get { return SITE_ID; }
            set { SITE_ID = value; }
        }

        public string Quotation_no { get; set; }

        public int Product_id { get; set; }

        public int Customer_id { get; set; }

        private double QTY;
        public double Qty
        {
            get { return QTY; }
            set { QTY = value; }
        }

        private string UNIT;
        public string Unit
        {
            get { return UNIT; }
            set { UNIT = value; }
        }

        private double RATE;
        public double Rate
        {
            get { return RATE; }
            set { RATE = value; }
        }

        public string Due_on { get; set; }

        public int Gst_id { get; set; }

        private double AMOUNT;
        public double Amount
        {
            get { return AMOUNT; }
            set { AMOUNT = value; }
        }

        private double Disscount;
        public double disscount
        {
            get { return Disscount; }
            set { Disscount = value; }
        }

        private string SpOperation;
        public string Sp_Operation
        {
            get { return SpOperation; }
            set { SpOperation = value; }
        }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Quotation_product_id > 0)
                Command.Parameters.Add(new SqlParameter("@QUOTATION_PRODUCT_ID", SqlDbType.Int)).Value = Quotation_product_id;
            else
                Command.Parameters.Add(new SqlParameter("@QUOTATION_PRODUCT_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Site_Id > 0)
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = Site_Id;
            else
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Quotation_Id > 0)
                Command.Parameters.Add(new SqlParameter("@QUOTATION_ID", SqlDbType.Int)).Value = Quotation_Id;
            else
                Command.Parameters.Add(new SqlParameter("@QUOTATION_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Quotation_no != String.Empty && Quotation_no != null)
                Command.Parameters.Add(new SqlParameter("@QUOTATION_NO", SqlDbType.VarChar)).Value = Quotation_no;
            else
                Command.Parameters.Add(new SqlParameter("@QUOTATION_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Customer_id > 0)
                Command.Parameters.Add(new SqlParameter("@CUSTMOER_ID", SqlDbType.Int)).Value = Customer_id;
            else
                Command.Parameters.Add(new SqlParameter("@CUSTMOER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Product_id > 0)
                Command.Parameters.Add(new SqlParameter("@PRODUCT_ID", SqlDbType.Int)).Value = Product_id;
            else
                Command.Parameters.Add(new SqlParameter("@PRODUCT_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Qty > 0)
                Command.Parameters.Add(new SqlParameter("@QTY", SqlDbType.Decimal)).Value = Qty;
            else
                Command.Parameters.Add(new SqlParameter("@QTY", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Unit != String.Empty && Unit != null)
                Command.Parameters.Add(new SqlParameter("@UNIT", SqlDbType.VarChar)).Value = Unit;
            else
                Command.Parameters.Add(new SqlParameter("@UNIT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Due_on != String.Empty && Due_on != null)
                Command.Parameters.Add(new SqlParameter("@DUE_ON", SqlDbType.VarChar)).Value = Due_on;
            else
                Command.Parameters.Add(new SqlParameter("@DUE_ON", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Rate > 0)
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = Rate;
            else
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Gst_id > 0)
                Command.Parameters.Add(new SqlParameter("@GST_ID", SqlDbType.Int)).Value = Gst_id;
            else
                Command.Parameters.Add(new SqlParameter("@GST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Amount > 0)
                Command.Parameters.Add(new SqlParameter("@AMOUNT", SqlDbType.Decimal)).Value = Amount;
            else
                Command.Parameters.Add(new SqlParameter("@AMOUNT", SqlDbType.Decimal)).Value = DBNull.Value;

            if (disscount > 0)
                Command.Parameters.Add(new SqlParameter("@DISCOUNT", SqlDbType.Decimal)).Value = disscount;
            else
                Command.Parameters.Add(new SqlParameter("@DISCOUNT", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Sp_Operation != string.Empty && Sp_Operation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = Sp_Operation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveUser()
        {
            cmd = new SqlCommand("QUOTATION_PRODUCT_MANAGEMENT", con);
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