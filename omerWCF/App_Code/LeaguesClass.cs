using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Runtime.Serialization;
using System.Data;

namespace omerWCF.App_Code
{
    [DataContract]
    public class LeaguesClass
    {
        private string leagueName;
        private string BastPlayerAtTheLeague;
        private int PTSatLeague;
        private string CoachName;
        private int LeagueLevel;

        public LeaguesClass(string leagueName, string bastPlayerAtTheLeague, int pTSatLeague, string coachName, int leagueLevel)
        {
            this.leagueName = leagueName;
            BastPlayerAtTheLeague = bastPlayerAtTheLeague;
            PTSatLeague = pTSatLeague;
            CoachName = coachName;
            LeagueLevel = leagueLevel;
        }
        public LeaguesClass()
        {

        }
        public LeaguesClass(DataRow dr)
        {
            this.LeagueName = dr["leagueName"].ToString();
            this.BastPlayerAtTheLeague = dr["BastPlayerAtTheLeague"].ToString();
            this.PTSatLeague = (int)dr["PTSatLeague"];
            this.LeagueLevel = (int)dr["LeagueLevel"];
            this.CoachName = dr["CoachName"].ToString();
        }
        [DataMember]
        public string LeagueName { get => leagueName; set => leagueName = value; }
        [DataMember]

        public string BastPlayerAtTheLeague1 { get => BastPlayerAtTheLeague; set => BastPlayerAtTheLeague = value; }
        [DataMember]

        public int PTSatLeague1 { get => PTSatLeague; set => PTSatLeague = value; }
        [DataMember]

        public string CoachName1 { get => CoachName; set => CoachName = value; }
        [DataMember]

        public int LeagueLevel1 { get => LeagueLevel; set => LeagueLevel = value; }

        public int Addleagues()
        {
            Connection MyConn = new Connection();
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("insert into leagues (leagueName,BastPlayerAtTheLeague,PTSatLeague,coachName,LeagueLevel)Values(@leagueName,@BastPlayerAtTheLeague, @PTSatLeague, @coachName, @LeagueLevel)");
                cmd.Parameters.AddWithValue("@leagueName", this.leagueName);
                cmd.Parameters.AddWithValue("@BastPlayerAtTheLeague", this.BastPlayerAtTheLeague);
                cmd.Parameters.AddWithValue("@PTSatLeague", this.PTSatLeague);
                cmd.Parameters.AddWithValue("@coachName", this.CoachName);
                cmd.Parameters.AddWithValue("@LeagueLevel", this.LeagueLevel);
                cmd.ExecuteNonQuery();
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
        public int DeleteLeague()
        {
            Connection MyConn = new Connection();
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("DELETE FROM leagues WHERE leagueName = @leagueName");
                cmd.Parameters.AddWithValue("@leagueName", this.LeagueName);
                cmd.ExecuteNonQuery();
                MyConn.CloseConnection();
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
        public void SelectLeague()
        {
            Connection MyConn = new Connection();
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("SELECT * FROM leagues WHERE leagueName = @leagueName");
                cmd.Parameters.AddWithValue("@leagueName", this.leagueName);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.leagueName = (string)dr["leagueName"];
                    this.BastPlayerAtTheLeague = (string)dr["BastPlayerAtTheLeague"];
                    this.PTSatLeague = (int)dr["PTSatLeague"];
                    this.LeagueLevel = (int)dr["LeagueLevel"];
                    this.CoachName = (string)dr["CoachName"];
                }
                else
                {
                    this.leagueName = "-1";
                }
            }
            catch
            {
                this.leagueName = "-2";
            }
            finally
            {
                MyConn.CloseConnection();
            }


        }
        public int UpdateLeague()
        {
            Connection MyConn = new Connection();
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("UPDATE leagues SET BastPlayerAtTheLeague = @BastPlayerAtTheLeague, PTSatLeague = @PTSatLeague, CoachName = @CoachName, LeagueLevel = @LeagueLevel WHERE leagueName = @leagueName");
                cmd.Parameters.AddWithValue("@leagueName", this.leagueName);
                cmd.Parameters.AddWithValue("@BastPlayerAtTheLeague", this.BastPlayerAtTheLeague);
                cmd.Parameters.AddWithValue("@PTSatLeague", this.PTSatLeague);
                cmd.Parameters.AddWithValue("@CoachName", this.CoachName);
                cmd.Parameters.AddWithValue("@LeagueLevel", this.LeagueLevel);
                cmd.ExecuteNonQuery();
                MyConn.CloseConnection();
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
        public static LeaguesClass[] PrintLeaguesList()
        {
            try
            {
                Connection myConn = new Connection();
                myConn.OpenConnection();
                string sql = "select * from leagues";
                DataRow[] TrainingList = ((DataTable)myConn.ShowDataInGridView(sql)).Select();
                LeaguesClass[] res = new LeaguesClass[TrainingList.Length];
                for (int i = 0; i < TrainingList.Length; i++)
                {
                    res[i] = new LeaguesClass(TrainingList[i]);
                }
                return res;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {

            }
        }
        public static List<LeaguesClass> GetLeaguesChartData()
        {
            List<LeaguesClass> scores = new List<LeaguesClass>();
            Connection con = new Connection();
            con.OpenConnection();

            OleDbCommand cmd = con.Command("select * from leagues");
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                scores.Add(new LeaguesClass
                {
                    leagueName = reader["leagueName"].ToString(),
                    LeagueLevel = (int)(reader["LeagueLevel"])
                });
            }

            reader.Close();
            con.CloseConnection();
            return scores;
        }
    }
}
