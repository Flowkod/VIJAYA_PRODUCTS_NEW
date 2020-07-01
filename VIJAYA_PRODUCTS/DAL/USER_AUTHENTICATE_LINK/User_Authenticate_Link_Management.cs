using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace NewStarCity.DAL.USER_AUTHENTICATE_LINK
{
    public class User_Authenticate_Link_Management
    {
        #region"Veriable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region"Properties"
        private int USER_ID;

        public int User_Id
        {
            get { return USER_ID; }
            set { USER_ID = value; }
        }
        private string COLUMN_1;

        public string Column_1
        {
            get { return COLUMN_1; }
            set { COLUMN_1 = value; }
        }
        private string COLUMN_2;

        public string Column_2
        {
            get { return COLUMN_2; }
            set { COLUMN_2 = value; }
        }
        private string COLUMN_3;

        public string Column_3
        {
            get { return COLUMN_3; }
            set { COLUMN_3 = value; }
        }
        private string COLUMN_4;

        public string Column_4
        {
            get { return COLUMN_4; }
            set { COLUMN_4 = value; }
        }
        private string COLUMN_5;

        public string Column_5
        {
            get { return COLUMN_5; }
            set { COLUMN_5 = value; }
        }
        private string COLUMN_6;

        public string Column_6
        {
            get { return COLUMN_6; }
            set { COLUMN_6 = value; }
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
            if (User_Id > 0)
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = User_Id;
            else
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Column_1 != String.Empty && Column_1 != null)
                Command.Parameters.Add(new SqlParameter("@COLUMN_1", SqlDbType.VarChar)).Value = Column_1;
            else
                Command.Parameters.Add(new SqlParameter("@COLUMN_1", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Column_2 != String.Empty && Column_2 != null)
                Command.Parameters.Add(new SqlParameter("@COLUMN_2", SqlDbType.VarChar)).Value = Column_2;
            else
                Command.Parameters.Add(new SqlParameter("@COLUMN_2", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Column_3 != String.Empty && Column_3 != null)
                Command.Parameters.Add(new SqlParameter("@COLUMN_3", SqlDbType.VarChar)).Value = Column_3;
            else
                Command.Parameters.Add(new SqlParameter("@COLUMN_3", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Column_4 != String.Empty && Column_4 != null)
                Command.Parameters.Add(new SqlParameter("@COLUMN_4", SqlDbType.VarChar)).Value = Column_4;
            else
                Command.Parameters.Add(new SqlParameter("@COLUMN_4", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Column_5 != String.Empty && Column_5 != null)
                Command.Parameters.Add(new SqlParameter("@COLUMN_5", SqlDbType.VarChar)).Value = Column_5;
            else
                Command.Parameters.Add(new SqlParameter("@COLUMN_5", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Column_6 != String.Empty && Column_6 != null)
                Command.Parameters.Add(new SqlParameter("@COLUMN_6", SqlDbType.VarChar)).Value = Column_6;
            else
                Command.Parameters.Add(new SqlParameter("@COLUMN_6", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Sp_Operation != string.Empty && Sp_Operation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = Sp_Operation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;
        }
        public DataTable SaveUser()
        {
            cmd = new SqlCommand("AUTHENTICATE_MANAGEMENT", con);
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