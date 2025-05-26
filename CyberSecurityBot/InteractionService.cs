// InteractionService.cs
/*
 * Jeron Okkers
 * ST10447759
 * PROG6221 - Part 2 Enhancement
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberSecurityBot.Services;

namespace CyberSecurityBot
{
    /// <summary>
    /// Handles user interaction: name greeting, menu-based Q&A,
    /// sentiment detection, memory storage, and recall.
    /// </summary>
    public class InteractionService
    {
        private readonly IResponseService _responseService;
        private readonly List<string> _topics;
        private readonly Dictionary<string, string> _memory = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public InteractionService(IResponseService responseService)
        {
            _responseService = responseService;
            _topics = responseService.GetAvailableTopics().OrderBy(t => t).ToList();
            _topics.Add("exit");
        }

        /// <summary>
        /// Prompts the user for their name and stores it.
        /// </summary>
        public async Task GreetAndAskNameAsync()
        {
            await ConsoleUI.TypeWriteAsync("Good day! What's your name?");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                var input = Console.ReadLine()?.Trim();
                Console.ResetColor();
                if (!string.IsNullOrEmpty(input))
                {
                    _memory["name"] = input;
                    break;
                }
                await ConsoleUI.TypeWriteAsync("Oops, I missed that. Please type your name:");
            }
            await ConsoleUI.TypeWriteAsync($"Nice to meet you, {_memory["name"]}! Let's get started.\n");
        }

        /// <summary>
        /// Displays a menu of topics and processes user input until exit.
        /// Includes sentiment detection, user memory capture, and recall.
        /// </summary>
        public async Task MenuInteractionAsync()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Select a topic by number, type a keyword (e.g. 'phishing'), or 'exit':");
                for (int i = 0; i < _topics.Count; i++)
                    Console.WriteLine($"  {i + 1}. {_topics[i]}");
                Console.ResetColor();

                var input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    await ConsoleUI.TypeWriteAsync("Please enter a topic or number.");
                    continue;
                }

                // Exit
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)
                    || (int.TryParse(input, out int ex) && ex == _topics.Count))
                {
                    await ConsoleUI.TypeWriteAsync("Goodbye! Stay secure online.");
                    break;
                }

                // Memory capture: user interest
                if (input.StartsWith("I'm interested in", StringComparison.OrdinalIgnoreCase))
                {
                    var topic = input.Substring(input.IndexOf("in", StringComparison.OrdinalIgnoreCase) + 2).Trim();
                    _memory["interest"] = topic;
                    Console.WriteLine($"Chatbot: Great! I'll remember that you're interested in {topic}.");
                    continue;
                }

                // Memory recall
                if (input.Equals("What have you done for me?", StringComparison.OrdinalIgnoreCase))
                {
                    await ShowMemoryAsync();
                    continue;
                }

                // Sentiment detection
                if (input.IndexOf("worried", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine("Chatbot: It's understandable to feel that way. Let me share some tips to help you stay safe.");
                    continue;
                }
                if (input.IndexOf("frustrated", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine("Chatbot: I’m sorry you feel frustrated. How can I help clarify things?");
                    continue;
                }

                string reply;
                // Number selection
                if (int.TryParse(input, out int sel) && sel >= 1 && sel < _topics.Count)
                {
                    reply = _responseService.GetRandomResponse(_topics[sel - 1]);
                }
                else
                {
                    // Keyword detection
                    var found = _topics
                        .Where(t => t != "exit")
                        .FirstOrDefault(t => input.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0);
                    reply = _responseService.GetRandomResponse(found ?? "");
                }

                await ConsoleUI.TypeWriteAsync(reply);
                Console.WriteLine();
            }
        }

        private async Task ShowMemoryAsync()
        {
            await ConsoleUI.TypeWriteAsync("Here's what I remember about you:");
            foreach (var kv in _memory)
            {
                await ConsoleUI.TypeWriteAsync($" - {kv.Key}: {kv.Value}");
            }
        }
    }
}
