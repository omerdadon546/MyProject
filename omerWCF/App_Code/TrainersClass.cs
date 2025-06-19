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
    public class TrainersClass : HumanSource
    {
        private DateTime startWorking;

        public TrainersClass()
        {
        }

        public TrainersClass(string key, string firstName, string lastName, int level, DateTime startWorking): base(key, firstName,lastName,level)
        {
            this.key = key;
            this.firstName = firstName;
            this.lastName = lastName;
            this.level = level;
            this.startWorking = startWorking;
        }
        public TrainersClass(DataRow dr)
        {
            this.startWorking = (DateTime)dr["startWorking"];
        }
        [DataMember]

        public string Id { get => key; set => key = value; }
        [DataMember]

        public string Fname1 { get => firstName; set => firstName = value; }
        [DataMember]

        public string Lname1 { get => lastName; set => lastName = value; }
        [DataMember]

        public int Level1 { get => Level; set => Level = value; }
        [DataMember]
        public DateTime StartWorking { get => startWorking; set => startWorking = value; }

        public int AddTrainer()
        {
            Connection MyConn = new Connection();
            try { 
                try
                {
                    base.AddHuman();
                }
                catch { }
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("insert into Trainers (trainerID,firstName,lastName,trainingLevel,startWorking)Values(@trainerID, @firstName, @lastName, @trainingLevel,@startWorking)");
                cmd.Parameters.AddWithValue("@trainerID", this.key);
                cmd.Parameters.AddWithValue("@startWorking", this.startWorking);
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
        public int DeleteTrainer()
        {
            Connection MyConn = new Connection();
            try { 
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("DELETE FROM trainers WHERE trainerID = @trainerID");
                cmd.Parameters.AddWithValue("@trainerID", this.Id);
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
        public void SelectTrainer()
        {

            try
            {
                base.SelectHuman();
            }
            catch { }
            Connection MyConn = new Connection();
            try { 
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("SELECT * FROM trainers WHERE trainerID = @trainerID");
                cmd.Parameters.AddWithValue("@trainerID", this.Id);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.key = (string)dr["trainerID"];
                    this.firstName = (string)dr["firstName"];
                    this.lastName = (string)dr["lastName"];
                    this.Level = (int)dr["trainingLevel"];
                    this.startWorking = (DateTime)dr["startWorking"];
                }
                else
                {
                    this.Id = "";
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
        public int UpdateTrainer()
        {
            Connection MyConn = new Connection();

            try
            {
                try
                {
                    base.UpdateHuman();
                }
                catch { return 0; }
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command("UPDATE trainers SET firstName = @firstName, lastName = @lastName, trainingLevel = @trainingLevel, startWorking = @startWorking WHERE trainerID = @trainerID");
                cmd.Parameters.AddWithValue("@trainerID", this.key);
                cmd.Parameters.AddWithValue("@firstName", this.firstName);
                cmd.Parameters.AddWithValue("@lastName", this.lastName);
                cmd.Parameters.AddWithValue("@trainingLevel", this.level);
                cmd.Parameters.AddWithValue("@startWorking", this.StartWorking);
                if (cmd.ExecuteNonQuery() == 0) return 1;
            } catch {
                return 2;
            } finally
            {
                MyConn.CloseConnection();
            }
            return 0;

        }
        public static TrainersClass[] PrintTrainersList()
        {
                Connection myConn = new Connection();
                myConn.OpenConnection();
                string sql = "select * from trainers INNER JOIN human_source ON Trainers.trainerID = human_source.key";
                DataRow[] TrainingList = ((DataTable)myConn.ShowDataInGridView(sql)).Select();
                TrainersClass[] res = new TrainersClass[TrainingList.Length];
                for (int i = 0; i < TrainingList.Length; i++)
                {
                    res[i] = new TrainersClass(TrainingList[i]);
                }
                return res;
        }
        public static TrainersClass[] GetTrainersSalaryBySeniority()
        {
            string sql = @"
        SELECT 
            trainerID, 
            startWorking
        FROM Trainers";

            DataRow[] rows = ((DataTable)new Connection().ShowDataInGridView(sql)).Select();
            TrainersClass[] result = new TrainersClass[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                result[i] = new TrainersClass
                {
                    Key = rows[i]["trainerID"].ToString(),
                    StartWorking = Convert.ToDateTime(rows[i]["startWorking"])
                };
            }

            return result;
        }

    }


}
