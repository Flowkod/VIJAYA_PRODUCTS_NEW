using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace SRIRAM_MILK.DAL
{
    public class FundManagement
    {

        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public string Fund_id { get; set; }

        public DateTime CREATED_ON { get; set; }
        public DateTime To_Date { get; set; }
        public string Description { get; set; }
        public double FUND_AMOUNT { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Fund_id != String.Empty && Fund_id != null)
                Command.Parameters.Add(new SqlParameter("@FUND_ID", SqlDbType.VarChar)).Value = Fund_id;
            else
                Command.Parameters.Add(new SqlParameter("@FUND_ID", SqlDbType.VarChar)).Value = DBNull.Value;

            if (CREATED_ON != DateTime.MinValue && CREATED_ON != null)
                Command.Parameters.Add(new SqlParameter("@CREATED_ON", SqlDbType.Date)).Value = CREATED_ON;
            else
                Command.Parameters.Add(new SqlParameter("@CREATED_ON", SqlDbType.Date)).Value = DBNull.Value;

            if (To_Date != DateTime.MinValue && To_Date != null)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.Date)).Value = To_Date;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.Date)).Value = DBNull.Value;

            if (Description != String.Empty && Description != null)
                Command.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.VarChar)).Value = Description;
            else
                Command.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.VarChar)).Value = DBNull.Value;

            if (FUND_AMOUNT > 0)
                Command.Parameters.Add(new SqlParameter("@FUND_AMOUNT", SqlDbType.Decimal)).Value = FUND_AMOUNT;
            else
                Command.Parameters.Add(new SqlParameter("@FUND_AMOUNT", SqlDbType.Decimal)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveExpenses()
        {
            cmd = new SqlCommand("FUND_MANAGEMENT", con);
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