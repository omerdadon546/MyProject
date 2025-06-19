using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using omerWCF.App_Code;

namespace omerWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public int AddGame(GamesClass game)
        {
            return game.AddGame();
        }

        public GamesClass[] PrintGamesList()
        {
            return GamesClass.PrintGamesList();
        }
        public PlayrsClass[] PrintPlayersList()
        {
            return PlayrsClass.PrintPlayersList();
        }
        public int AddTrainer(TrainersClass trainer)
        {
            return trainer.AddTrainer();
        }
        public int DeleteTrainer(TrainersClass trainer)
        {
            return trainer.DeleteTrainer();
        }
        public TrainersClass SelectTrainer(TrainersClass trainer)
        {
            trainer.SelectTrainer();
            return trainer;
        }
        public int UpdateTrainer(TrainersClass trainer)
        {
            return trainer.UpdateTrainer();
        }
        public TrainersClass[] PrintTrainersLinst()
        {
            return TrainersClass.PrintTrainersList();
        }
        public int AddTraining(TrainingClass train)
        {
            return train.AddTraining();
        }
        public int DeleteTraining(TrainingClass train)
        {
            return train.DeleteTraining();
        }
        public TrainingClass SelectTraining(TrainingClass train)
        {
            train.SelectTraining();
            return train;
        }
        public TrainingClass[] PrintTraningList()
        {
            return TrainingClass.PrintTrainingList();
        }
        public int AddLeague(LeaguesClass league)
        {
            return league.Addleagues();
        }
        public int DeleteLeague(LeaguesClass league)
        {
            return league.DeleteLeague();
        }
        public LeaguesClass SelectLeague(LeaguesClass league)
        {
            league.SelectLeague();
            return league;
        }
        public int UpdateLeague(LeaguesClass league)
        {
            return league.UpdateLeague();
        }
        public LeaguesClass[] PrintLeaguesList()
        {
            return LeaguesClass.PrintLeaguesList();
        }
        public int AddPlayer(PlayrsClass player)
        {
            return player.Addplayer();
        }
        public int DeletePlayer(PlayrsClass player)
        {
            return player.DeletePlayer();
        }
        public PlayrsClass Select(PlayrsClass player)
        {
            player.Select();
            return player;
        }
        public int UpdatePlayer(PlayrsClass player)
        {
            return player.UpdatePlayer();
        }
        public int DeleteGame(GamesClass game)
        {
            return game.DeleteGame();
        }
        public GamesClass SelectGame(GamesClass game)
        {
            game.SelectGame();
            return game;
        }
        public int UpdateGame(GamesClass game)
        {
            return game.UpdateGame();
        }
        public int UpdateTraining(TrainingClass train)
        {
            return train.UpdateTraining();
        }
        public int signUp(LoginClass user)
        {
            return user.signUp();
        }
        public string login(LoginClass user)
        {
            return user.login();
        }
        public TrainersClass[] GetTrainersSalaryBySeniority()
        {
            return TrainersClass.GetTrainersSalaryBySeniority();
        }
        public List<LeaguesClass> GetLeaguesChartData()
        {
            return LeaguesClass.GetLeaguesChartData();
        }
        public PlayrsClass[] GetWeakPlayers()
        {
            return PlayrsClass.GetWeakPlayers();
        }
        public int GetWinCount()
        {
            return GamesClass.CountWins();
        }

        public int GetLossCount()
        {
            return GamesClass.CountLosses();
        }


    }
}
 