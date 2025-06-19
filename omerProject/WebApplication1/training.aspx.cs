using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Svc = WebApplication1.ServiceReference1.Service1Client;
using Training = WebApplication1.ServiceReference1.TrainingClass;
using System.Data;
using System.Security.Cryptography;
using RestSharp;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace WebApplication1
{
    public partial class training : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Training[] rows = mySvc.PrintTraningList();
            GridView1.DataSource = rows;
            GridView1.DataBind();

            if (Session["role"] is string)
            {
                if ((string)Session["role"] == "שחקן")
                {
                    Button11.Visible = false;
                    Button10.Visible = false;
                    Button9.Visible = false;
                    Button12.Visible = false;
                }
            }
            try
            {
                RestClient client = new RestClient("https://api.open-meteo.com/");
                RestRequest request = new RestRequest("/v1/forecast/");
                request.AddParameter("latitude", "31.25");
                request.AddParameter("longitude", "34.78");
                request.AddParameter("daily", "temperature_2m_mean");
                RestResponse response = client.Execute(request);
                JObject json = JObject.Parse(response.Content);
                Label6.Text = $"the weather in Omer is {json["daily"]["temperature_2m_mean"][0].ToString()} C";
            }
            catch
            {

            }
            Svc svc = new Svc();
            Training[] data = svc.PrintTraningList();
            List<string> stringData = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                stringData.Add(data[i].TrainerID);
            }
            stringData = stringData.Distinct().ToList();
            DropDownList4.DataSource = stringData;
            DropDownList4.DataBind();
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Training training = new Training();
            training.WorkoutDay = TextBox1.Text;
            training.TrainingType = DropDownList1.Text;
            training.TrainingLevel1 = DropDownList2.SelectedIndex+1;
            training.TrainingHouer1 = DropDownList3.Text;
            training.TrainerID = DropDownList4.Text;
            int res = mySvc.AddTraining(training);
            if (res == 0)
            {
                Response.Write("<script>alert('the training was Added successfully');</script>");
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

        protected void Button10_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Training train = new Training();
            train.WorkoutDay = TextBox1.Text;
            int res = mySvc.DeleteTraining(train);
            if (res == 0)
            {
                Response.Write("<script>alert('the training was Deleted successfully');</script>");
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
            Training train = new Training();
            train.WorkoutDay = TextBox1.Text;
            train = mySvc.SelectTraining(train);
            if(train.WorkoutDay == "")
            {
                Response.Write("<script>alert('the training was selected successfully');</script>");
                return;
            } else if(train.WorkoutDay == "-2")
            {
                Response.Write("<script>alert('miscelaneous error');</script>");
                return;
            }
            DropDownList1.Text = train.TrainingType;
            DropDownList2.Text = train.TrainingLevel1.ToString();
            DropDownList3.Text = train.TrainingHouer1;
            DropDownList4.Text = train.TrainerID;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Training[] rows = mySvc.PrintTraningList();
            GridView1.DataSource = rows;
            GridView1.DataBind();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Training train = new Training();
            train.WorkoutDay = TextBox1.Text;
            train.TrainingType = DropDownList1.Text;
            train.TrainingLevel1 = DropDownList2.SelectedIndex +1 ;
            train.TrainingHouer1 = DropDownList3.Text;
            train.TrainerID = DropDownList4.Text;

            int res = mySvc.UpdateTraining(train);
            if (res == 0)
            {
                Response.Write("<script>alert('the training was Updated successfully');</script>");
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

        protected void Button13_Click(object sender, EventArgs e)
        {
            string[] videoIds = new string[]
{
        "-hSma-BRzoo", 
        "0J1QYTJbvGQ&t=120s",
        "wQREYx3fY7k",
        "SZkfcTTmQls"
};

            Random rnd = new Random();
            int index = rnd.Next(videoIds.Length);
            string selectedVideoId = videoIds[index];

            string embedHtml = $@"
        <iframe width='560' height='315' 
                src='https://www.youtube.com/embed/{selectedVideoId}' 
                frameborder='0' 
                allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' 
                allowfullscreen>
        </iframe>";

            litVideo.Text = embedHtml;
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            string[] imageUrls = new string[]
{
        "https://www.ducksters.com/sports/basketball/zone_defense_2-3.jpg",
        "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Basketball_positions_he.svg/500px-Basketball_positions_he.svg.png",
        "https://www.storiespreschool.com/images/basketball_2-3_defense.jpg",
        "https://www.basketballforcoaches.com/wp-content/uploads/2015/01/trapping-top.jpg"
};

            Random rnd = new Random();
            int index = rnd.Next(imageUrls.Length);
            string selectedImage = imageUrls[index];

            imgRandom.ImageUrl = selectedImage;
        }
    }
}