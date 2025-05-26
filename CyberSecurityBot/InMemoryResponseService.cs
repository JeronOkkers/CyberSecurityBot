// Services/InMemoryResponseService.cs
/*
 * Jeron Okkers
 * ST10447759
 * PROG6221
 * Provides answers from in-memory ResponseData
 */
using System;
using System.Collections.Generic;
using CyberSecurityBot.Services;

namespace CyberSecurityBot.Services
{
    //--------------------------------------------------------------------------------------//
    /// <summary>
    /// Provides responses to user queries based on in-memory data.
    /// </summary>
    public class InMemoryResponseService : IResponseService
    {
        //--------------------------------------------------------------------------------------//    
        // Holds the response data for various cybersecurity topics.
        //--------------------------------------------------------------------------------------//
        public string GetRandomResponse(string key)
        {
            if (ResponseData.Responses.TryGetValue(key, out var replies) && replies.Count > 0)
            {
                var rnd = new Random();
                return replies[rnd.Next(replies.Count)];
            }
            return "Sorry, I don't have a response for that topic—try another one!";
        }

        public IEnumerable<string> GetAvailableTopics() => ResponseData.Responses.Keys;
    }
}
//==================================================================================/
