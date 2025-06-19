using System;
using System.Data;
using System.Data.OleDb;

namespace omerWCF.App_Code
{
    public static class TrainerQueries
    {
        // שאילתה להוספת מאמן חדש
        public static string InsertTrainerQuery = @"
            INSERT INTO Trainers (trainerID, firstName, lastName, trainingLevel, startWorking)
            VALUES (@trainerID, @firstName, @lastName, @trainingLevel, @startWorking)";

        // שאילתה למחיקת מאמן
        public static string DeleteTrainerQuery = @"
            DELETE FROM trainers 
            WHERE trainerID = @trainerID";

        // שאילתה לבחירת מאמן ספציפי
        public static string SelectTrainerQuery = @"
            SELECT * FROM trainers 
            WHERE trainerID = @trainerID";

        // שאילתה לעדכון פרטי מאמן
        public static string UpdateTrainerQuery = @"
            UPDATE trainers 
            SET firstName = @firstName, 
                lastName = @lastName, 
                trainingLevel = @trainingLevel, 
                startWorking = @startWorking 
            WHERE trainerID = @trainerID";

        // שאילתה לקבלת כל המאמנים עם פרטי human_source
        public static string GetAllTrainersQuery = @"
            SELECT * FROM trainers 
            INNER JOIN human_source 
            ON Trainers.trainerID = human_source.key";

        // שאילתה לחיפוש מאמן לפי שם פרטי
        public static string GetTrainerByFirstNameQuery = @"
            SELECT * FROM trainers 
            WHERE firstName LIKE @firstName";

        // שאילתה לחיפוש מאמן לפי שם משפחה
        public static string GetTrainerByLastNameQuery = @"
            SELECT * FROM trainers 
            WHERE lastName LIKE @lastName";

        // שאילתה לקבלת מאמנים לפי רמת אימון
        public static string GetTrainersByLevelQuery = @"
            SELECT * FROM trainers 
            WHERE trainingLevel = @trainingLevel";

        // שאילתה לקבלת מאמנים לפי טווח תאריכים
        public static string GetTrainersByDateRangeQuery = @"
            SELECT * FROM trainers 
            WHERE startWorking BETWEEN @startDate AND @endDate";

        // שאילתה לספירת מאמנים לפי רמה
        public static string GetTrainerCountByLevelQuery = @"
            SELECT trainingLevel, COUNT(*) as Count 
            FROM trainers 
            GROUP BY trainingLevel";

        // שאילתה לקבלת מאמנים עם ניסיון של X שנים
        public static string GetExperiencedTrainersQuery = @"
            SELECT * FROM trainers 
            WHERE DATEDIFF('yyyy', startWorking, NOW()) >= @yearsOfExperience";

        // שאילתה לקבלת מאמנים לפי רמת אימון ומספר שנות ניסיון
        public static string GetTrainersByLevelAndExperienceQuery = @"
            SELECT * FROM trainers 
            WHERE trainingLevel = @trainingLevel 
            AND DATEDIFF('yyyy', startWorking, NOW()) >= @yearsOfExperience";

        // שאילתה לקבלת מאמנים שעבדו בשנה מסוימת
        public static string GetTrainersByYearQuery = @"
            SELECT * FROM trainers 
            WHERE YEAR(startWorking) = @year";

        // שאילתה לקבלת מאמנים לפי חודש התחלת העבודה
        public static string GetTrainersByMonthQuery = @"
            SELECT * FROM trainers 
            WHERE MONTH(startWorking) = @month";

        // שאילתה לקבלת מאמנים לפי רמה ומספר שעות אימון
        public static string GetTrainersByLevelAndHoursQuery = @"
            SELECT t.*, COUNT(th.trainingID) as TotalHours
            FROM trainers t
            LEFT JOIN training_hours th ON t.trainerID = th.trainerID
            WHERE t.trainingLevel = @trainingLevel
            GROUP BY t.trainerID
            HAVING COUNT(th.trainingID) >= @minHours";

        // שאילתה לקבלת מאמנים לפי רמה ושעות אימון בחודש מסוים
        public static string GetTrainersByLevelAndHoursInMonthQuery = @"
            SELECT t.*, COUNT(th.trainingID) as TotalHours
            FROM trainers t
            LEFT JOIN training_hours th ON t.trainerID = th.trainerID
            WHERE t.trainingLevel = @trainingLevel
            AND MONTH(th.trainingDate) = @month
            AND YEAR(th.trainingDate) = @year
            GROUP BY t.trainerID
            HAVING COUNT(th.trainingID) >= @minHours";

        // שאילתה לקבלת מאמנים לפי רמה ושעות אימון בשנה מסוימת
        public static string GetTrainersByLevelAndHoursInYearQuery = @"
            SELECT t.*, COUNT(th.trainingID) as TotalHours
            FROM trainers t
            LEFT JOIN training_hours th ON t.trainerID = th.trainerID
            WHERE t.trainingLevel = @trainingLevel
            AND YEAR(th.trainingDate) = @year
            GROUP BY t.trainerID
            HAVING COUNT(th.trainingID) >= @minHours";

        // שאילתה לקבלת מאמנים לפי רמה ושעות אימון בטווח תאריכים
        public static string GetTrainersByLevelAndHoursInDateRangeQuery = @"
            SELECT t.*, COUNT(th.trainingID) as TotalHours
            FROM trainers t
            LEFT JOIN training_hours th ON t.trainerID = th.trainerID
            WHERE t.trainingLevel = @trainingLevel
            AND th.trainingDate BETWEEN @startDate AND @endDate
            GROUP BY t.trainerID
            HAVING COUNT(th.trainingID) >= @minHours";

        // שאילתה לקבלת מאמנים לפי רמה ושעות אימון בשבוע מסוים
        public static string GetTrainersByLevelAndHoursInWeekQuery = @"
            SELECT t.*, COUNT(th.trainingID) as TotalHours
            FROM trainers t
            LEFT JOIN training_hours th ON t.trainerID = th.trainerID
            WHERE t.trainingLevel = @trainingLevel
            AND DATEPART(week, th.trainingDate) = @week
            AND YEAR(th.trainingDate) = @year
            GROUP BY t.trainerID
            HAVING COUNT(th.trainingID) >= @minHours";

        // שאילתה לקבלת מאמנים לפי רמה ושעות אימון ביום מסוים
        public static string GetTrainersByLevelAndHoursInDayQuery = @"
            SELECT t.*, COUNT(th.trainingID) as TotalHours
            FROM trainers t
            LEFT JOIN training_hours th ON t.trainerID = th.trainerID
            WHERE t.trainingLevel = @trainingLevel
            AND th.trainingDate = @date
            GROUP BY t.trainerID
            HAVING COUNT(th.trainingID) >= @minHours";
    }
} 