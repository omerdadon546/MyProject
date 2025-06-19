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
    public class TrainingClass
    {
        private string workoutDay;
        private string trainingType;
        private int TrainingLevel;
        private string TrainingHouer;
        private string trainerID;

        public TrainingClass(string workoutDay, string trainingType, int trainingLevel, string trainingHouer, string trainerID)
        {
            this.workoutDay = workoutDay;
            this.trainingType = trainingType;
            TrainingLevel = trainingLevel;
            TrainingHouer = trainingHouer;
            this.trainerID = trainerID;
        }
        public TrainingClass(DataRow dr)
        {
            this.workoutDay = dr["workoutDay"].ToString();
            this.trainingType = dr["trainingType"].ToString();
            this.TrainingLevel = (int)dr["TrainingLevel"];
            this.TrainingHouer = dr["TrainingHouer"].ToString();
            this.trainerID = dr["trainerID"].ToString();
        }
        [DataMember]
        public string WorkoutDay { get => workoutDay; set => workoutDay = value; }
        [DataMember]
        public string TrainingType { get => trainingType; set => trainingType = value; }
        [DataMember]
        public int TrainingLevel1 { get => TrainingLevel; set => TrainingLevel = value; }
        [DataMember]
        public string TrainingHouer1 { get => TrainingHouer; set => TrainingHouer = value; }
        [DataMember]
        public string TrainerID { get => trainerID; set => trainerID = value; }

        public int AddTraining()
        {
            Connection MyConn = new Connection();
            try { 
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("insert into training (workoutDay,trainingType,TrainingLevel,TrainingHouer,trainerID) Values (@workoutDay,@trainingType, @TrainingLevel, @TrainingHouer, @trainerID)");
                cmd.Parameters.AddWithValue("@workoutDay", this.workoutDay);
                cmd.Parameters.AddWithValue("@trainingType", this.trainingType);
                cmd.Parameters.AddWithValue("@TrainingLevel", this.TrainingLevel);
                cmd.Parameters.AddWithValue("@TrainingHouer", this.TrainingHouer);
                cmd.Parameters.AddWithValue("@trainerID", this.trainerID);
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
        public int DeleteTraining()
        {
            Connection MyConn = new Connection();
            try { 
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("DELETE FROM training WHERE workoutDay = @workoutDay");
                cmd.Parameters.AddWithValue("@workoutDay", this.workoutDay);
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
        public void SelectTraining()
        {
            Connection MyConn = new Connection();
            try { 
            MyConn.OpenConnection();
            OleDbCommand cmd = MyConn.Command("SELECT * FROM training WHERE workoutDay = @workoutDay");
            cmd.Parameters.AddWithValue("@workoutDay", this.workoutDay);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.workoutDay = (string)dr["workoutDay"];
                this.trainingType = (string)dr["trainingType"];
                this.TrainingLevel = (int)dr["TrainingLevel"];
                this.TrainingHouer = (string)dr["TrainingHouer"];
                this.trainerID = (string)dr["trainerID"];
            }
            else
            {
                this.workoutDay = "";
            }
            }
            catch
            {
                this.workoutDay = "-2";
            }
            finally
            {
                MyConn.CloseConnection();
            }

        }
        public static TrainingClass[] PrintTrainingList()
        {
            try
            {
                Connection myConn = new Connection();
                myConn.OpenConnection();
                string sql = "select * from training";
                DataRow[] TrainingList = ((DataTable)myConn.ShowDataInGridView(sql)).Select();
                TrainingClass[] res = new TrainingClass[TrainingList.Length];
                for (int i = 0; i < TrainingList.Length; i++)
                {
                    res[i] = new TrainingClass(TrainingList[i]);
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
        public int UpdateTraining()
        {
            Connection MyConn = new Connection();
            try { 

                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("UPDATE training SET trainingType = @trainingType, TrainingLevel = @TrainingLevel, TrainingHouer = @TrainingHouer, trainerID = @trainerID WHERE workoutDay = @workoutDay");
                cmd.Parameters.AddWithValue("@workoutDay", this.workoutDay);
                cmd.Parameters.AddWithValue("@trainingType", this.trainingType);
                cmd.Parameters.AddWithValue("@TrainingLevel", this.TrainingLevel);
                cmd.Parameters.AddWithValue("@TrainingHouer", this.TrainingHouer);
                cmd.Parameters.AddWithValue("@trainerID", this.trainerID);
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
    }
}
