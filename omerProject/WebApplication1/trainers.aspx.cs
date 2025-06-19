using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Svc = WebApplication1.ServiceReference1.Service1Client;
using Trainers = WebApplication1.ServiceReference1.TrainersClass;
using System.Data;
using System.Security.Cryptography;

namespace WebApplication1
{
    public partial class trainers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] is string)
            {
                if ( (string)Session["role"] == "מאמן")
                {
                    Button7.Visible = false;
                    Button8.Visible = false;
                    Button10.Visible = false;
                    Button12.Visible = false;
                }
            }

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Trainers myTrainer = new Trainers();
            myTrainer.Id = TextBox1.Text;
            myTrainer.Fname1 = TextBox2.Text;
            myTrainer.Lname1 = TextBox3.Text;
            myTrainer.Level1 = DropDownList1.SelectedIndex + 1;
            myTrainer.StartWorking = Calendar1.SelectedDate;
            int res = mySvc.AddTrainer(myTrainer);
            if (res == 0)
            {
                Response.Write("<script>alert('the trainer was Added successfully');</script>");
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
            Trainers myTrainer = new Trainers();
            myTrainer.Id = TextBox1.Text;
            int res = mySvc.DeleteTrainer(myTrainer);
            if (res == 0)
            {
                Response.Write("<script>alert('the trainer was deleted successfully');</script>");
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
            Trainers trainer = new Trainers();
            trainer.Id = TextBox1.Text;
            trainer = mySvc.SelectTrainer(trainer);
            if(trainer.Id == "")
            {
                Response.Write("<script>alert('the trainer was selected successfully');</script>");
                return;
            }
            if(trainer.Id == "-2")
            {
                Response.Write("<script>alert('miscelaneous error');</script>");

            }
            TextBox2.Text = trainer.Fname1;
            TextBox3.Text = trainer.Lname1;
            DropDownList1.Text = trainer.Level1.ToString();
            Calendar1.SelectedDate = trainer.StartWorking;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Svc mySvc = new Svc();
            Trainers trainer = new Trainers();
            trainer.Id = TextBox1.Text;
            trainer.Fname1 = TextBox2.Text;
            trainer.Lname1 = TextBox3.Text;
            trainer.Level1 = DropDownList1.SelectedIndex +1;
            trainer.StartWorking = Calendar1.SelectedDate;
            int res = mySvc.UpdateTrainer(trainer);
            if (res == 0)
            {
                Response.Write("<script>alert('the trainer was updated successfully');</script>");
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
            Trainers[] rows = mySvc.PrintTrainersLinst();
            GridView1.DataSource = rows;
            GridView1.DataBind();
        }

        protected void Button12_Click(object sender, EventArgs e)
        {

            Svc client = new Svc();
            var trainers = client.GetTrainersSalaryBySeniority();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("StartWorking");
            dt.Columns.Add("SeniorityYears", typeof(int));
            dt.Columns.Add("Salary", typeof(int));

            foreach (var trainer in trainers)
            {
                int seniority = DateTime.Now.Year - trainer.StartWorking.Year;
                int salary = seniority * 1000;

                dt.Rows.Add(trainer.Key, trainer.StartWorking.ToShortDateString(), seniority, salary);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}