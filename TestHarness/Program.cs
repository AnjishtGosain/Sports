using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExtractionAndProcessing;
using DataExtractionAndProcessing.DataStructures;
using Common.Enumerations;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            // Params
            var cricinfoWebAddress = "http://www.espncricinfo.com";
            var iplScoresSuffix = "/scores/series/8048/season/2019/ipl";
            var cachePath = "C:\\Users\\anjis\\cache\\IPLFantasyCalculator";

            var name = PlayerNameExtensions.ConvertTo("v koHli");


            var nodes = DataExtractor.GetIplScorecards(cricinfoWebAddress, iplScoresSuffix, cachePath);
            var innings = new Dictionary<int, Dictionary<PlayerName, BatsmanInning>>();
            var game = 1;
            foreach(var scorecardAddress in nodes)
            {
                var temp = DataExtractor.GetScores(scorecardAddress, cachePath);
                innings.Add(game, temp);
                game++;
            }
            var blah = 0.0;
        }
    }
}
