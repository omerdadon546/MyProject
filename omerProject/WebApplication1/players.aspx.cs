using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Svc = WebApplication1.ServiceReference1.Service1Client;
using Players = WebApplication1.ServiceReference1.PlayrsClass;
using System.Data;

namespace WebApplication1
{
    public partial class players : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] is string)
            {
                if ((string)Session["role"] != "chek")
                {
                    Button13.Visible = false;
                }
                    if ((string)Session["role"] == "שחקן")
                {
                    Button8.Visible = false;
                    Button10.Visible = false;
                    Button9.Visible = false;
                    Button12.Visible = false;
                }
                if ((string)Session["role"] == "chek")
                {
                    Button8.Visible = false;
                    Button10.Visible = false;
                    Button9.Visible = false;
                    Button12.Visible = false;
                    Button7.Visible = false;
                    Button11.Visible = false;
                }
            }

            Svc svc = new Svc();
            Players[] data = svc.PrintPlayersList();
            List<string> stringData = new List<string>();
            for(int i = 0; i < data.Length; i++)
            {
                stringData.Add(data[i].PlayedINLeagues1);
            }
            stringData = stringData.Distinct().ToList();
            DropDownList3.DataSource= stringData;
            DropDownList3.DataBind();

            List<string> stringData2 = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                stringData2.Add(data[i].TrainerID);
            }
            stringData2 = stringData2.Distinct().ToList();
            DropDownList4.DataSource = stringData2;
            DropDownList4.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Players[] rows = mySvc.PrintPlayersList();
            GridView1.DataSource = rows;
            GridView1.DataBind();
        }
        public static int LevelHishuv(Players player)
        {
            int sum = 0;
            sum += player.TO1;
            sum += player.AST1;
            sum += player.BLK1;
            sum += player.fGM;
            sum += player.GP1;
            sum += player.STL1;
            sum = sum / 10;
            if(sum >= 5) { return 5; }
            else if ((5 > sum) && sum>= 4) {  return 4; }
            else if ((4 > sum) && sum >= 3) { return 3; }
            else if ((3 > sum) && sum >= 2) { return 2; }
            else { return 1; }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Players player = new Players();
            player.PlayerNumber = TextBox1.Text;
            player.PlayerName = TextBox2.Text;
            player.LastName1 = TextBox3.Text;
            player.WorkoutDays = "sunady";
            player.fGM = int.Parse(TextBox4.Text);
            player.GP1 = int.Parse(TextBox5.Text);
            player.AST1 = int.Parse(TextBox6.Text);
            player.STL1 = int.Parse(TextBox7.Text);
            player.BLK1 = int.Parse(TextBox8.Text);
            player.TO1 = int.Parse(TextBox9.Text);
            player.PlayedINLeagues1 = DropDownList3.Text;
            player.TrainerID = DropDownList4.Text;
            player.Level1 = LevelHishuv(player);
            int res = mySvc.AddPlayer(player);
            if (res == 0)
            {
                Response.Write("<script>alert('the player was Added successfully');</script>");
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
            Players player = new Players();
            player.PlayerNumber = TextBox1.Text;
            int res = mySvc.DeletePlayer(player);
            if (res == 0)
            {
                Response.Write("<script>alert('the player was Deleted successfully');</script>");
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
            Players player = new Players();
            player.PlayerNumber = TextBox1.Text;
            player = mySvc.SelectPlayer(player);
            if (player.PlayerNumber == "-1")
            {
                Response.Write("<script>alert('the player was selected successfully');</script>");
                return;
            }
            else if(player.PlayerNumber == "-2")
            {
                Response.Write("<script>alert('miscelaneous error');</script>");
                return;
            }
            TextBox2.Text = player.PlayerName;
            TextBox3.Text = player.LastName1;
            DropDownList1.Text = player.WorkoutDays;
            DropDownList2.Text = player.Level1.ToString();
            TextBox4.Text = player.fGM.ToString();
            TextBox5.Text = player.GP1.ToString();
            TextBox6.Text = player.AST1.ToString();
            TextBox7.Text = player.STL1.ToString();
            TextBox8.Text = player.BLK1.ToString();
            TextBox9.Text = player.TO1.ToString();
            DropDownList3.Text = player.PlayedINLeagues1;
            DropDownList3.Text = player.TrainerID;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Players player = new Players();
            player.PlayerNumber = TextBox1.Text;
            player.PlayerName = TextBox2.Text;
            player.LastName1 = TextBox3.Text;
            player.WorkoutDays = DropDownList1.Text;
            player.Level1 = DropDownList2.SelectedIndex+1;
            player.fGM = int.Parse(TextBox4.Text);
            player.GP1 = int.Parse(TextBox5.Text);
            player.AST1 = int.Parse(TextBox6.Text);
            player.STL1 = int.Parse(TextBox7.Text);
            player.BLK1 = int.Parse(TextBox8.Text);
            player.TO1 = int.Parse(TextBox9.Text);
            player.PlayedINLeagues1 = DropDownList3.Text;
            player.TrainerID = DropDownList4.Text;
            int res = mySvc.UpdatePlayer(player);
            if (res == 0)
            {
                Response.Write("<script>alert('the player was updated successfully');</script>");
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
            Svc mySvc = new Svc();
            Players[] rows = mySvc.GetWeakPlayers();
            GridView1.DataSource = rows;
            GridView1.DataBind();
        }


        protected void Button13_Click1(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Players player = new Players();
            player.PlayerNumber = TextBox1.Text;
            player.PlayerName = TextBox2.Text;
            player.LastName1 = TextBox3.Text;
            player.WorkoutDays = "sunady";
            player.fGM = int.Parse(TextBox4.Text);
            player.GP1 = int.Parse(TextBox5.Text);
            player.AST1 = int.Parse(TextBox6.Text);
            player.STL1 = int.Parse(TextBox7.Text);
            player.BLK1 = int.Parse(TextBox8.Text);
            player.TO1 = int.Parse(TextBox9.Text);
            player.PlayedINLeagues1 = DropDownList3.Text;
            player.TrainerID = DropDownList4.Text;
            player.Level1 = LevelHishuv(player);
            int res = mySvc.AddPlayer(player);
            if (res == 0)
            {
                Response.Write("<script>alert('the player was Added successfully');</script>");
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