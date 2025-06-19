using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Data;
namespace omerWCF.App_Code
{
    [DataContract]
    public class GamesClass
    {
        private int gameNUmver;
        private int shootNumber;
        private string pointsInTheGame;
        private string playersPlayed;
        private bool Victory;
        private int game_level;

        public GamesClass()
        {
        }

        public GamesClass(int gameNUmver, int shootNumber, string pointsInTheGame, string playersPlayed, bool victory, int game_level)
        {
            this.gameNUmver = gameNUmver;
            this.shootNumber = shootNumber;
            this.pointsInTheGame = pointsInTheGame;
            this.playersPlayed = playersPlayed;
            Victory = victory;
            this.game_level = game_level;
        }

        public GamesClass(DataRow dr)
        {
            this.gameNUmver = (int)dr["game_number"];
            this.shootNumber = (int)dr["shootNumber"];
            this.pointsInTheGame = ((int)dr["pointsInTheGame"]).ToString();
            this.playersPlayed = dr["playersPlayed"].ToString();
            Victory = (bool)dr["Victory"];
            this.game_level = (int)dr["game_level"];
        }
        public GamesClass(int shootNumber, string pointsInTheGame, string playersPlayed, bool victory, int game_level)
        {
            this.shootNumber = shootNumber;
            this.pointsInTheGame = pointsInTheGame;
            this.playersPlayed = playersPlayed;
            Victory = victory;
            this.game_level = game_level;
        }
        [DataMember]

        public int GameNUmver { get => gameNUmver; set => gameNUmver = value; }
        [DataMember]

        public int ShootNumber { get => shootNumber; set => shootNumber = value; }
        [DataMember]

        public string PointsInTheGame { get => pointsInTheGame; set => pointsInTheGame = value; }
        [DataMember]

        public string PlayersPlayed { get => playersPlayed; set => playersPlayed = value; }
        [DataMember]

        public bool Victory1 { get => Victory; set => Victory = value; }
        [DataMember]

        public int Game_level { get => game_level; set => game_level = value; }

       public int AddGame()
        {
            // Create a connection to the database
            Connection MyConn = new Connection();
            try { 
                MyConn.OpenConnection();

                // Create the SQL command to insert the new game
                OleDbCommand cmd = MyConn.Command("INSERT INTO games (shootNumber, pointsInTheGame, playersPlayed, Victory, game_level) " +
                                                            "VALUES (@shootNumber, @pointsInTheGame, @playersPlayed, @Victory, @game_level)");

                // Add parameters to the command
                cmd.Parameters.AddWithValue("@shootNumber", this.shootNumber);
                cmd.Parameters.AddWithValue("@pointsInTheGame", this.pointsInTheGame);
                cmd.Parameters.AddWithValue("@playersPlayed", this.playersPlayed);
                cmd.Parameters.AddWithValue("@Victory", this.Victory);
                cmd.Parameters.AddWithValue("@game_level", this.game_level);

                // Execute the insert command
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
        public int DeleteGame()
        {
            Connection MyConn = new Connection();
            try { 
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("DELETE FROM games WHERE game_number = @game_number");
                cmd.Parameters.AddWithValue("@game_number", this.GameNUmver);
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

        public void SelectGame()
        {
            Connection MyConn = new Connection();
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("SELECT * FROM games WHERE game_number = @game_number");
                cmd.Parameters.AddWithValue("@game_number", this.GameNUmver);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.GameNUmver = (int)dr["game_number"];
                    this.ShootNumber = (int)dr["shootNumber"];
                    this.PointsInTheGame = dr["pointsInTheGame"].ToString();
                    this.PlayersPlayed = dr["playersPlayed"].ToString();
                    this.Victory1 = (bool)dr["Victory"];
                    this.Game_level = (int)dr["game_level"];
                }
                else
                {
                    this.GameNUmver = 0;
                }
            }
            catch
            {
                this.gameNUmver = -2;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        public int UpdateGame()
        {
            Connection MyConn = new Connection();
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("UPDATE games SET shootNumber = @shootNumber, pointsInTheGame = @pointsInTheGame, playersPlayed = @playersPlayed, Victory = @Victory, game_level = @game_level WHERE game_number = @game_number");
                cmd.Parameters.AddWithValue("@game_number", this.GameNUmver);
                cmd.Parameters.AddWithValue("@shootNumber", this.ShootNumber);
                cmd.Parameters.AddWithValue("@pointsInTheGame", this.PointsInTheGame);
                cmd.Parameters.AddWithValue("@playersPlayed", this.PlayersPlayed);
                cmd.Parameters.AddWithValue("@Victory", this.Victory1);
                cmd.Parameters.AddWithValue("@game_level", this.Game_level);
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

        public static GamesClass[] PrintGamesList()
        {
            try
            {
                Connection myConn = new Connection();
                myConn.OpenConnection();
                string sql = "select * from games";
                DataRow[] gamestList = ((DataTable)myConn.ShowDataInGridView(sql)).Select();
                GamesClass[] res = new GamesClass[gamestList.Length];
                for(int i = 0; i < gamestList.Length; i++)
                {
                    res[i] = new GamesClass(gamestList[i]);
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
        public static int CountWins()
        {
            string sql = "SELECT * FROM games WHERE Victory = True";
            DataTable dt = (DataTable)new Connection().ShowDataInGridView(sql);
            return dt.Rows.Count;
        }

        public static int CountLosses()
        {
            string sql = "SELECT * FROM games WHERE Victory = False";
            DataTable dt = (DataTable)new Connection().ShowDataInGridView(sql);
            return dt.Rows.Count;
        }


    }
}
