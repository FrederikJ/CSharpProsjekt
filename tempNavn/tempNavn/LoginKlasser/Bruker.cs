﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProsjekt.LoginKlasser
{
    public class Bruker
    {
        public static int BrukerID { get; set; }
        public static string Navn { get; set; }
        public static int TopScore { get; set; }
        public static int Level { get; set; }
        public static string Epost { get; set; }

        public static void AddBruker(int brukerID, string navn, int topScore, int level, string epost)
        {
            BrukerID = brukerID;
            Navn = navn;
            TopScore = topScore;
            Level = level;
            Epost = epost;
        }
        public static void AddTopScoreLevelToBruker(int topScore, int level)
        {
            TopScore = topScore;
            Level = level;
        }
    }
}
