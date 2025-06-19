using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Svc = WebApplication1.ServiceReference1.Service1Client;
using League = WebApplication1.ServiceReference1.LeaguesClass;
using Players = WebApplication1.ServiceReference1.PlayrsClass;
using System.Data;
using System.Security.Cryptography;
using System.Web.UI.DataVisualization.Charting;

namespace WebApplication1
{
    public partial class leagues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] is string)
            {
                if ((string)Session["role"] == "שחקן")
                {
                    Button7.Visible = false;
                    Button8.Visible = false;
                    Button9.Visible = false;
                    Button10.Visible = false;
                    Button12.Visible = false;

                }
            }
            Svc mySvc = new Svc();
            League[] rows = mySvc.PrintLeaguesList();
            GridView1.DataSource = rows;
            GridView1.DataBind();


            Svc svc = new Svc();
            Players[] data = svc.PrintPlayersList();
            List<string> stringData = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                stringData.Add(data[i].Key);
            }
            stringData = stringData.Distinct().ToList();
            DropDownList2.DataSource = stringData;
            DropDownList2.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            League newLeague = new League();
            newLeague.LeagueName = TextBox3.Text;
            newLeague.BastPlayerAtTheLeague1 = DropDownList2.Text;
            newLeague.PTSatLeague1 = int.Parse(TextBox1.Text);
            newLeague.LeagueLevel1 = DropDownList4.SelectedIndex+1;
            int res = mySvc.AddLeague(newLeague);
            if (res == 0)
            {
                Response.Write("<script>alert('the league was Added successfully');</script>");
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

        protected void Button8_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            League newLeague = new League();
            newLeague.LeagueName = TextBox3.Text;
            int res = mySvc.DeleteLeague(newLeague);
            if (res == 0)
            {
                Response.Write("<script>alert('the league was deleted successfully');</script>");
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

        protected void Button9_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            League league = new League();
            league.LeagueName = TextBox3.Text;
            league = mySvc.SelectLeague(league);
            if (league.LeagueName == "-1")
            {
                Response.Write("<script>alert('the league was selected successfully');</script>");
                return;
            }
            else if (league.LeagueName == "-2")
            {
                Response.Write("<script>alert('miscelaneous error');</script>");
                return;
            }
            DropDownList2.Text = league.BastPlayerAtTheLeague1;
            TextBox1.Text = league.PTSatLeague1.ToString();
            DropDownList4.Text = league.LeagueLevel1.ToString();
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            League league = new League();
            league.LeagueName = TextBox3.Text;
            league.BastPlayerAtTheLeague1 = DropDownList2.Text;
            league.PTSatLeague1 = int.Parse(TextBox1.Text);
            league.LeagueLevel1 = DropDownList4.SelectedIndex + 1;
            int res = mySvc.UpdateLeague(league);
            if (res == 0)
            {
                Response.Write("<script>alert('the league was updated successfully');</script>");
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

        protected void Button11_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            League[] rows = mySvc.PrintLeaguesList();
            GridView1.DataSource = rows;
            GridView1.DataBind();
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            var client = new Svc();
            var data = client.GetLeaguesChartData();

            Chart1.Series.Clear();
            Series series = new Series("התקדמות הקבוצה");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;

            foreach (League item in data)
            {
                series.Points.AddXY(item.LeagueName, item.LeagueLevel1);
            }

            Chart1.Series.Add(series);
            Chart1.ChartAreas[0].AxisX.Title = "ליגה";
            Chart1.ChartAreas[0].AxisY.Title = "רמה";
        }
    }
}