using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace NewStarCity.DAL.PO_DRAFT
{
    public class Po_Draft_Management
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion
        #region"Properties"
        private int DRAFT_ID;

        public int Draft_Id
        {
            get { return DRAFT_ID; }
            set { DRAFT_ID = value; }
        }
        private DateTime DATE;

        public DateTime Date
        {
            get { return DATE; }
            set { DATE = value; }
        }
        private string TO_NAME;

        public string To_Name
        {
            get { return TO_NAME; }
            set { TO_NAME = value; }
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

            if (Draft_Id > 0)
                Command.Parameters.Add(new SqlParameter("@DRAFT_ID", SqlDbType.Int)).Value = Draft_Id ;
            else
                Command.Parameters.Add(new SqlParameter("@DRAFT_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (To_Name != String.Empty && To_Name != null)
                Command.Parameters.Add(new SqlParameter("@TO_NAME", SqlDbType.VarChar)).Value = To_Name ;
            else
                Command.Parameters.Add(new SqlParameter("@TO_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Date != null && Date != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.DateTime)).Value = Date;
            else
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (Site_Id > 0)
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = Site_Id;
            else
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (User_Id > 0)
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = User_Id;
            else
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Sp_Operation != string.Empty && Sp_Operation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = Sp_Operation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;

        }
        public DataTable SaveUser()
        {
            cmd = new SqlCommand("PO_DRAFT_MANAGEMENT", con);
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