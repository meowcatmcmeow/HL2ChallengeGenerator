using System;
using MeowcatXLib;

/// <summary>
/// The HL2 Challenge Generator: Challenge Component Index
/// Written by Meowcat McMeow XVIII, with contributions from many others.
/// "Engineer let me take a look inside the red briefcase. I need some bleach, please."
/// 
/// This content is proudly made available under the GNU General Public License, version 3
/// </summary>

namespace HL2ChallengeIndex
{
    public static class Challenges
    {
        // The format is { TitleString, TypeString, DescriptionString }
        // Remember to change the RNG limits in Program.cs when adding components, lest the generator never use them!
        public static readonly string[,] Primary = new string[3, 3]
        {
            { "Ph. D. in Theoretical Physics", "Handicap", "You may NEVER use hitscan bullets! You may only deal damage by means of explosion,\nthrowing physics objects, the crowbar, or vehicle collisions. Pulse-weaponry excluded." },
            { "Agh, my legs...", "Handicap", "Your legs are injured beyond what the HEV suit can automatically heal.\nYou are NOT alowed to run." },
            { "Afraid of The Dark", "Handicap", "If you're in a dark area and your flashlight is off, you CAN NOT\nmove, even to shoot at incoming hostiles." },
        };

        public static readonly string[,] Secondary = new string[3, 3]
        { 
            { "Bad Charging Circuit", "Handicap", "You may NEVER allow your HEV suit to be charged past 15%" },
            { "Weapon Malfunction", "Handicap", "Your weapons were damaged and are incapable of using secondary fire options." },
            { "Hazardous Materials", "Handicap", "You are not allowed to move explosive barrels.\n Optional extra challenge: you fail if you take any explosive damage, ever." }
        };

        public static readonly string[,] Auxilary = new string[3, 3] 
        {
            { "The Enraged Geek has come to seek vengance!", "Level 2 Failure Consequence", "Upon death, your weapons are restricted to just your crowbar for 1 hour.\nMay be bypassed by reverting to last quick save." },
            { "Golden Wind", "Level 3 Failure Consequence", "If you die, you have to restart the chapter. Quick-save won't help you this time.\nThere's no escaping the fate you sealed yourself to." },
            { "Arm Injuries", "Level 1 Failure Consequence", "Upon death, your left arm was broken during respawn and will take 1 hour to heal.\nUntil then, you may NOT use 2-handed equipment. May be bypassed by reverting to last quick save." }
        };

        public static int MainPart;
        public static int SecondPart;
        public static int AuxPart;

        /// <summary>
        /// Randomly creates a 3-part challenge and shows it to the user, with an option to generate another or exit the program.
        /// </summary>
        public static void ChallengeMe()
        {
            // Ideally, once the index is more full, the range of the RNG would be increased to add diversity.
            Random RNG = new Random();
            MainPart = RNG.Next(0, 3);
            SecondPart = RNG.Next(0, 3);
            AuxPart = RNG.Next(0, 3);

            Text.WriteHeaderToConsole(0x00, "Challenge ID: " + MainPart + SecondPart + AuxPart);
            Text.WriteHeaderToConsole(0x00, "Primary Component");
            Console.WriteLine("Name: " + Primary[MainPart, 0]);
            Console.WriteLine("Type: " + Primary[MainPart, 1]);
            Console.WriteLine(Primary[MainPart, 2] + "\n");

            Text.WriteHeaderToConsole(0x00, "Secondary Component");
            Console.WriteLine("Name: " + Secondary[SecondPart, 0]);
            Console.WriteLine("Type: " + Secondary[SecondPart, 1]);
            Console.WriteLine(Secondary[SecondPart, 2] + "\n");

            Text.WriteHeaderToConsole(0x00, "Auxilary Component");
            Console.WriteLine("Name: " + Auxilary[AuxPart, 0]);
            Console.WriteLine("Type: " + Auxilary[AuxPart, 1]);
            Console.WriteLine(Auxilary[AuxPart, 2] + "\n");
        }

        /// <summary>
        /// Writes the presented challenge to a text file in the executable's directory.
        /// </summary>
        public static void TicketWriter()
        {
            string[] Output = new string[]
            { 
                "Meow's Half-Life 2 Challenge Generator - Challenge Ticket",
                "Challenge ID: " + MainPart + SecondPart + AuxPart,
                "",
                "==== Primary Component ====",
                "Name: " + Primary[MainPart, 0],
                "Type: " + Primary[MainPart, 1],
                Primary[MainPart, 2],
                "",
                "==== Secondary Component ====",
                "Name: " + Secondary[SecondPart, 0],
                "Type: " + Secondary[SecondPart, 1],
                Secondary[SecondPart, 2],
                "",
                "==== Aux. Component ====",
                "Name: " + Auxilary[AuxPart, 0],
                "Type: " + Auxilary[AuxPart, 1],
                Auxilary[AuxPart, 2]
            };
            IO.WriteTextFile(Output, null);
            return;
        }
    }
}