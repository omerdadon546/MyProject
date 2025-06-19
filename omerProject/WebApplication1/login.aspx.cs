using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Svc = WebApplication1.ServiceReference1.Service1Client;
using Login = WebApplication1.ServiceReference1.LoginClass;
using System.Data;
using System.Security.Cryptography;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Login user = new Login();
            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;
            string chek = "";
            chek = mySvc.login(user);
            if (chek == "the passwords did not match")
            {
                Response.Write("<script>alert('the passwords did not match');</script>");
                return;
            }
            else if (chek == "0")
            {
                Response.Write("<script>alert('The password or username isn't right');</script>");
                return;
            }
            else if (chek == "-2")
            {
                Response.Write("<script>alert('miscelaneous error');</script>");
                return;
            }
            else
            {
                Session["role"] = chek ;
                Response.Redirect("HomePag.aspx");
            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("signUp.aspx");
        }
    }
}