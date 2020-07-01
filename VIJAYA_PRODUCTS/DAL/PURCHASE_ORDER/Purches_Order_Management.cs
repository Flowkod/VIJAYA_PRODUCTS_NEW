using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace NewStarCity.DAL.PURCHASE_ORDER
{
    public class Purches_Order_Management
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region"Properties"

        private int PURCHASEORDER_ID;
        public int Purchaseorder_Id
        {
            get { return PURCHASEORDER_ID; }
            set { PURCHASEORDER_ID = value; }
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

        public int Customer_id { get; set; }

        private string PO_NO;
        public string Po_No
        {
            get { return PO_NO; }
            set { PO_NO = value; }
        }

        private DateTime DATE;
        public DateTime Date
        {
            get { return DATE; }
            set { DATE = value; }
        }

        private DateTime TO_DATE;
        public DateTime to_date
        {
            get { return TO_DATE; }
            set { TO_DATE = value; }
        }

        public string Gst_no { get; set; }

        public string Phone_no { get; set; }

        public string Contact_person { get; set; }

        public int Gst_id { get; set; }

        private double TOTAL;
        public double Total
        {
            get { return TOTAL; }
            set { TOTAL = value; }
        }

        private double DISCOUNT;
        public double Discount
        {
            get { return DISCOUNT; }
            set { DISCOUNT = value; }
        }

        private double NET_TOTAL;
        public double Net_Total
        {
            get { return NET_TOTAL; }
            set { NET_TOTAL = value; }
        }

        private double ADVANCE;
        public double Advance
        {
            get { return ADVANCE; }
            set { ADVANCE = value; }
        }

        public double Round_Off { get; set; }

        private double GRAND_TOTAL;
        public double Grand_Total
        {
            get { return GRAND_TOTAL; }
            set { GRAND_TOTAL = value; }
        }

        private string NOTE;
        public string Note
        {
            get { return NOTE; }
            set { NOTE = value; }
        }

        private string DeliveryPeriod;
        public string Delivery_Period
        {
            get { return DeliveryPeriod; }
            set { DeliveryPeriod = value; }
        }

        private string PaymentTerms;
        public string Payment_Terms
        {
            get { return PaymentTerms; }
            set { PaymentTerms = value; }
        }

        public string Is_print { get; set; }

        public string E_WAY_BILL { get; set; }

        public string TRANSPORT { get; set; }

        public string DATE_OF_SUPPLY { get; set; }

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
            if (Purchaseorder_Id > 0)
                Command.Parameters.Add(new SqlParameter("@PURCHASEORDER_ID", SqlDbType.Int)).Value = Purchaseorder_Id;
            else
                Command.Parameters.Add(new SqlParameter("@PURCHASEORDER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Site_Id > 0)
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = Site_Id;
            else
                Command.Parameters.Add(new SqlParameter("@SITE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (User_Id > 0)
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = User_Id;
            else
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Customer_id > 0)
                Command.Parameters.Add(new SqlParameter("@CUSTOMER_ID", SqlDbType.Int)).Value = Customer_id;
            else
                Command.Parameters.Add(new SqlParameter("@CUSTOMER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Po_No != String.Empty && Po_No != null)
                Command.Parameters.Add(new SqlParameter("@PO_NO", SqlDbType.VarChar)).Value = Po_No;
            else
                Command.Parameters.Add(new SqlParameter("@PO_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Gst_no != String.Empty && Gst_no != null)
                Command.Parameters.Add(new SqlParameter("@GST_NO", SqlDbType.VarChar)).Value = Gst_no;
            else
                Command.Parameters.Add(new SqlParameter("@GST_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Gst_id > 0)
                Command.Parameters.Add(new SqlParameter("@GST_ID", SqlDbType.Int)).Value = Gst_id;
            else
                Command.Parameters.Add(new SqlParameter("@GST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Date != null && Date != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.DateTime)).Value = Date;
            else
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (to_date != null && to_date != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = to_date;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (Phone_no != String.Empty && Phone_no != null)
                Command.Parameters.Add(new SqlParameter("@PHONE_NO", SqlDbType.VarChar)).Value = Phone_no;
            else
                Command.Parameters.Add(new SqlParameter("@PHONE_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Contact_person != String.Empty && Contact_person != null)
                Command.Parameters.Add(new SqlParameter("@CONTACT_PERSON", SqlDbType.VarChar)).Value = Contact_person;
            else
                Command.Parameters.Add(new SqlParameter("@CONTACT_PERSON", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Total > 0)
                Command.Parameters.Add(new SqlParameter("@TOTAL", SqlDbType.Decimal)).Value = Total;
            else
                Command.Parameters.Add(new SqlParameter("@TOTAL", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Discount > 0)
                Command.Parameters.Add(new SqlParameter("@DISCOUNT", SqlDbType.Decimal)).Value = Discount;
            else
                Command.Parameters.Add(new SqlParameter("@DISCOUNT", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Net_Total > 0)
                Command.Parameters.Add(new SqlParameter("@NET_TOTAL", SqlDbType.Decimal)).Value = Net_Total;
            else
                Command.Parameters.Add(new SqlParameter("@NET_TOTAL", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Round_Off > 0)
                Command.Parameters.Add(new SqlParameter("@ROUND_OFF", SqlDbType.Decimal)).Value = Round_Off;
            else
                Command.Parameters.Add(new SqlParameter("@ROUND_OFF", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Grand_Total > 0)
                Command.Parameters.Add(new SqlParameter("@GRAND_TOTAL", SqlDbType.Decimal)).Value = Grand_Total;
            else
                Command.Parameters.Add(new SqlParameter("@GRAND_TOTAL", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Note != String.Empty && Note != null)
                Command.Parameters.Add(new SqlParameter("@NOTE", SqlDbType.VarChar)).Value = Note;
            else
                Command.Parameters.Add(new SqlParameter("@NOTE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Delivery_Period != String.Empty && Delivery_Period != null)
                Command.Parameters.Add(new SqlParameter("@DELIVERYPERIOD", SqlDbType.VarChar)).Value = Delivery_Period;
            else
                Command.Parameters.Add(new SqlParameter("@DELIVERYPERIOD", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Payment_Terms != String.Empty && Payment_Terms != null)
                Command.Parameters.Add(new SqlParameter("@PAYMENTTERMS", SqlDbType.VarChar)).Value = Payment_Terms;
            else
                Command.Parameters.Add(new SqlParameter("@PAYMENTTERMS", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Is_print != String.Empty && Is_print != null)
                Command.Parameters.Add(new SqlParameter("@IS_PRINT", SqlDbType.VarChar)).Value = Is_print;
            else
                Command.Parameters.Add(new SqlParameter("@IS_PRINT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (E_WAY_BILL != String.Empty && E_WAY_BILL != null)
                Command.Parameters.Add(new SqlParameter("@E_WAY_BILL", SqlDbType.Decimal)).Value = E_WAY_BILL;
            else
                Command.Parameters.Add(new SqlParameter("@E_WAY_BILL", SqlDbType.Decimal)).Value = DBNull.Value;

            if (TRANSPORT != String.Empty && TRANSPORT != null)
                Command.Parameters.Add(new SqlParameter("@TRANSPORT", SqlDbType.VarChar)).Value = TRANSPORT;
            else
                Command.Parameters.Add(new SqlParameter("@TRANSPORT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (DATE_OF_SUPPLY != String.Empty && DATE_OF_SUPPLY != null)
                Command.Parameters.Add(new SqlParameter("@DATE_OF_SUPPLY", SqlDbType.VarChar)).Value = DATE_OF_SUPPLY;
            else
                Command.Parameters.Add(new SqlParameter("@DATE_OF_SUPPLY", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Sp_Operation != string.Empty && Sp_Operation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = Sp_Operation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveUser()
        {
            cmd = new SqlCommand("PURCHASE_ORDER_MANAGEMENT", con);
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