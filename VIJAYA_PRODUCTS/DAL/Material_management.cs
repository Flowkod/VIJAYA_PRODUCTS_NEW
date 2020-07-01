using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace SUPPLY_MANAGEMENT.DAL
{
    public class Material_management
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int Material_id { get; set; }
        public int Created_by { get; set; }
        public string Material_name { get; set; }
        public double RATE { get; set; }
        public double Gst { get; set; }
        public string Unit { get; set; }
        public string Hsn_Code { get; set; }
        public double Qty_in_Stock { get; set; }
        public string SpOperation { get; set; }
        public double LOW_QTY { get; set; }

        #endregion
        
        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Material_id > 0)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = Material_id;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Created_by > 0)
                Command.Parameters.Add(new SqlParameter("@CREATED_BY", SqlDbType.Int)).Value = Created_by;
            else
                Command.Parameters.Add(new SqlParameter("@CREATED_BY", SqlDbType.Int)).Value = DBNull.Value;

            if (Material_name != String.Empty && Material_name != null)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_NAME", SqlDbType.VarChar)).Value = Material_name;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (RATE > 0)
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = RATE;
            else
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Gst > 0)
                Command.Parameters.Add(new SqlParameter("@GST", SqlDbType.Decimal)).Value = Gst;
            else
                Command.Parameters.Add(new SqlParameter("@GST", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Unit != string.Empty && Unit != null)
                Command.Parameters.Add(new SqlParameter("@UNIT", SqlDbType.VarChar)).Value = Unit;
            else
                Command.Parameters.Add(new SqlParameter("@UNIT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Hsn_Code != string.Empty && Hsn_Code != null)
                Command.Parameters.Add(new SqlParameter("@HSN_CODE", SqlDbType.VarChar)).Value = Hsn_Code;
            else
                Command.Parameters.Add(new SqlParameter("@HSN_CODE", SqlDbType.VarChar)).Value = DBNull.Value;

                Command.Parameters.Add(new SqlParameter("@QTY_IN_STOCK", SqlDbType.Decimal)).Value = Qty_in_Stock;

                Command.Parameters.Add(new SqlParameter("@LOW_QTY", SqlDbType.Decimal)).Value = LOW_QTY;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveMaterial()
        {
            cmd = new SqlCommand("MATERIAL_MANAGEMENT", con);
            AddwithParameter(cmd);
            DataTable DataTableMaterial= new DataTable();

            cmd.CommandType = CommandType.StoredProcedure;

            sda = new SqlDataAdapter(cmd);
            sda.Fill(DataTableMaterial);

            return DataTableMaterial;

        }
        #endregion
    }
}