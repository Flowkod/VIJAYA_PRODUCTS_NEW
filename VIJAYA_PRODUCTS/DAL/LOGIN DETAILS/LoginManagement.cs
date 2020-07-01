using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace StarCity.DAL.LOGIN_DETAILS
{
    public class LoginManagement
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region"Properties"
        private string USER_NAME;
        private string EMAIL_ID;

        public string Email_Id
        {
            get { return EMAIL_ID; }
            set { EMAIL_ID = value; }
        }
        private string MOBILE_NO;

        public string Mobile_No
        {
            get { return MOBILE_NO; }
            set { MOBILE_NO = value; }
        }
        private string PASSWORD;
        private int SITE_ID;
        private int ROLL_ID;
        private string SpOperation;

        public string User_Name
        {
            get
            {
                return USER_NAME;
            }

            set
            {
                USER_NAME = value;
            }
        }

        public string Password
        {
            get
            {
                return PASSWORD;
            }

            set
            {
                PASSWORD = value;
            }
        }
        public string Sp_Operation
        {
            get
            {
                return SpOperation;
            }

            set
            {
                SpOperation = value;
            }
        }

        public int Site_Id
        {
            get
            {
                return SITE_ID;
            }

            set
            {
                SITE_ID = value;
            }
        }

        public int Roll_Id
        {
            get
            {
                return ROLL_ID;
            }

            set
            {
                ROLL_ID = value;
            }
        }
        private int USER_ID;

        public int User_Id
        {
            get { return USER_ID; }
            set { USER_ID = value; }
        }
        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {

            if (User_Id > 0)
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = User_Id;
            else
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (User_Name != String.Empty && User_Name != null)
                Command.Parameters.Add(new SqlParameter("@USER_NAME", SqlDbType.VarChar)).Value = User_Name;
            else
                Command.Parameters.Add(new SqlParameter("@USER_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Email_Id != String.Empty && Email_Id != null)
                Command.Parameters.Add(new SqlParameter("@EMAIL_ID", SqlDbType.VarChar)).Value = Email_Id;
            else
                Command.Parameters.Add(new SqlParameter("@EMAIL_ID", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Mobile_No != String.Empty && Mobile_No != null)
                Command.Parameters.Add(new SqlParameter("@MOBILE_NO", SqlDbType.VarChar)).Value = Mobile_No;
            else
                Command.Parameters.Add(new SqlParameter("@MOBILE_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Password != String.Empty && Password != null)
                Command.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.VarChar)).Value = Password;
            else
                Command.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Site_Id > 0)
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = Site_Id;
            else
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Roll_Id > 0)
                Command.Parameters.Add(new SqlParameter("@ROLL_ID", SqlDbType.Int)).Value = Roll_Id;
            else
                Command.Parameters.Add(new SqlParameter("@ROLL_ID", SqlDbType.Int)).Value = DBNull.Value;


            if (Sp_Operation != string.Empty && Sp_Operation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = Sp_Operation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;
        }
        public DataTable SaveUser()
        {
            cmd = new SqlCommand("LOGIN_MANAGEMENT", con);
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