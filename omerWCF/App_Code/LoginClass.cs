using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace omerWCF.App_Code
{
    [DataContract]
    public class LoginClass
    {
        private string username;
        private string password;
        private DateTime birthday;
        private string role;
        [DataMember]
        public string Username { get => username; set => username = value; }
        [DataMember]
        public string Password { get => password; set => password = value; }
        [DataMember]    
        public DateTime Birthday { get => birthday; set => birthday = value; }
        [DataMember]    
        public string Role { get => role; set => role = value; }

        public LoginClass(string username, string password, DateTime birthday, string role)
        {
            this.username = username;
            this.password = password;
            this.birthday = birthday;
            this.role = role;
        }
        public LoginClass() { }


        public int signUp()
        {
            Connection MyConn = new Connection();
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("INSERT INTO login (username,[password],birthday,[role]) Values (@username, @password, @birthday, @role)");
                cmd.Parameters.AddWithValue("@username", this.username);
                cmd.Parameters.AddWithValue("@password", this.password);
                cmd.Parameters.AddWithValue("@birthday", this.birthday);
                cmd.Parameters.AddWithValue("@role", this.role);
                if (cmd.ExecuteNonQuery() == 0) return 1;
            }
            catch
            {
                return 2;
            }
            finally
            {
                MyConn.CloseConnection();
            }
            return 0;
        }
        public string login()
        {
            Connection MyConn = new Connection();
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("SELECT * FROM login WHERE username = @username");
                cmd.Parameters.AddWithValue("@username", this.username);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (this.password == dr["password"].ToString()) { return dr["role"].ToString(); }
                    else return "the passwords did not match";
                }
                else
                {
                    return "0";
                }
            }
            catch
            {
                return "-2";
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }
    }
}
