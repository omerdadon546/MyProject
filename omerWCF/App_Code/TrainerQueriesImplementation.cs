using System;
using System.Data;
using System.Data.OleDb;

namespace omerWCF.App_Code
{
    public class TrainerQueriesImplementation
    {
        private Connection MyConn = new Connection();

        // הוספת מאמן חדש
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

        // מחיקת מאמן
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

        // בחירת מאמן ספציפי
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

        // עדכון פרטי מאמן
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

        // קבלת כל המאמנים
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

        // חיפוש מאמן לפי שם פרטי
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

        // חיפוש מאמן לפי שם משפחה
        public DataTable SearchTrainerByLastName(string lastName)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainerByLastNameQuery);
                cmd.Parameters.AddWithValue("@lastName", "%" + lastName + "%");
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

        // קבלת מאמנים לפי רמת אימון
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

        // קבלת מאמנים לפי טווח תאריכים
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

        // קבלת ספירת מאמנים לפי רמה
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

        // קבלת מאמנים עם ניסיון של X שנים
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

        // קבלת מאמנים לפי רמה וניסיון
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

        // קבלת מאמנים לפי שנת התחלת עבודה
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

        // קבלת מאמנים לפי חודש התחלת עבודה
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

        // קבלת מאמנים לפי רמה ומספר שעות אימון
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

        // קבלת מאמנים לפי רמה ושעות בחודש מסוים
        public DataTable GetTrainersByLevelAndHoursInMonth(int level, int month, int year, int minHours)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainersByLevelAndHoursInMonthQuery);
                cmd.Parameters.AddWithValue("@trainingLevel", level);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
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

        // קבלת מאמנים לפי רמה ושעות בשנה מסוימת
        public DataTable GetTrainersByLevelAndHoursInYear(int level, int year, int minHours)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainersByLevelAndHoursInYearQuery);
                cmd.Parameters.AddWithValue("@trainingLevel", level);
                cmd.Parameters.AddWithValue("@year", year);
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

        // קבלת מאמנים לפי רמה ושעות בטווח תאריכים
        public DataTable GetTrainersByLevelAndHoursInDateRange(int level, DateTime startDate, DateTime endDate, int minHours)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainersByLevelAndHoursInDateRangeQuery);
                cmd.Parameters.AddWithValue("@trainingLevel", level);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
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

        // קבלת מאמנים לפי רמה ושעות בשבוע מסוים
        public DataTable GetTrainersByLevelAndHoursInWeek(int level, int week, int year, int minHours)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainersByLevelAndHoursInWeekQuery);
                cmd.Parameters.AddWithValue("@trainingLevel", level);
                cmd.Parameters.AddWithValue("@week", week);
                cmd.Parameters.AddWithValue("@year", year);
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

        // קבלת מאמנים לפי רמה ושעות ביום מסוים
        public DataTable GetTrainersByLevelAndHoursInDay(int level, DateTime date, int minHours)
        {
            try
            {
                MyConn.OpenConnection();
                OleDbCommand cmd = MyConn.Command(TrainerQueries.GetTrainersByLevelAndHoursInDayQuery);
                cmd.Parameters.AddWithValue("@trainingLevel", level);
                cmd.Parameters.AddWithValue("@date", date);
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