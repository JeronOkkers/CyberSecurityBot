// Services/IResponseService.cs
/*
 * Jeron Okkers
 * ST10447759
 * PROG6221
 */
using System.Collections.Generic;

namespace CyberSecurityBot.Services
{
    /// <summary>
    /// Defines methods to fetch cybersecurity topic responses.
    /// </summary>
    public interface IResponseService
    {
        string GetRandomResponse(string key);
        IEnumerable<string> GetAvailableTopics();
    }
}
//================================================================================================================================================================//
