using System;
using MeowcatXLib;
using HL2ChallengeIndex;

/// <summary>
/// The HL2 Challenge Generator
/// Written by Meowcat McMeow XVIII
/// "Pretty simple, really. It just asks RNG to come up with a few handicaps for HL2 players."
/// 
/// This content is proudly made available under the GNU General Public License, version 3
/// </summary>

namespace HL2ChallengeGenerator
{
    /// <summary>
    /// The main functions of the challenge generator.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // I have a habit of clearing the terminal window on startup, in case someone started the program from a command
            // prompt instead of double-clicking the exec file.
            Console.Clear();
            Text.WriteHeaderToConsole(0x00, "Meow's Half-Life 2 Challenge Generator - 1.0-beta");
            Console.WriteLine("Press [ENTER/RETURN] to randomly generate a challenge.");
            Console.WriteLine("Press any other key to terminate the program.");
            ConsoleKeyInfo MenuOption = Console.ReadKey();
            if (MenuOption.Key == ConsoleKey.Enter)
            {
                // I hope no one expects me to start up the generator...
                Console.Clear();
                Challenges.ChallengeMe();
            Start:;
                Console.WriteLine("Press [ENTER/RETURN] to randomly generate a challenge.");
                Console.WriteLine("Press [T] to save this challenge to a text file. (May require elevation.)");
                Console.WriteLine("Press any other key to terminate the program.");
                MenuOption = Console.ReadKey();
                if (MenuOption.Key == ConsoleKey.Enter)
                {
                    // I hope no one expects me to start up the generator...
                    Console.Clear();
                    Challenges.ChallengeMe();
                    goto Start;
                }
                else if (MenuOption.Key == ConsoleKey.T)
                {
                    // Wouldn't it be fantastic to get some pure readings for a change?
                    Console.Clear();
                    Challenges.TicketWriter();
                    goto Start;
                }
                else
                {
                    // Sorry, I'm leaving now.
                    Console.WriteLine("Have a very safe day.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Have a very safe day.");
                return;
            }
        }
    }
}