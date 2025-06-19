using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using API = WebApplication1.localhost2.WebService2;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class HomePag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RestClient client = new RestClient("http://api.forismatic.com");

                RestRequest request = new RestRequest("/api/1.0/", Method.Get);
                request.AddParameter("method", "getQuote");
                request.AddParameter("format", "text");
                request.AddParameter("key", "123456"); 
                request.AddParameter("lang", "en");

                RestResponse response = client.Execute<RestResponse>(request);

                // בדיקה אם הייתה שגיאה או שה-API לא ענה
                if (response.ResponseStatus != ResponseStatus.Completed || response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Label3.Text = "שיהיה לך יום נעים";
                }
                else
                {
                    Label3.Text = response.Content.ToString();
                }


                API svc = new API();
                string[] users = svc.GetTodaysBirthdays();
                if (users[0] == "שגיאה בשליפת נתונים")
                {
                    Label4.Text = "אין ימי הולדת היום 🎂";
                }
                else
                {
                    Label4.Text = "מזל טוב ל: " + string.Join(", ", users);
                }

            }
            catch { }
            
        }
    }
}