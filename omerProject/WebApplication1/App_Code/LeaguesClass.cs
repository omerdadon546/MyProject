using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code
{
    public class LeaguesClass
    {
        private string leagueName;
        private string BastPlayerAtTheLeague;
        private int PTSatLeague;
        private string CoachName;
        private int LeagueLevel;
        private string yearOfLeague;

        public LeaguesClass(string leagueName, string bastPlayerAtTheLeague, int pTSatLeague, string coachName, int leagueLevel, string yearOfLeague)
        {
            this.leagueName = leagueName;
            BastPlayerAtTheLeague = bastPlayerAtTheLeague;
            PTSatLeague = pTSatLeague;
            CoachName = coachName;
            LeagueLevel = leagueLevel;
            this.yearOfLeague = yearOfLeague;
        }

        public string LeagueName { get => leagueName; set => leagueName = value; }
        public string BastPlayerAtTheLeague1 { get => BastPlayerAtTheLeague; set => BastPlayerAtTheLeague = value; }
        public int PTSatLeague1 { get => PTSatLeague; set => PTSatLeague = value; }
        public string CoachName1 { get => CoachName; set => CoachName = value; }
        public int LeagueLevel1 { get => LeagueLevel; set => LeagueLevel = value; }
        public string YearOfLeague { get => yearOfLeague; set => yearOfLeague = value; }
    }
}