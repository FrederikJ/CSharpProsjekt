using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempNavn.Klasser
{
    public static class Bruker
    {
        public static int BrukerID { get; set; }
        public static string Navn { get; set; }
        public static int TopScore { get; set; }
        public static string Epost { get; set; }

        public static void Bruker(int brukerID, string navn,string epost)
        {
            BrukerID = brukerID;
            Navn = navn;
            Epost = epost;
        }
        public static void Bruker(int topScore)
        {
            TopScore = topScore;
        }
    }
}
