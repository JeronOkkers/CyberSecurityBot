using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace CyberSecurityBot
{
    class Program
    {
        private static readonly string apiKey = "sk_30dbb654e8f4c3c7b16b1140e3c1ff692c5569ebc5a9f9a5";
        private static readonly string voiceId = "cgSgspJ2msm6clMCkdW9";
        private static readonly string textToRead = "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.";

        static async Task Main()
        {
            await ConvertTextToSpeech();
        }

        static async Task ConvertTextToSpeech()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("xi-api-key", apiKey);

                var requestBody = new
                {
                    text = textToRead,
                    model_id = "eleven_monolingual_v1",  // Change if needed
                    voice_settings = new { stability = 0.5, similarity_boost = 0.8 }
                };

                var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"https://api.elevenlabs.io/v1/text-to-speech/{voiceId}", content);

                if (response.IsSuccessStatusCode)
                {
                    byte[] audioData = await response.Content.ReadAsByteArrayAsync();
                    string filePath = "output.mp3";
                    await File.WriteAllBytesAsync(filePath, audioData);
                    Console.WriteLine($"Audio saved to {filePath}");
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {error}");
                }
            }
        }
    }
}
