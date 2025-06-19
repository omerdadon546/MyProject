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
    public class PlayrsClass : HumanSource
    {
        private string workoutDays;
        private int FGM;
        private int GP;
        private int AST;
        private int STL;
        private int BLK;
        private int TO;
        private string PlayedINLeagues;
        private string trainerID;

        public PlayrsClass(string key,string firstName, string lastName, int level, string workoutDays, int fGM, int gP, int aST, int sTL, int bLK, int tO, string playedINLeagues, string trainerID) :base(key, firstName, lastName,level)
        {
            this.key = key;
            this.firstName = firstName;
            LastName = lastName;
            this.workoutDays = workoutDays;
            Level = level;
            FGM = fGM;
            GP = gP;
            AST = aST;
            STL = sTL;
            BLK = bLK;
            TO = tO;
            PlayedINLeagues = playedINLeagues;
            this.trainerID = trainerID;
        }
        public PlayrsClass()
        {

        }
        public PlayrsClass(DataRow dr) : base(dr)
        {
            this.workoutDays = dr["workoutDays"].ToString();
            this.FGM = (int)dr["FGM"];
            this.GP = (int)dr["GP"];
            this.AST = (int)dr["AST"];
            this.STL = (int)dr["STL"];
            this.BLK = (int)dr["BLK"];
            this.TO = (int)dr["TO"];
            this.PlayedINLeagues = dr["PlayedINLeagues"].ToString();
            this.trainerID = dr["trainerID"].ToString();
        }
        [DataMember]

        public string PlayerNumber { get => key; set => key = value; }
        [DataMember]

        public string PlayerName { get => firstName; set => firstName = value; }
        [DataMember]

        public string LastName1 { get => LastName; set => LastName = value; }
        [DataMember]

        public string WorkoutDays { get => workoutDays; set => workoutDays = value; }
        [DataMember]

        public int Level1 { get => Level; set => Level = value; }
        [DataMember]

        public int fGM { get => FGM; set => FGM = value; }
        [DataMember]

        public int GP1 { get => GP; set => GP = value; }
        [DataMember]

        public int AST1 { get => AST; set => AST = value; }
        [DataMember]

        public int STL1 { get => STL; set => STL = value; }
        [DataMember]

        public int BLK1 { get => BLK; set => BLK = value; }
        [DataMember]

        public int TO1 { get => TO; set => TO = value; }
        [DataMember]

        public string PlayedINLeagues1 { get => PlayedINLeagues; set => PlayedINLeagues = value; }
        [DataMember]

        public string TrainerID { get => trainerID; set => trainerID = value; }

        public int Addplayer() 
        {
                Connection MyConn = new Connection();

                try
                {
                    // קריאה לפעולה מהמחלקה הראשית (למשל הכנסת מידע ל־Human_Source)
                    try
                    {
                        base.AddHuman();
                    }
                    catch
                    {
                        // אם יש שגיאה כאן אפשר לטפל או פשוט להמשיך - תלוי בצורך שלך
                    }

                    MyConn.OpenConnection();

                    OleDbCommand cmd = MyConn.Command(
                        "INSERT INTO sahkanim (playerNumber, workoutDays, FGM, GP, AST, STL, BLK, TO, PlayedINLeagues, trainerID) " +
                        "VALUES (@playerNumber,  @workoutDays, @FGM, @GP, @AST, @STL, @BLK, @TO, @PlayedINLeagues, @trainerID)");

                    cmd.Parameters.AddWithValue("@playerNumber", this.key);
                    cmd.Parameters.AddWithValue("@workoutDays", this.WorkoutDays);
                    cmd.Parameters.AddWithValue("@FGM", this.FGM);
                    cmd.Parameters.AddWithValue("@GP", this.GP);
                    cmd.Parameters.AddWithValue("@AST", this.AST);
                    cmd.Parameters.AddWithValue("@STL", this.STL);
                    cmd.Parameters.AddWithValue("@BLK", this.BLK);
                    cmd.Parameters.AddWithValue("@TO", this.TO);
                    cmd.Parameters.AddWithValue("@PlayedINLeagues", this.PlayedINLeagues);
                    cmd.Parameters.AddWithValue("@trainerID", this.trainerID);

                    int rowsAffected = cmd.ExecuteNonQuery(); // מריצים רק פעם אחת

                    if (rowsAffected == 0)
                        return 1; // הפעולה לא הוסיפה שורות

                    return 0; // הצלחה
                }
                catch
                {
                    return 2; // שגיאה כללית (לדוגמה: בעיית מסד נתונים או חיבור)
                }
                finally
                {
                    MyConn.CloseConnection(); // חשוב לסגור את החיבור
                }

        }
        public static PlayrsClass[] PrintPlayersList()
        {
            Connection myConn = new Connection();
            myConn = new Connection();
            myConn.OpenConnection();
            string sql = "select * from sahkanim INNER JOIN human_source ON sahkanim.playerNumber = human_source.key";
            DataRow[] playertList = ((DataTable)myConn.ShowDataInGridView(sql)).Select();
            PlayrsClass[] res = new PlayrsClass[playertList.Length];
            for (int i = 0; i < playertList.Length; i++)
            {
                res[i] = new PlayrsClass(playertList[i]);
            }
            return res;
            
            
        }
        public int DeletePlayer()
        {
            Connection MyConn = new Connection();
            try { 
                base.
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("DELETE FROM sahkanim WHERE playerNumber = @playerNumber");
                cmd.Parameters.AddWithValue("@playerNumber", this.key);
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
        public override void Select()
        {
            try
            {
                base.Select();
            }
            catch { }
            Connection MyConn = new Connection();
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("SELECT * FROM sahkanim WHERE playerNumber = @playerNumber");
                cmd.Parameters.AddWithValue("@playerNumber", this.key);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.key = (string)dr["playerNumber"];
                    this.PlayerName = (string)dr["firstName"];
                    this.LastName = (string)dr["lastName"];
                    this.workoutDays = (string)dr["workoutDays"];
                    this.Level = (int)dr["Level"];
                    this.fGM = (int)dr["FGM"];
                    this.GP = (int)dr["GP"];
                    this.AST = (int)dr["AST"];
                    this.STL = (int)dr["STL"];
                    this.BLK = (int)dr["BLK"];
                    this.TO = (int)dr["TO"];
                    this.PlayedINLeagues = (string)dr["PlayedINLeagues"];
                    this.trainerID = (string)dr["trainerID"];
                }
                else
                {
                    this.key = "-1";
                }
            }
            catch
            {
                this.key = "-2";
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }
        public int UpdatePlayer()
        {
            Connection MyConn = new Connection();
            try
            {
                try
                {
                    base.UpdateHuman();
                }
                catch { }
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("UPDATE sahkanim SET firstName = @firstName, lastName = @lastName, workoutDays = @workoutDays, Level = @Level, FGM = @FGM, GP = @GP, AST = @AST, STL = @STL, BLK = @BLK, TO = @TO, PlayedINLeagues = @PlayedINLeagues, trainerID = @trainerID WHERE playerNumber = @playerNumber");
                cmd.Parameters.AddWithValue("@playerNumber", this.key);
                cmd.Parameters.AddWithValue("@firstName", this.PlayerName);
                cmd.Parameters.AddWithValue("@lastName", this.LastName);
                cmd.Parameters.AddWithValue("@workoutDays", this.WorkoutDays);
                cmd.Parameters.AddWithValue("@Level", this.Level);
                cmd.Parameters.AddWithValue("@FGM", this.FGM);
                cmd.Parameters.AddWithValue("@GP", this.GP);
                cmd.Parameters.AddWithValue("@AST", this.AST);
                cmd.Parameters.AddWithValue("@STL", this.STL);
                cmd.Parameters.AddWithValue("@BLK", this.BLK);
                cmd.Parameters.AddWithValue("@TO", this.TO);
                cmd.Parameters.AddWithValue("@PlayedINLeagues", this.PlayedINLeagues);
                cmd.Parameters.AddWithValue("@trainerID", this.trainerID);
                cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() == 0) return 1;
             }catch{
                return 2;
            }
            finally
            {
                MyConn.CloseConnection();
            }
            return 0;
        }
        public static PlayrsClass[] GetWeakPlayers()
        {
            string sql = @"
        SELECT sahkanim.playerNumber, human_source.level
        FROM sahkanim
        INNER JOIN human_source ON sahkanim.playerNumber = human_source.key
        WHERE human_source.level < 3";

            DataTable dt = (DataTable)new Connection().ShowDataInGridView(sql);
            DataRow[] rows = dt.Select();

            PlayrsClass[] result = new PlayrsClass[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                result[i] = new PlayrsClass
                {
                    PlayerNumber = rows[i]["playerNumber"].ToString(),
                    Level = Convert.ToInt32(rows[i]["level"])
                };
            }

            return result;
        }



    }
}
