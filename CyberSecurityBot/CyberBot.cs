// CyberBot.cs
/*
 * Jeron Okkers
 * ST10447759
 * PROG6221
 */
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    /// <summary>
    /// Orchestrates the bot services: greeting, interaction, and UI.
    /// </summary>
    public class CyberBot
    {
        private readonly VoiceGreetingService _voiceService;
        private readonly InteractionService _interactionService;

        public CyberBot(VoiceGreetingService voiceService,
                        InteractionService interactionService)
        {
            _voiceService = voiceService;
            _interactionService = interactionService;
        }

        /// <summary>
        /// Runs the chatbot by invoking each service in order.
        /// </summary>
        public async Task RunAsync()
        {
            await _interactionService.GreetAndAskNameAsync();
            await _interactionService.MenuInteractionAsync();
        }
    }
}
//================================================================================================================================================================//
