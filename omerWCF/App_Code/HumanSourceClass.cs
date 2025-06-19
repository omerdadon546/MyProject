using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace omerWCF.App_Code
{
    [DataContract]
    public class HumanSource
    {
        protected string key;
        protected string firstName;
        protected string lastName;
        protected int level;
        [DataMember]
        public string Key { get => key; set => key = value; }
        [DataMember]

        public string FirstName { get => firstName; set => firstName = value; }
        [DataMember]

        public string LastName { get => lastName; set => lastName = value; }
        [DataMember]

        public int Level { get => level; set => level = value; }

        public HumanSource(string key, string firstName, string lastName, int level)
        {
            this.key = key;
            this.firstName = firstName;
            this.lastName = lastName;
            this.level = level;
        }
        public HumanSource()
        {
        }
        public HumanSource(DataRow dr)
        {
            this.key = dr["key"].ToString();
            this.firstName = dr["firstName"].ToString();
            this.lastName = dr["lastName"].ToString();
            this.level = (int)dr["level"];
        }
        public void AddHuman()
        {
            Connection MyConn = new Connection();
            MyConn.OpenConnection();
            OleDbCommand cmd = MyConn.Command("insert into human_source (id, first_name, last_name, phone, mail)Values(@id, @Fname, @Lname, @phone, @mail)");
            cmd.Parameters.AddWithValue("@key", this.key);
            cmd.Parameters.AddWithValue("@firstName", this.firstName);
            cmd.Parameters.AddWithValue("@lastName", this.lastName);
            cmd.Parameters.AddWithValue("@level", this.level);
            cmd.ExecuteNonQuery();
            MyConn.CloseConnection();
        }
        public virtual void Select()
        {
            Connection MyConn = new Connection();
            MyConn.OpenConnection();
            OleDbCommand cmd = MyConn.Command("select * from human_source where key=@key");
            cmd.Parameters.AddWithValue("@key", key);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FirstName = dr[1].ToString();
                LastName = dr[2].ToString();
                level = (int)dr[3];
            }

            dr.Close();
            MyConn.CloseConnection();
        }
        public void UpdateHuman()
        {
            Connection MyConn = new Connection();
            MyConn.OpenConnection();
            OleDbCommand cmd = MyConn.Command("Update human_source Set first_name=@Fname, last_name=@Lname, phone=@phone, mail=@mail Where id=@id");
            cmd.Parameters.AddWithValue("@first_name", FirstName);
            cmd.Parameters.AddWithValue("@last_name", LastName);
            cmd.Parameters.AddWithValue("@phone", level);
            cmd.ExecuteNonQuery();
            MyConn.CloseConnection();
        }
    }


}

