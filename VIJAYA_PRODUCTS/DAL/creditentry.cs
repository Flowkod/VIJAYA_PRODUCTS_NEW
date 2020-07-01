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
    public class creditentry
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property
        public int id { get; set; }
        public string PartyName { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string To_Date { get; set; }
        public Double Amount { get; set; }
        public string Description { get; set; }
        public string SP_OPERATION { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {


            if (id > 0)
                Command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
            else
                Command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = DBNull.Value;

            if (PartyName != String.Empty && PartyName != null)
                Command.Parameters.Add(new SqlParameter("@PartyName", SqlDbType.VarChar)).Value = PartyName;
            else
                Command.Parameters.Add(new SqlParameter("@PartyName", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Type != String.Empty && Type != null)
                Command.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar)).Value = Type;
            else
                Command.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Date != String.Empty && Date != null)
                Command.Parameters.Add(new SqlParameter("@Date", SqlDbType.VarChar)).Value = Date;
            else
                Command.Parameters.Add(new SqlParameter("@Date", SqlDbType.VarChar)).Value = DBNull.Value;


            if (To_Date != String.Empty && To_Date != null)
                Command.Parameters.Add(new SqlParameter("@To_Date", SqlDbType.VarChar)).Value = To_Date;
            else
                Command.Parameters.Add(new SqlParameter("@To_Date", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Amount > 0)
                Command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal)).Value = Amount;
            else
                Command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal)).Value = DBNull.Value;


            if (Description != String.Empty && Description != null)
                Command.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar)).Value = Description;
            else
                Command.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar)).Value = DBNull.Value;


            if (SP_OPERATION != string.Empty && SP_OPERATION != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SP_OPERATION;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveEntry()
        {
            cmd = new SqlCommand("CREDIT_MANAGEMENT", con);
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