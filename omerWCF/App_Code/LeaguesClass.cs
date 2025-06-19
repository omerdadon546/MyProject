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
                int rowsAffected = cmd.ExecuteNonQuery(); // Single call
                if (rowsAffected > 0)
                {
                    MyConn.CloseConnection(); // Close before successful return
                    return 0; // Success
                }
                else
                {
                    MyConn.CloseConnection(); // Close before "logical error" return
                    return 1; // No rows affected / logical error
                }
            }
            catch
            {
                return 2;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }
        public int DeleteLeague()
        {
            Connection MyConn = new Connection();
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("DELETE FROM leagues WHERE leagueName = @leagueName");
                cmd.Parameters.AddWithValue("@leagueName", this.LeagueName);
                int rowsAffected = cmd.ExecuteNonQuery(); // Single call
                // MyConn.CloseConnection(); // Already called in finally, explicit close before return is good.
                if (rowsAffected > 0)
                {
                    MyConn.CloseConnection(); // Close before successful return
                    return 0; // Success
                }
                else
                {
                    MyConn.CloseConnection(); // Close before "logical error" return
                    return 1; // No rows affected / logical error
                }
            }
            catch
            {
                return 2;
            }
            finally
            {
                MyConn.CloseConnection();
            }
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
                int rowsAffected = cmd.ExecuteNonQuery(); // Single call
                if (rowsAffected > 0)
                {
                    MyConn.CloseConnection(); // Close before successful return
                    return 0; // Success
                }
                else
                {
                    MyConn.CloseConnection(); // Close before "logical error" return
                    return 1; // No rows affected / logical error
                }
            }
            catch
            {
                return 2;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }
        public static LeaguesClass[] PrintLeaguesList()
        {
            try
            {
                Connection connUtility = new Connection(); // Instance to call method
                string sql = "select * from leagues";
                // ShowDataInGridView handles its own connection using the ConnectionString
                DataRow[] TrainingList = ((DataTable)connUtility.ShowDataInGridView(sql)).Select();
                LeaguesClass[] res = new LeaguesClass[TrainingList.Length];
                for (int i = 0; i < TrainingList.Length; i++)
                {
                    res[i] = new LeaguesClass(TrainingList[i]);
                }
                return res;
            }
            catch (Exception ex)
            {
                // Consider logging the exception or wrapping it in a custom exception
                throw ex; // Preserving existing behavior
            }
        }
        public static List<LeaguesClass> GetLeaguesChartData()
        {
            List<LeaguesClass> scores = null;
            Connection con = null;
            OleDbDataReader reader = null;
            try
            {
                con = new Connection();
                con.OpenConnection();

                OleDbCommand cmd = con.Command("select * from leagues");
                reader = cmd.ExecuteReader();
                scores = new List<LeaguesClass>(); // Initialize inside try

                while (reader.Read())
                {
                    scores.Add(new LeaguesClass
                    {
                        leagueName = reader["leagueName"].ToString(),
                        LeagueLevel = (int)(reader["LeagueLevel"])
                    });
                }
                return scores;
            }
            catch (Exception ex)
            {
                // Consider logging the exception or re-throwing if appropriate
                // For now, re-throwing to maintain consistency if no specific error handling is defined
                throw;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                if (con != null) // Assuming con.CloseConnection can handle if OpenConnection failed or already closed
                {
                    con.CloseConnection();
                }
            }
        }
    }
}
