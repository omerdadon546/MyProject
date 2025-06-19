using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Svc = WebApplication1.ServiceReference1.Service1Client;
using Games = WebApplication1.ServiceReference1.GamesClass;
using Players = WebApplication1.ServiceReference1.PlayrsClass;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace WebApplication1
{
    public partial class games : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Games[] rows = mySvc.PrintGamesList();
            GridView1.DataSource = rows;
            GridView1.DataBind();

            if (Session["role"] is string)
            {
                if ((string)Session["role"] == "שחקן")
                {
                    Button7.Visible = false;
                    Button9.Visible = false;
                    Button10.Visible = false;
                    Button11.Visible = false;
                    Button12.Visible = false;

                }
            }
            Svc svc = new Svc();
            Players[] data = svc.PrintPlayersList();
            List<string> stringData = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                stringData.Add(data[i].PlayerNumber);
            }
            stringData = stringData.Distinct().ToList();
            DropDownList1.DataSource = stringData;
            DropDownList1.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();

            Games myGames = new Games();
            myGames.ShootNumber = int.Parse(TextBox2.Text);
            myGames.PointsInTheGame = TextBox3.Text;
            myGames.PlayersPlayed = DropDownList1.Text;
            myGames.Victory1 = CheckBox1.Checked;
            myGames.Game_level = DropDownList2.SelectedIndex+1;
            int res = mySvc.AddGame(myGames);
            if (res == 0)
            {
                Response.Write("<script>alert('the game was Added successfully');</script>");
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
            Games[] rows = mySvc.PrintGamesList();
            GridView1.DataSource = rows;
            GridView1.DataBind();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Games myGame = new Games();
            myGame.GameNUmver = int.Parse(TextBox1.Text);
            int res = mySvc.DeleteGame(myGame);
            if(res == 0)
            {
                Response.Write("<script>alert('the game was deleted successfully');</script>");
            } else if(res == 1)
            {
                Response.Write("<script>alert('some of the details provided were wrong');</script>");

            } else
            {
                Response.Write("<script>alert('miscelaneous error');</script>");

            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Games game = new Games();
            game.GameNUmver = int.Parse(TextBox1.Text);
            game = mySvc.SelectGame(game);
            if(game.GameNUmver == 0)
            {
                Response.Write("<script>alert('the game was selected successfully');</script>");
                return;
            }
            else if(game.GameNUmver == -2)
            {
                Response.Write("<script>alert('miscelaneous error');</script>");
                return ;
            }
            TextBox2.Text = game.ShootNumber.ToString();
            TextBox3.Text = game.PointsInTheGame;
            DropDownList1.SelectedValue = game.PlayersPlayed;
            CheckBox1.Checked = game.Victory1;
            DropDownList2.SelectedValue = game.Game_level.ToString();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Games game = new Games();
            game.GameNUmver = int.Parse(TextBox1.Text);
            game.ShootNumber = int.Parse(TextBox2.Text);
            game.PointsInTheGame = TextBox3.Text;
            game.PlayersPlayed = DropDownList1.SelectedValue;
            game.Victory1 = CheckBox1.Checked;
            game.Game_level = int.Parse(DropDownList2.SelectedValue);
            int res = mySvc.UpdateGame(game);
            if (res == 0)
            {
                Response.Write("<script>alert('the game was updated successfully');</script>");
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

        protected void Button12_Click(object sender, EventArgs e)
        {
            Svc client = new Svc();

            int winCount = client.GetWinCount();
            int lossCount = client.GetLossCount();

            Series series = new Series("results");
            series.ChartType = SeriesChartType.Column;
            series.Points.AddXY("ניצחונות", winCount);
            series.Points.AddXY("הפסדים", lossCount);

            Chart1.Series.Clear();
            Chart1.Series.Add(series);

        }
    }
}