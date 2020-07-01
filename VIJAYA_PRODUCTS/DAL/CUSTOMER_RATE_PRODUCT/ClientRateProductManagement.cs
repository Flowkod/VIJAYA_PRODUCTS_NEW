using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion
namespace KumarGas.DAL.CLIENT_RATE_PRODUCT
{
    public class ClientRateProductManagement
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region"Properties"

        private int ID;

        public int Id
        {
            get { return ID; }
            set { ID = value; }
        }


        private int CUSTOMER_ID;

        public int Customer_Id
        {
            get { return CUSTOMER_ID; }
            set { CUSTOMER_ID = value; }
        }

        private int MATERIAL_ID;

        public int Material_Id
        {
            get { return MATERIAL_ID; }
            set { MATERIAL_ID = value; }
        }

        private int SITE_ID;

        public int Site_Id
        {
            get { return SITE_ID; }
            set { SITE_ID = value; }
        }
        private int USER_ID;

        public int User_Id
        {
            get { return USER_ID; }
            set { USER_ID = value; }
        }

        private double RATE;

        public double Rate
        {
            get { return RATE; }
            set { RATE = value; }
        }

        private double GST_ID;

        public double Gst_id
        {
            get { return GST_ID; }
            set { GST_ID = value; }
        }

        private string SESSION_DATA;

        public string Session_Data
        {
            get { return SESSION_DATA; }
            set { SESSION_DATA = value; }
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
            if (Id > 0)
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = Id;
            else
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Customer_Id > 0)
                Command.Parameters.Add(new SqlParameter("@CUSTOMER_ID", SqlDbType.Int)).Value = Customer_Id;
            else
                Command.Parameters.Add(new SqlParameter("@CUSTOMER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Material_Id > 0)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = Material_Id;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Site_Id > 0)
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = Site_Id;
            else
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (User_Id > 0)
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = User_Id;
            else
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Rate > 0)
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = Rate;
            else
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Gst_id > 0)
                Command.Parameters.Add(new SqlParameter("@GST_ID", SqlDbType.Decimal)).Value = Gst_id;
            else
                Command.Parameters.Add(new SqlParameter("@GST_ID", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Session_Data != String.Empty && Session_Data != null)
                Command.Parameters.Add(new SqlParameter("@SESSION_DATA", SqlDbType.VarChar)).Value = Session_Data;
            else
                Command.Parameters.Add(new SqlParameter("@SESSION_DATA", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Sp_Operation != string.Empty && Sp_Operation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = Sp_Operation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;
        }
        public DataTable SaveUser()
        {
            cmd = new SqlCommand("CUSTOMER_RATE_PRODUCT_DETAILS", con);
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