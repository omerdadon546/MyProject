using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code
{
    public class TrainersClass
    {
        private string id;
        private string Fname;
        private string Lname;
        private int Level;

        public TrainersClass(string id, string fname, string lname, int level)
        {
            this.id = id;
            Fname = fname;
            Lname = lname;
            Level = level;
        }

        public string Id { get => id; set => id = value; }
        public string Fname1 { get => Fname; set => Fname = value; }
        public string Lname1 { get => Lname; set => Lname = value; }
        public int Level1 { get => Level; set => Level = value; }
    }
}