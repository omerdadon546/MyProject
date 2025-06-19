using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code
{
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

        public string WorkoutDay { get => workoutDay; set => workoutDay = value; }
        public string TrainingType { get => trainingType; set => trainingType = value; }
        public int TrainingLevel1 { get => TrainingLevel; set => TrainingLevel = value; }
        public string TrainingHouer1 { get => TrainingHouer; set => TrainingHouer = value; }
        public string TrainerID { get => trainerID; set => trainerID = value; }
    }
}