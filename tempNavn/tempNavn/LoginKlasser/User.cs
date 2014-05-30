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
    public class User
    {
        //Get/Set metoder for de forskjellige medlemsvariablene.
        public static int UserID { get; set; }
        public static string Name { get; set; }
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
        public static void AddUser(int brukerID, string navn)
        {
            UserID = brukerID;
            Name = navn;
        }
        public static void AddTopScoreLevelToUser(int topScore, int level)
        {
            TopScore = topScore;
            Level = level;
        }
    }
}
