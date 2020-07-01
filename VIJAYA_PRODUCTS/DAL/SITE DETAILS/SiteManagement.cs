using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace StarCity.DAL.SITE_DETAILS
{
    public class SiteManagement
    {
        #region"Veriable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region"Properties"

        public int Site_id { get; set; }

        public string site_Name { get; set; }

        public string Address { get; set; }

        public string Contact_Person { get; set; }

        public string GST_NO { get; set; }

        public string MOBILE_NO { get; set; }

        public string Hsn_Code { get; set; }

        public string SpOperation { get; set; }


        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Site_id > 0)
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = Site_id;
            else
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (site_Name != String.Empty && site_Name != null)
                Command.Parameters.Add(new SqlParameter("@SITE_NAME", SqlDbType.VarChar)).Value = site_Name;
            else
                Command.Parameters.Add(new SqlParameter("@SITE_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Address != String.Empty && Address != null)
                Command.Parameters.Add(new SqlParameter("@ADDRESS", SqlDbType.VarChar)).Value = Address;
            else
                Command.Parameters.Add(new SqlParameter("@ADDRESS", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Contact_Person != String.Empty && Contact_Person != null)
                Command.Parameters.Add(new SqlParameter("@CONTACT_PERSON", SqlDbType.VarChar)).Value = Contact_Person;
            else
                Command.Parameters.Add(new SqlParameter("@CONTACT_PERSON", SqlDbType.VarChar)).Value = DBNull.Value;

            if (GST_NO != String.Empty && GST_NO != null)
                Command.Parameters.Add(new SqlParameter("@GST_NO", SqlDbType.VarChar)).Value = GST_NO;
            else
                Command.Parameters.Add(new SqlParameter("@GST_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (MOBILE_NO != String.Empty && MOBILE_NO != null)
                Command.Parameters.Add(new SqlParameter("@MOBILE_NO", SqlDbType.VarChar)).Value = MOBILE_NO;
            else
                Command.Parameters.Add(new SqlParameter("@MOBILE_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Hsn_Code != String.Empty && Hsn_Code != null)
                Command.Parameters.Add(new SqlParameter("@HSN_CODE", SqlDbType.VarChar)).Value = Hsn_Code;
            else
                Command.Parameters.Add(new SqlParameter("@HSN_CODE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveSite()
        {
            cmd = new SqlCommand("SITE_MANAGEMENT", con);
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