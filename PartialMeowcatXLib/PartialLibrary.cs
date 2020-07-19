using System;
using System.Security.Principal;
using System.IO;

/// <summary>
/// A partial implementation of the MeowcatX Experimental Utilities Library
/// Modules included: MeowcatXLib.Text, MeowcatXLib.HMode, MeowcatXLib.IO
/// All components of the MeowcatX Experimental Utilities Library is available
/// under the GNU General Public License, version 3. As always. :)
/// </summary>
namespace MeowcatXLib
{
    /// <summary>
    /// Experimental console text stylization and manipulation functions.
    /// </summary>
    public static class Text
    {
        /// <summary>
        /// Writes a line of text using special color settings to make it stand out more. Note: This implementation is incomplete!
        /// </summary>
        /// <param name="Type">Hexadecimal header style ID</param>
        /// <param name="HeaderText">The text to write</param>
        public static void WriteHeaderToConsole(int Type, string HeaderText)
        {
            switch (Type)
            {
                // Default header: black on white
                default:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(HeaderText);
                    Console.ResetColor();
                    return;

                // White on blue
                case 0x00:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(HeaderText);
                    Console.ResetColor();
                    return;

                // Black on green
                case 0x01:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(HeaderText);
                    Console.ResetColor();
                    return;

                // White on red (A.K.A. The "Well Heck" header style)
                case 0x02:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(HeaderText);
                    Console.ResetColor();
                    return;
            }
        }
    }

    /// <summary>
    /// The Hazard Module prevents the program from executing certain functions unless the program is
    /// run with elevated privileges. This helps enhance the security of the system when writing
    /// or reading in sensitive directories such as the $PATH areas.
    /// </summary>
    public static class HMode
    {
        // I found this simple auth check in a Stack Exchange answer. Better solution will come with the
        // complete library.
        // https://stackoverflow.com/questions/1220213/detect-if-running-as-administrator-with-or-without-elevated-privileges
        public static bool IsElevated => WindowsIdentity.GetCurrent().Owner.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid);
    }

    /// <summary>
    /// The IO module allows the MeowcatX EUL to perform filesystem functions.
    /// Relies on the Hazard Module to prevent problematic accesses under normal conditions.
    /// </summary>
    public static class IO
    {
        private static string CWD;
        private static bool IsInitialized;

        /// <summary>
        /// Initializes the IO module by storing things like current working directory.
        /// </summary>
        public static void Initialize()
        {
            CWD = AppDomain.CurrentDomain.BaseDirectory;
            IsInitialized = true;
            Text.WriteHeaderToConsole(0x01, "MeowcatXLib.IO: Initialization complete!");
        }

        public static void WriteTextFile(string[] TextToWriteDown, string TargetLocation)
        {
            // First thing's first, make sure the module is initialized. If not, fix that real quick.
            if (IsInitialized == false) { Initialize(); }

            // Next, perform a null check for the target, defaulting to the CWD if null.
            if (TargetLocation == null) { TargetLocation = CWD; }

            // Alright, let's get to business.
            try
            {
                Console.WriteLine("Please wait while your challenge is saved in\n" + TargetLocation);
                File.WriteAllLines(TargetLocation + @"HL2Challenge.txt", TextToWriteDown);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.Clear();
                Text.WriteHeaderToConsole(0x02, "Well, heck. Looks like there was an access exception.");
                Console.WriteLine("System error message:\n" + e.Message + "\n");
                Console.WriteLine("Typically this error can be circumvented by restarting the program with elevation.");
                Console.WriteLine("If that doesn't fix the issue and you land on this again, please let us know.");
                Console.WriteLine("Press any key to unlock the program and return to normal execution.");
                _ = Console.ReadKey();
                return;
            }
            Text.WriteHeaderToConsole(0x01, "Success! Press any key to continue.");
            _ = Console.ReadKey();
            return;
        }
    }
}