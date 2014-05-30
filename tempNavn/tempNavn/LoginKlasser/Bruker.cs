using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProsjekt.LoginKlasser
{
    /// <summary>
    /// Bruker.cs av Frederik Johnsen
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Brukker oppgjekt klasse. Her lagre vi all informasjon fra database ved innlogginen
    /// lokalt på programmet, slik at det er lett tilgjengelig i koden
    /// </summary>
    public class Bruker
    {
        //Get/Set metoder for de forskjellige medlemsvariablene.
        public static int BrukerID { get; set; }
        public static string Navn { get; set; }
        public static int TopScore { get; set; }
        public static int Level { get; set; }
 
        /// <summary>
        /// Kan ikke lage konstruktør av static metoden. Så laga static metoden så den er lett tigjengelig
        /// i koden. Slipper å opprette et objekt, forså å legge til det forskjellige informasjon som
        /// skal inn hit.
        /// </summary>
        /// <param name="brukerID"></param>
        /// <param name="navn"></param>
        /// <param name="topScore"></param>
        /// <param name="level"></param>
        public static void AddBruker(int brukerID, string navn)
        {
            BrukerID = brukerID;
            Navn = navn;
        }
        public static void AddTopScoreLevelToBruker(int topScore, int level)
        {
            TopScore = topScore;
            Level = level;
        }
    }
}
