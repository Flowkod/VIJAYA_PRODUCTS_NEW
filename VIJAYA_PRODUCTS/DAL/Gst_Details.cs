using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion
namespace RCandJJ.DAL
{
    public class Gst_Details
    {
        #region"Veriable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int Gst_id { get; set; }
        public double Gst { get; set; }
        public string SpOperation { get; set; }
        
        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Gst_id > 0)
                Command.Parameters.Add(new SqlParameter("@GST_ID", SqlDbType.Int)).Value = Gst_id;
            else
                Command.Parameters.Add(new SqlParameter("@GST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Gst > 0)
                Command.Parameters.Add(new SqlParameter("@GST", SqlDbType.Decimal)).Value = Gst;
            else
                Command.Parameters.Add(new SqlParameter("@GST", SqlDbType.Decimal)).Value = DBNull.Value;


            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveGST()
        {
            cmd = new SqlCommand("GST_MANAGEMENT", con);
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