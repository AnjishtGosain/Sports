using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;
using DataExtractionAndProcessing.Enumerations;
using Common.Enumerations;
using DataExtractionAndProcessing.DataStructures;
using System.Text.RegularExpressions;

namespace DataExtractionAndProcessing
{
    public class DataExtractor
    {
        /// <summary>
        /// Helper utility which reads in a pre-cached HTML document. If not found, then hits the web address.
        /// </summary>
        /// <param name="cacheFileName"></param>
        /// <param name="htmlWebAddress"></param>
        /// <returns></returns>
        static HtmlDocument CacheHtmlFile(string cacheFileName, string htmlWebAddress)
        {
            var document = new HtmlDocument();
            if (File.Exists(cacheFileName))
            {
                document.Load(cacheFileName);
            }
            else
            {
                var web = new HtmlWeb();
                document = web.Load(htmlWebAddress);
                // Cache the data
                using (StreamWriter writer = new StreamWriter(cacheFileName))
                {
                    writer.Write(document.Text);
                }
            }
            return document;
        }

        /// <summary>
        /// Gets the http addresses for the IPl scorecards and caches the page for each daily run
        /// </summary>
        /// <param name="cricinfoWebAddress"></param> the homepage for Cricinfo
        /// <param name="iplScoresSuffix"></param> the suffix to the Cricinfo homepage for the IPL year of interest
        /// <param name="cachePath"></param> the local cache path
        /// <returns></returns> the http addresses for the scorecards as at the run date.
        public static IEnumerable<string> GetIplScorecards(string cricinfoWebAddress, string iplScoresSuffix,
            string cachePath)
        {
            // Identify the page for the IPL scores
            // ------------------------------------

            var iplScoresWebAddress = cricinfoWebAddress + iplScoresSuffix;
            var iplScoresPageCachePath = cachePath + "\\IPLScoresPage_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            Directory.CreateDirectory(cachePath);


            // Identify the hyperlink references corresponding to the Scorecards
            // -----------------------------------------------------------------

            //var nodes = document.DocumentNode.SelectNodes("//a").ToArray();
            //var nodes = document.DocumentNode.SelectNodes("//section[@id='pane-main']//a").ToArray();

            var document = CacheHtmlFile(iplScoresPageCachePath, iplScoresWebAddress);

            var nodes = document.DocumentNode.SelectNodes("//section[@id='pane-main']//a")
                .Where(x => x.OuterHtml.Contains("href")).ToArray()
                    .Where(y => y.OuterHtml.Contains("SCORECARD")).ToArray();

            var outNodes = nodes.Select(x => cricinfoWebAddress + x.Attributes["href"].Value);
            return outNodes;
        }

        /// <summary>
        /// Extracts the scores from a single game.
        /// </summary>
        /// <param name="args"></param>
        public static Dictionary<PlayerName, BatsmanInning> GetScores(string scorecardAddress, string cachePath)
        {
            // Extract the HTML from the scorecard address
            // -------------------------------------------

            var cacheFileName = cachePath + "\\" + scorecardAddress.Split('/').Last();
            var document = CacheHtmlFile(cacheFileName, scorecardAddress);

            // Extract the game info
            // ---------------------

            var gameInfoNodes = document.DocumentNode.SelectNodes("//div[@class='cscore_info-overview']").ToArray();
            var gameNumberString = gameInfoNodes.First().InnerText.Split(' ').First();
            var gameNumber = Convert.ToInt32(Regex.Replace(gameNumberString, "[^0-9.]", ""));

            // Extract the nodes with batting figures
            // --------------------------------------

            var battingInningsNodes = document.DocumentNode.SelectNodes("//div[@class='scorecard-section batsmen']")
                .Select(x => x.ChildNodes).ToArray();

            var battingDict = new Dictionary<int, Dictionary<NodeDataType, HtmlNode>>();
            var batsmanDict = new Dictionary<PlayerName, BatsmanInning>();
            foreach(var battingInningNode in battingInningsNodes) // Innings level
            {
                foreach(var battingNode in battingInningNode) // Batsman level
                {
                    var batsmanName = PlayerName.None;
                    var battingChildNodes = battingNode.ChildNodes;
                    foreach(var childNode in battingChildNodes)
                    {
                        if (childNode.OuterHtml.Contains("div class=\"wrap batsmen\"")) // node with batting runs etc.
                        {
                            var tempNodes = childNode.ChildNodes;
                            var batsmanNameString = tempNodes[0].InnerText;
                            var dismissal = tempNodes[1].InnerText;
                            var runs = "0";
                            var ballsFaced = "0";
                            var fours = "0";
                            var sixes = "0";
                            var strikeRate = "0.0";
                            if (dismissal != "absent hurt")
                            {
                                runs = tempNodes[2].InnerText;
                                ballsFaced = tempNodes[3].InnerText;
                                fours = tempNodes[4].InnerText;
                                sixes = tempNodes[5].InnerText;
                                strikeRate = tempNodes[6].InnerText;
                            }
                            var batsmanInning = new BatsmanInning(batsmanNameString, gameNumber, dismissal, "", 
                                runs, ballsFaced, fours, sixes, strikeRate);
                            batsmanName = batsmanInning.PlayerName;
                            batsmanDict.Add(batsmanInning.PlayerName, batsmanInning);
                        }
                        else if (childNode.OuterHtml.Contains("div class=\"content\"")) // node with dismissal commentary
                        {
                            batsmanDict[batsmanName].DismissalCommentary = childNode.InnerText;
                        }
                        else if (childNode.OuterHtml.Contains("div class=\"wrap dnb\"")) // node with did not bat information
                        {
                            if (childNode.InnerText.Contains("Did not bat")) // node with did not bat information
                            {
                                var tempNames = childNode.InnerText.Replace("Did not bat:", "");
                                var dnbNames = tempNames.Split(',');
                                foreach(var dnbName in dnbNames)
                                {
                                    var batsmanInning = new BatsmanInning(dnbName, gameNumber);
                                    batsmanDict.Add(batsmanInning.PlayerName, batsmanInning);
                                }
                            }
                        }
                    }
                }
            }

            return batsmanDict;
        }
    }
}
