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
    public class Ledger
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property
        public DateTime from_date { get; set; }
        public DateTime To_date { get; set; }
        public string PartyName { get; set; }
        public int Cash_Memo_id { get; set; }
        public string SP_OPERATION { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {


            if (from_date != DateTime.MinValue && from_date != null)
                Command.Parameters.Add(new SqlParameter("@FROM_DATE", SqlDbType.DateTime)).Value = from_date;
            else
                Command.Parameters.Add(new SqlParameter("@FROM_DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (To_date != DateTime.MinValue && To_date != null)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = To_date;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (PartyName != String.Empty && PartyName != null)
                Command.Parameters.Add(new SqlParameter("@PARTY_NAME", SqlDbType.VarChar)).Value = PartyName;
            else
                Command.Parameters.Add(new SqlParameter("@PARTY_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Cash_Memo_id > 0)
                Command.Parameters.Add(new SqlParameter("@CASH_MEMO_ID", SqlDbType.Int)).Value = Cash_Memo_id;
            else
                Command.Parameters.Add(new SqlParameter("@CASH_MEMO_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (SP_OPERATION != String.Empty && SP_OPERATION != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SP_OPERATION;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable GetLedger()
        {
            cmd = new SqlCommand("LEDGER", con);
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