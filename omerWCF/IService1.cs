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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int AddGame(GamesClass game);
        [OperationContract]
        GamesClass[] PrintGamesList();
        [OperationContract]
        PlayrsClass[] PrintPlayersList();
        [OperationContract]
        int AddTrainer(TrainersClass trainer);
        [OperationContract]
        int DeleteTrainer(TrainersClass trainer);
        [OperationContract]
        TrainersClass SelectTrainer(TrainersClass trainer);
        [OperationContract]
        int UpdateTrainer(TrainersClass trainer);
        [OperationContract]
        TrainersClass[] PrintTrainersLinst();
        [OperationContract]
        int AddTraining(TrainingClass train);
        [OperationContract]
        int DeleteTraining(TrainingClass train);
        [OperationContract]
        TrainingClass SelectTraining(TrainingClass trainer);
        [OperationContract]
        TrainingClass[] PrintTraningList();
        [OperationContract]
        int AddLeague(LeaguesClass league);
        [OperationContract]
        int DeleteLeague(LeaguesClass league);
        [OperationContract]
        LeaguesClass SelectLeague(LeaguesClass league);
        [OperationContract]
        LeaguesClass[] PrintLeaguesList();
        [OperationContract]
        int UpdateLeague(LeaguesClass league);
        [OperationContract]
        int AddPlayer(PlayrsClass player);
        [OperationContract]
        int DeletePlayer(PlayrsClass player);
        [OperationContract]
        int UpdatePlayer(PlayrsClass player);
        [OperationContract]
        PlayrsClass Select(PlayrsClass player);
        [OperationContract]
        int DeleteGame(GamesClass game);
        [OperationContract]
        int UpdateGame(GamesClass game);
        [OperationContract]
        GamesClass SelectGame(GamesClass game);
        [OperationContract]
        int UpdateTraining(TrainingClass train);
        [OperationContract]
        int signUp(LoginClass user);
        [OperationContract]
        string login(LoginClass user);
        [OperationContract]
        TrainersClass[] GetTrainersSalaryBySeniority();
        [OperationContract]
        List<LeaguesClass> GetLeaguesChartData();
        [OperationContract]
        PlayrsClass[] GetWeakPlayers();
        [OperationContract]
        int GetWinCount();

        [OperationContract]
        int GetLossCount();

    }
}
