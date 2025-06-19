using System;
using System.Data;
using System.Data.OleDb;
using System.Web.Services;
using omerWCF.App_Code;

namespace WebServiceCS
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebService2 : WebService
    {
        [WebMethod]
        public string[] GetTodaysBirthdays()
        {
            try
            {
                int day = DateTime.Today.Day;
                int month = DateTime.Today.Month;

                string sql = "SELECT username FROM login WHERE DAY(birthday) = ? AND MONTH(birthday) = ?";

                Connection conn = new Connection();
                conn.OpenConnection();
                OleDbCommand cmd = conn.Command(sql);
                cmd.Parameters.AddWithValue("?", day);
                cmd.Parameters.AddWithValue("?", month);

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.CloseConnection();

                string[] users = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    users[i] = dt.Rows[i]["username"].ToString();
                }

                return users;
            }
            catch
            {
                return new string[] { "שגיאה בשליפת נתונים" };
            }
        }

    }
}

