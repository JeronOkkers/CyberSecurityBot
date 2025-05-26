// VoiceGreetingService.cs
/*
 * Jeron Okkers
 * ST10447759
 * PROG6221
 */ 
using System;
using System.IO;
using System.Media;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    //--------------------------------------------------------------------------------------//
    /// Plays the voice greeting WAV and types the welcome message.
    public class VoiceGreetingService
    {
        private const string GreetingFile = "Greeting.wav";

        public async Task PlayVoiceGreetingAsync()
        {
            try
            {
                //--------------------------------------------------------------------------------------//
                // Attempt to load and play a WAV greeting file  
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GreetingFile);
                using (var player = new SoundPlayer(filePath))
                {
                    player.Load();
                    player.Play(); // non-blocking  
                }
            }
            catch
            {
                // Ignore if file not found or audio errors  
            }

            // Simultaneously type the greeting message  
            await ConsoleUI.TypeWriteAsync(
                "Hello! Welcome to the Cybersecurity Awareness Bot. " +
                "I’m here to help you stay safe online."
            );
        }
    }
}
//==================================================================================/

