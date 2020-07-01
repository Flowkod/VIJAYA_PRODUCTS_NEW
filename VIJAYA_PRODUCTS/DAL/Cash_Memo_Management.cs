using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SparkInventory.DAL
{
    public class Cash_Memo_Management
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int Cash_Memo_id { get; set; }
        public string Srno { get; set; }
        public string PartyName { get; set; }
        public string Address { get; set; }
        public DateTime date { get; set; }
        public DateTime ToDate { get; set; }
        public double Grand_Total { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Cash_Memo_id > 0)
                Command.Parameters.Add(new SqlParameter("@CASH_MEMO_ID", SqlDbType.Int)).Value = Cash_Memo_id;
            else
                Command.Parameters.Add(new SqlParameter("@CASH_MEMO_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Srno != String.Empty && Srno != null)
                Command.Parameters.Add(new SqlParameter("@SRNO", SqlDbType.VarChar)).Value = Srno;
            else
                Command.Parameters.Add(new SqlParameter("@SRNO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (PartyName != String.Empty && PartyName != null)
                Command.Parameters.Add(new SqlParameter("@PARTY_NAME", SqlDbType.VarChar)).Value = PartyName;
            else
                Command.Parameters.Add(new SqlParameter("@PARTY_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Address != String.Empty && Address != null)
                Command.Parameters.Add(new SqlParameter("@ADDRESS", SqlDbType.VarChar)).Value = Address;
            else
                Command.Parameters.Add(new SqlParameter("@ADDRESS", SqlDbType.VarChar)).Value = DBNull.Value;

            if (date != DateTime.MinValue && date != null)
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.DateTime)).Value = date;
            else
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (ToDate != DateTime.MinValue && ToDate != null)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = ToDate;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (Grand_Total > 0)
                Command.Parameters.Add(new SqlParameter("@GRAND_TOTAL", SqlDbType.Decimal)).Value = Grand_Total;
            else
                Command.Parameters.Add(new SqlParameter("@GRAND_TOTAL", SqlDbType.Decimal)).Value = DBNull.Value;


            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveCashMemo()
        {
            cmd = new SqlCommand("CASH_MEMO_MANAGEMENT", con);
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