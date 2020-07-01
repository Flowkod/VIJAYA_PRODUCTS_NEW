using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion
namespace KumarGas.DAL.CLIENT_RAGISTER
{
    public class Client_Ragister_Management
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region"Properties"

        private int CUSTOMER_ID;

        public int Customer_Id
        {
            get { return CUSTOMER_ID; }
            set { CUSTOMER_ID = value; }
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

        private string CUSTOMER_NAME;

        public string Customer_Name
        {
            get { return CUSTOMER_NAME; }
            set { CUSTOMER_NAME = value; }
        }

        public string Contact_Person { get; set; }

        private string DELIVERY_ADDRESS;

        public string DELIVERY_ADDRESS1
        {
            get { return DELIVERY_ADDRESS; }
            set { DELIVERY_ADDRESS = value; }
        }
        
        private string ADDRESS;

        public string Address
        {
            get { return ADDRESS; }
            set { ADDRESS = value; }
        }

        private string MOBILE_NO;

        public string Mobile_No
        {
            get { return MOBILE_NO; }
            set { MOBILE_NO = value; }
        }
        private string EMAIL_ID;

        public string Email_Id
        {
            get { return EMAIL_ID; }
            set { EMAIL_ID = value; }
        }       

        private string GST_NO;

        public string Gst_No
        {
            get { return GST_NO; }
            set { GST_NO = value; }
        }

        public string FSSAI_NO { get; set; }

        public string Pan_no { get; set; }

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

            if (Customer_Id > 0)
                Command.Parameters.Add(new SqlParameter("@CUSTOMER_ID", SqlDbType.Int)).Value = Customer_Id;
            else
                Command.Parameters.Add(new SqlParameter("@CUSTOMER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Site_Id > 0)
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = Site_Id;
            else
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (User_Id > 0)
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = User_Id;
            else
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Customer_Name != String.Empty && Customer_Name != null)
                Command.Parameters.Add(new SqlParameter("@CUSTOMER_NAME", SqlDbType.VarChar)).Value = Customer_Name;
            else
                Command.Parameters.Add(new SqlParameter("@CUSTOMER_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Contact_Person != String.Empty && Contact_Person != null)
                Command.Parameters.Add(new SqlParameter("@CONTACT_PERSON", SqlDbType.VarChar)).Value = Contact_Person;
            else
                Command.Parameters.Add(new SqlParameter("@CONTACT_PERSON", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Address != String.Empty && Address != null)
                Command.Parameters.Add(new SqlParameter("@ADDRESS", SqlDbType.VarChar)).Value = Address;
            else
                Command.Parameters.Add(new SqlParameter("@ADDRESS", SqlDbType.VarChar)).Value = DBNull.Value;

            if (DELIVERY_ADDRESS1 != String.Empty && DELIVERY_ADDRESS1 != null)
                Command.Parameters.Add(new SqlParameter("@DELIVERY_ADDRESS", SqlDbType.VarChar)).Value = DELIVERY_ADDRESS1;
            else
                Command.Parameters.Add(new SqlParameter("@DELIVERY_ADDRESS", SqlDbType.VarChar)).Value = DBNull.Value;


            if (Mobile_No != String.Empty && Mobile_No != null)
                Command.Parameters.Add(new SqlParameter("@MOBILE_NO", SqlDbType.VarChar)).Value = Mobile_No;
            else
                Command.Parameters.Add(new SqlParameter("@MOBILE_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Email_Id != String.Empty && Email_Id != null)
                Command.Parameters.Add(new SqlParameter("@EMAIL_ID", SqlDbType.VarChar)).Value = Email_Id;
            else
                Command.Parameters.Add(new SqlParameter("@EMAIL_ID", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Gst_No != String.Empty && Gst_No != null)
                Command.Parameters.Add(new SqlParameter("@GST_NO", SqlDbType.VarChar)).Value = Gst_No;
            else
                Command.Parameters.Add(new SqlParameter("@GST_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (FSSAI_NO != String.Empty && FSSAI_NO != null)
                Command.Parameters.Add(new SqlParameter("@FSSAI_NO", SqlDbType.VarChar)).Value = FSSAI_NO;
            else
                Command.Parameters.Add(new SqlParameter("@FSSAI_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Pan_no != String.Empty && Pan_no != null)
                Command.Parameters.Add(new SqlParameter("@PAN_NO", SqlDbType.VarChar)).Value = Pan_no;
            else
                Command.Parameters.Add(new SqlParameter("@PAN_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Sp_Operation != string.Empty && Sp_Operation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = Sp_Operation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveCustomer()
        {
            cmd = new SqlCommand("CUSTOMER_DETAILS", con);
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