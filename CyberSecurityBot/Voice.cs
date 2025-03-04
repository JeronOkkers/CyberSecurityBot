using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    class Voice
    {
        public void Speak()
        {
            // Specify the path to your .wav file
            string wavFilePath = @"C:\Users\DELL\source\repos\CyberSecurityBot\CyberSecurityBot\Greeting.wav";  // Replace 'yourfile.wav' with the actual file name
            // Create an instance of SoundPlayer and load the .wav file
            SoundPlayer player = new SoundPlayer(wavFilePath);

            try
            {
                // Play the sound file
                player.PlaySync(); // Play synchronously (blocks until finished)
                               // Alternatively, you can use player.PlayAsync() for non-blocking
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., file not found)
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            // Your main program logic can go here
            Console.WriteLine("Program started!");
        }

    }
}
