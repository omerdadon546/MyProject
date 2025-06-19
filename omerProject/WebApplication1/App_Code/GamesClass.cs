using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code
{
    public class GamesClass
    {
        private int gameNUmver;
        private int shootNumber;
        private string pointsInTheGame;
        private string playersPlayed;
        private bool Victory;
        private int game_level;

        public GamesClass(int gameNUmver, int shootNumber, string pointsInTheGame, string playersPlayed, bool victory, int game_level)
        {
            this.gameNUmver = gameNUmver;
            this.shootNumber = shootNumber;
            this.pointsInTheGame = pointsInTheGame;
            this.playersPlayed = playersPlayed;
            Victory = victory;
            this.game_level = game_level;
        }

        public int GameNUmver { get => gameNUmver; set => gameNUmver = value; }
        public int ShootNumber { get => shootNumber; set => shootNumber = value; }
        public string PointsInTheGame { get => pointsInTheGame; set => pointsInTheGame = value; }
        public string PlayersPlayed { get => playersPlayed; set => playersPlayed = value; }
        public bool Victory1 { get => Victory; set => Victory = value; }
        public int Game_level { get => game_level; set => game_level = value; }
    }
}