// ConsoleHelper.cs
/*
 * Jeron Okkers
 * ST10447759
 * PROG6221
 */
// Provides utility methods for visual effects like typing animation and ASCII art logo
// Reference: ASCII art from https://www.asciiart.eu/text-to-ascii-art

using System;
using System.Threading;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    /// <summary>
    /// Provides helper methods for console output effects.
    /// </summary>
    public static class ConsoleUI
    {
        private const int TypingDelay = 40;

        /// <summary>
        /// Draws the ASCII art header centered in the console.
        /// </summary>
        public static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            string[] headerLines = new[]
            {
                "================================================================================================================",
                "██████╗██╗   ██╗██████╗ ███████╗██████╗",
                "██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗",
                "██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝",
                "██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗",
                "╚██████╗   ██║   ██████╔╝███████╗██║  ██║",
                " ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝",
                "",
                "██████╗██╗  ██╗ █████╗ ████████╗██████╗  ██████╗ ████████╗",
                "██╔════╝██║  ██║██╔══██╗╚══██╔══╝██╔══██╗██╔═══██╗╚══██╔══╝",
                "██║     ███████║███████║   ██║   ██████╔╝██║   ██║   ██║   ",
                "██║     ██╔══██║██╔══██║   ██║   ██╔══██╗██║   ██║   ██║   ",
                "╚██████╗██║  ██║██║  ██║   ██║   ██████╔╝╚██████╔╝   ██║   ",
                " ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═════╝  ╚═════╝    ╚═╝   ",
                "",
                "================================================================================================================",
                "Cybersecurity Awareness Bot"
            };

            int windowWidth = Console.WindowWidth;
            foreach (var line in headerLines)
            {
                int pad = Math.Max(0, (windowWidth - line.Length) / 2);
                Console.WriteLine(new string(' ', pad) + line);
                Thread.Sleep(100); // animation effect
            } 

            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Simulates typing effect when writing messages to the console.
        /// </summary>
        public static async Task TypeWriteAsync(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Bot: ");
            foreach (var ch in message)
            {
                Console.Write(ch);
                await Task.Delay(TypingDelay);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
//==================================================================================/
