using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code
{
    public class PlayrsClass
    {
        private int playerNumber;
        private string playerName;
        private string LastName;
        private string workoutDays;
        private int Level;
        private int FGM;
        private int GP;
        private int AST;
        private int STL;
        private int BLK;
        private int TO;
        private string PlayedINLeagues;
        private string trainerID;

        public PlayrsClass(int playerNumber, string playerName, string lastName, string workoutDays, int level, int fGM, int gP, int aST, int sTL, int bLK, int tO, string playedINLeagues, string trainerID)
        {
            this.playerNumber = playerNumber;
            this.playerName = playerName;
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

        public int PlayerNumber { get => playerNumber; set => playerNumber = value; }
        public string PlayerName { get => playerName; set => playerName = value; }
        public string LastName1 { get => LastName; set => LastName = value; }
        public string WorkoutDays { get => workoutDays; set => workoutDays = value; }
        public int Level1 { get => Level; set => Level = value; }
        public int FGM1 { get => FGM; set => FGM = value; }
        public int GP1 { get => GP; set => GP = value; }
        public int AST1 { get => AST; set => AST = value; }
        public int STL1 { get => STL; set => STL = value; }
        public int BLK1 { get => BLK; set => BLK = value; }
        public int TO1 { get => TO; set => TO = value; }
        public string PlayedINLeagues1 { get => PlayedINLeagues; set => PlayedINLeagues = value; }
        public string TrainerID { get => trainerID; set => trainerID = value; }
    }
}