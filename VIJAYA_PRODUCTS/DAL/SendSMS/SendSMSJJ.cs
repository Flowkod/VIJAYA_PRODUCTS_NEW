using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;


namespace NewStarCity.DAL.SendSMS
{
    public class SendSMSJJ
    {
        public Boolean SMSsent(string mobno, string msg)
        {
            string url;
            WebClient client;
            try
            {
                client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                url = "http://login.honorarydigitech.com/api/sendhttp.php?authkey=2076AnPpGpFyk576a718e&mobiles=" + mobno + "&message=" + msg + "&sender=JJGROP&route=8";
                string baseurl = url;
                Stream data = client.OpenRead(baseurl);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}