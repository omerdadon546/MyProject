using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] is string)
            {
                if ((string)Session["role"] == "שחקן")
                {
                    Button3.Visible = false;
                }
                if ((string)Session["role"] == "אורח")
                {
                    Button3.Visible = false;
                    Button2.Visible = false;
                    Button1.Visible = false;
                    Button4.Visible = false;
                    Button5.Visible = false;
                    Button6.Visible = false;
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePag.aspx"); 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("players.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("trainers.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("training.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("leagues.aspx");
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("games.aspx");
        }
    }
}