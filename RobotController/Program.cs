using System;

namespace RobotController
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string userInput;

            Console.Write("Enter robot input: ");
            userInput = Console.ReadLine();

            Console.Write("Press enter key to start");
            Console.ReadLine();

            using (var game = new RobotController(userInput))
                game.Run();

            Console.Write("Simulation Ended: Press enter key to exit");
            Console.ReadLine();
        }
    }
#endif
}
