using System;
using System.Data;
using System.Data.OleDb;

namespace omerWCF.App_Code
{
    public class TrainerQueriesExamples
    {
        private Connection MyConn = new Connection();

        // דוגמה להוספת מאמן חדש
        public int AddNewTrainer(string trainerID, string firstName, string lastName, int level, DateTime startWorking)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.InsertTrainerQuery);
                cmd.Parameters.AddWithValue("@trainerID", trainerID);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@trainingLevel", level);
                cmd.Parameters.AddWithValue("@startWorking", startWorking);
                
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה למחיקת מאמן
        public int DeleteTrainer(string trainerID)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.DeleteTrainerQuery);
                cmd.Parameters.AddWithValue("@trainerID", trainerID);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לבחירת מאמן ספציפי
        public DataRow GetTrainer(string trainerID)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.SelectTrainerQuery);
                cmd.Parameters.AddWithValue("@trainerID", trainerID);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לעדכון פרטי מאמן
        public int UpdateTrainer(string trainerID, string firstName, string lastName, int level, DateTime startWorking)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.UpdateTrainerQuery);
                cmd.Parameters.AddWithValue("@trainerID", trainerID);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@trainingLevel", level);
                cmd.Parameters.AddWithValue("@startWorking", startWorking);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לקבלת כל המאמנים
        public DataTable GetAllTrainers()
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetAllTrainersQuery);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לחיפוש מאמן לפי שם פרטי
        public DataTable SearchTrainerByFirstName(string firstName)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainerByFirstNameQuery);
                cmd.Parameters.AddWithValue("@firstName", "%" + firstName + "%");
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לקבלת מאמנים לפי רמת אימון
        public DataTable GetTrainersByLevel(int level)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainersByLevelQuery);
                cmd.Parameters.AddWithValue("@trainingLevel", level);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לקבלת מאמנים לפי טווח תאריכים
        public DataTable GetTrainersByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainersByDateRangeQuery);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לקבלת ספירת מאמנים לפי רמה
        public DataTable GetTrainerCountByLevel()
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainerCountByLevelQuery);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לקבלת מאמנים עם ניסיון של X שנים
        public DataTable GetExperiencedTrainers(int yearsOfExperience)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetExperiencedTrainersQuery);
                cmd.Parameters.AddWithValue("@yearsOfExperience", yearsOfExperience);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לקבלת מאמנים לפי רמה וניסיון
        public DataTable GetTrainersByLevelAndExperience(int level, int yearsOfExperience)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainersByLevelAndExperienceQuery);
                cmd.Parameters.AddWithValue("@trainingLevel", level);
                cmd.Parameters.AddWithValue("@yearsOfExperience", yearsOfExperience);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לקבלת מאמנים לפי שנת התחלת עבודה
        public DataTable GetTrainersByYear(int year)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainersByYearQuery);
                cmd.Parameters.AddWithValue("@year", year);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לקבלת מאמנים לפי חודש התחלת עבודה
        public DataTable GetTrainersByMonth(int month)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainersByMonthQuery);
                cmd.Parameters.AddWithValue("@month", month);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }

        // דוגמה לקבלת מאמנים לפי רמה ומספר שעות אימון
        public DataTable GetTrainersByLevelAndHours(int level, int minHours)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainersByLevelAndHoursQuery);
                cmd.Parameters.AddWithValue("@trainingLevel", level);
                cmd.Parameters.AddWithValue("@minHours", minHours);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                MyConn.CloseConnection();
            }
        }
    }
} 