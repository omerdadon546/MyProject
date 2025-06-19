using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Svc = WebApplication1.ServiceReference1.Service1Client;
using API = WebApplication1.localhost.WebService1;
using Login = WebApplication1.ServiceReference1.LoginClass;
using System.Data;
using System.Security.Cryptography;

namespace WebApplication1
{
    public partial class signUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Login newUser = new Login();
            newUser.Username = TextBox1.Text;
            API svc = new API();

            bool isStrong = svc.IsStrongPassword(TextBox2.Text);

            if (!isStrong)
            {
                Response.Write("<script>alert('The password isn't strong');</script>");
            }
            else
            {

                newUser.Username = TextBox1.Text;
                newUser.Password = TextBox2.Text;
                newUser.Role = "אורח";
                newUser.Birthday = Calendar1.SelectedDate;
                int res = mySvc.signUp(newUser);
                if (res == 0)
                {
                    Response.Write("<script>alert('the user was Added successfully');</script>");
                    Response.Redirect("login.aspx");
                }
                else if (res == 1)
                {
                    Response.Write("<script>alert('some of the details provided were wrong');</script>");

                }
                else
                {
                    Response.Write("<script>alert('miscelaneous error');</script>");

                }
            }
        }
    }
}