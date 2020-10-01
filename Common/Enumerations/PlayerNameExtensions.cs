using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enumerations
{
    public static class PlayerNameExtensions
    {
        public static PlayerName ConvertTo(string playerNameString)
        {
            var adjustedString = playerNameString.Replace("(c)", "");
            adjustedString = adjustedString.Replace("&dagger;", "");
            adjustedString = adjustedString.Replace(" ", "").ToLower();
            if(!Enum.TryParse(adjustedString, true, out PlayerName playerName))
            {
                throw new Exception("Unknown player name.");
            }
            return playerName;
        }

        public static string ConvertTo(PlayerName playerName)
        {
            switch (playerName)
            {
                case PlayerName.ABdeVilliers:
                    return "AB de Villiers";
                case PlayerName.AbhishekSharma:
                    return "Abhishek Sharma";
                case PlayerName.ADNath:
                    return "AD Nath";
                case PlayerName.ArshdeepSingh:
                    return "Arshdeep Singh";
                case PlayerName.AveshKhan:
                    return "Avesh Khan";
                case PlayerName.BCJCutting:
                    return "BCJ Cutting";
                case PlayerName.CdeGrandhomme:
                    return "C de Grandhomme";
                case PlayerName.CAIngram:
                    return "CA Ingram";
                case PlayerName.CHGayle:
                    return "CH Gayle";
                case PlayerName.CRBrathwaite:
                    return "CR Brathwaite";
                case PlayerName.DJBravo:
                    return "DJ Bravo";
                case PlayerName.DJHooda:
                    return "DJ Hooda";
                case PlayerName.DLChahar:
                    return "DL Chahar";
                case PlayerName.FduPlessis:
                    return "F du Plessis";
                case PlayerName.HarbhajanSingh:
                    return "Harbhajan Singh";
                case PlayerName.HarpreetBrar:
                    return "Harpreet Brar";
                case PlayerName.HFGurney:
                    return "HF Gurney";
                case PlayerName.ImranTahir:
                    return "Imran Tahir";
                case PlayerName.IshanKishan:
                    return "Ishan Kishan";
                case PlayerName.JCArcher:
                    return "JC Archer";
                case PlayerName.JCButtler:
                    return "JC Buttler";
                case PlayerName.JJBumrah:
                    return "JJ Bumrah";
                case PlayerName.JLDenly:
                    return "JL Denly";
                case PlayerName.JMBairstow:
                    return "JM Bairstow";
                case PlayerName.JPBehrendorff:
                    return "JP Behrendorff";
                case PlayerName.KGowtham:
                    return "K Gowtham";
                case PlayerName.KCCariappa:
                    return "KC Cariappa";
                case PlayerName.KKAhmed:
                    return "KK Ahmed";
                case PlayerName.LHFerguson:
                    return "LH Ferguson";
                case PlayerName.MAshwin:
                    return "M Ashwin";
                case PlayerName.MAAgarwal:
                    return "MA Agarwal";
                case PlayerName.MMAli:
                    return "MM Ali";
                case PlayerName.MSDhoni:
                    return "MS Dhoni";
                case PlayerName.PChopra:
                    return "P Chopra";
                case PlayerName.PPChawla:
                    return "PP Chawla";
                case PlayerName.QdeKock:
                    return "Q de Kock";
                case PlayerName.RAshwin:
                    return "R Ashwin";
                case PlayerName.RDChahar:
                    return "RD Chahar";
                case PlayerName.RKBhui:
                    return "RK Bhui";
                case PlayerName.SDhawan:
                    return "S Dhawan";
                case PlayerName.SDube:
                    return "S Dube";
                case PlayerName.SGopal:
                    return "S Gopal";
                case PlayerName.SMCurran:
                    return "SM Curran";
                case PlayerName.SOHetmyer:
                    return "SO Hetmyer";
                case PlayerName.SSIyer:
                    return "SS Iyer";
                case PlayerName.STRBinny:
                    return "STR Binny";
                case PlayerName.SWBillings:
                    return "SW Billings";
                case PlayerName.TABoult:
                    return "TA Boult";
                case PlayerName.VRAaron:
                    return "VR Aaron";
                case PlayerName.YSChahal:
                    return "YS Chahal";
                case PlayerName.RAJadeja:
                    return "RA Jadeja";
                case PlayerName.KMJadhav:
                    return "KM Jadhav";
                case PlayerName.ASJoseph:
                    return "AS Joseph";
                case PlayerName.KDKarthik:
                    return "KD Karthik";
                case PlayerName.SKaul:
                    return "S Kaul";
                case PlayerName.SNKhan:
                    return "SN Khan";
                case PlayerName.HKlaasen:
                    return "H Klaasen";
                case PlayerName.VKohli:
                    return "V Kohli";
                case PlayerName.SCKuggeleijn:
                    return "SC Kuggeleijn";
                case PlayerName.KuldeepYadav:
                    return "Kuldeep Yadav";
                case PlayerName.DSKulkarni:
                    return "DS Kulkarni";
                case PlayerName.BKumar:
                    return "B Kumar";
                case PlayerName.SDLad:
                    return "SD Lad";
                case PlayerName.SLamichhane:
                    return "S Lamichhane";
                case PlayerName.ELewis:
                    return "E Lewis";
                case PlayerName.LSLivingstone:
                    return "LS Livingstone";
                case PlayerName.CALynn:
                    return "CA Lynn";
                case PlayerName.MJMcClenaghan:
                    return "MJ McClenaghan";
                case PlayerName.SLMalinga:
                    return "SL Malinga";
                case PlayerName.MandeepSingh:
                    return "Mandeep Singh";
                case PlayerName.MMarkande:
                    return "M Markande";
                case PlayerName.SMidhun:
                    return "S Midhun";
                case PlayerName.DAMiller:
                    return "DA Miller";
                case PlayerName.AMishra:
                    return "A Mishra";
                case PlayerName.MohammadNabi:
                    return "Mohammad Nabi";
                case PlayerName.MohammedShami:
                    return "Mohammed Shami";
                case PlayerName.MohammedSiraj:
                    return "Mohammed Siraj";
                case PlayerName.CHMorris:
                    return "CH Morris";
                case PlayerName.MujeebUrRahman:
                    return "Mujeeb Ur Rahman";
                case PlayerName.CMunro:
                    return "C Munro";
                case PlayerName.SNadeem:
                    return "S Nadeem";
                case PlayerName.NSNaik:
                    return "NS Naik";
                case PlayerName.KKNair:
                    return "KK Nair";
                case PlayerName.SPNarine:
                    return "SP Narine";
                case PlayerName.PNegi:
                    return "P Negi";
                case PlayerName.MKPandey:
                    return "MK Pandey";
                case PlayerName.HHPandya:
                    return "HH Pandya";
                case PlayerName.KHPandya:
                    return "KH Pandya";
                case PlayerName.RRPant:
                    return "RR Pant";
                case PlayerName.RParag:
                    return "R Parag";
                case PlayerName.ARPatel:
                    return "AR Patel";
                case PlayerName.HVPatel:
                    return "HV Patel";
                case PlayerName.PAPatel:
                    return "PA Patel";
                case PlayerName.YKPathan:
                    return "YK Pathan";
                case PlayerName.KMAPaul:
                    return "KMA Paul";
                case PlayerName.KAPollard:
                    return "KA Pollard";
                case PlayerName.NPooran:
                    return "N Pooran";
                case PlayerName.MPrasidhKrishna:
                    return "M Prasidh Krishna";
                case PlayerName.YPrithviRaj:
                    return "Y Prithvi Raj";
                case PlayerName.KRabada:
                    return "K Rabada";
                case PlayerName.AMRahane:
                    return "AM Rahane";
                case PlayerName.KLRahul:
                    return "KL Rahul";
                case PlayerName.SKRaina:
                    return "SK Raina";
                case PlayerName.ASRajpoot:
                    return "AS Rajpoot";
                case PlayerName.NRana:
                    return "N Rana";
                case PlayerName.RashidKhan:
                    return "Rashid Khan";
                case PlayerName.RasikhSalam:
                    return "Rasikh Salam";
                case PlayerName.ATRayudu:
                    return "AT Rayudu";
                case PlayerName.PRayBarman:
                    return "P Ray Barman";
                case PlayerName.ASRoy:
                    return "AS Roy";
                case PlayerName.ADRussell:
                    return "AD Russell";
                case PlayerName.SERutherford:
                    return "SE Rutherford";
                case PlayerName.NASaini:
                    return "NA Saini";
                case PlayerName.SVSamson:
                    return "SV Samson";
                case PlayerName.SandeepSharma:
                    return "Sandeep Sharma";
                case PlayerName.MJSantner:
                    return "MJ Santner";
                case PlayerName.VShankar:
                    return "V Shankar";
                case PlayerName.ShakibAlHasan:
                    return "Shakib Al Hasan";
                case PlayerName.ISharma:
                    return "I Sharma";
                case PlayerName.KVSharma:
                    return "KV Sharma";
                case PlayerName.MMSharma:
                    return "MM Sharma";
                case PlayerName.RGSharma:
                    return "RG Sharma";
                case PlayerName.PPShaw:
                    return "PP Shaw";
                case PlayerName.DRShorey:
                    return "DR Shorey";
                case PlayerName.ShubmanGill:
                    return "Shubman Gill";
                case PlayerName.RKSingh:
                    return "RK Singh";
                case PlayerName.SPDSmith:
                    return "SPD Smith";
                case PlayerName.ISSodhi:
                    return "IS Sodhi";
                case PlayerName.TGSouthee:
                    return "TG Southee";
                case PlayerName.DWSteyn:
                    return "DW Steyn";
                case PlayerName.MPStoinis:
                    return "MP Stoinis";
                case PlayerName.BAStokes:
                    return "BA Stokes";
                case PlayerName.RTewatia:
                    return "R Tewatia";
                case PlayerName.SNThakur:
                    return "SN Thakur";
                case PlayerName.OThomas:
                    return "O Thomas";
                case PlayerName.RATripathi:
                    return "RA Tripathi";
                case PlayerName.AJTurner:
                    return "AJ Turner";
                case PlayerName.AJTye:
                    return "AJ Tye";
                case PlayerName.JDUnadkat:
                    return "JD Unadkat";
                case PlayerName.RVUthappa:
                    return "RV Uthappa";
                case PlayerName.CVVarun:
                    return "CV Varun";
                case PlayerName.GHVihari:
                    return "GH Vihari";
                case PlayerName.MVijay:
                    return "M Vijay";
                case PlayerName.GCViljoen:
                    return "GC Viljoen";
                case PlayerName.DAWarner:
                    return "DA Warner";
                case PlayerName.WashingtonSundar:
                    return "Washington Sundar";
                case PlayerName.SRWatson:
                    return "SR Watson";
                case PlayerName.KSWilliamson:
                    return "KS Williamson";
                case PlayerName.JYadav:
                    return "J Yadav";
                case PlayerName.SAYadav:
                    return "SA Yadav";
                case PlayerName.UTYadav:
                    return "UT Yadav";
                case PlayerName.YuvrajSingh:
                    return "Yuvraj Singh";
                default:
                    return "None";
            }
        }
    }
}
