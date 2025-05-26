// Program.cs
/*
 * Jeron Okkers
 * ST10447759
 * PROG6221
 */
// Program.cs
// Entry point for the CyberSecurity Awareness Chatbot
using System;
using System.Threading.Tasks;
using CyberSecurityBot.Services;

namespace CyberSecurityBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize services
            IResponseService responseService = new InMemoryResponseService();
            var voiceService = new VoiceGreetingService("greeting.wav");
            var interactionService = new InteractionService(responseService);

            // Play voice greeting
            await voiceService.PlayGreetingAsync();

            // Start text-based interaction
            await interactionService.GreetAndAskNameAsync();
            await interactionService.MenuInteractionAsync();
        }
    }
}
//==================================================================================/
