using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExtractionAndProcessing.Enumerations;
using Common.Enumerations;

namespace DataExtractionAndProcessing.DataStructures
{
    public class BatsmanInning
    {
        public PlayerName PlayerName { get; set; }
        public int GameNumber { get; set; }
        public string Dismissal { get; set; }
        public string DismissalCommentary { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public int Fours { get; set; }
        public int Sixes { get; set; }
        public double StrikeRate { get; set; }

        public BatsmanInning()
        {
            PlayerName = PlayerName.None;
        }

        public BatsmanInning(PlayerName playerName, int gameNumber, 
            string dismissal, string dismissalCommentary, int runsScored, 
            int ballsFaced, int fours, int sixes, double strikeRate)
        {
            PlayerName = playerName;
            GameNumber = gameNumber;
            Dismissal = dismissal;
            DismissalCommentary = dismissalCommentary;
            RunsScored = runsScored;
            BallsFaced = ballsFaced;
            Fours = fours;
            Sixes = sixes;
            StrikeRate = strikeRate;
        }

        public BatsmanInning(string playerName, int gameNumber, 
            string dismissal = "", string dismissalCommentary = "", string runsScored = "", 
            string ballsFaced = "", string fours = "", string sixes = "", string strikeRate = "")
        {
            PlayerName = PlayerNameExtensions.ConvertTo(playerName);
            GameNumber = gameNumber;

            Dismissal = dismissal;
            DismissalCommentary = dismissalCommentary;

            RunsScored = runsScored == "" ? 0 : Convert.ToInt32(runsScored);
            BallsFaced = ballsFaced == "" ? 0 : Convert.ToInt32(ballsFaced);
            Fours = fours == "" ? 0 : Convert.ToInt32(fours);
            Sixes = sixes == "" ? 0 : Convert.ToInt32(sixes);
            StrikeRate = (strikeRate == "" || strikeRate == "-") ? 0 : Convert.ToDouble(strikeRate);
        }
    }
}
