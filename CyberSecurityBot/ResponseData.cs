// Services/ResponseData.cs
/*
 * Jeron Okkers
 * ST10447759
 * PROG6221 - Poe part 1
 * In-memory storage of cybersecurity Q&A data
 */
using System.Collections.Generic;

namespace CyberSecurityBot.Services
{
    /// <summary>
    /// Static repository of bot Q&A data.
    /// </summary>
    public static class ResponseData
    {
        public static readonly Dictionary<string, List<string>> Responses =
            new Dictionary<string, List<string>>(
                System.StringComparer.OrdinalIgnoreCase)
        {
            { "how are you", new List<string> {
                "I’m doing great, thanks for asking!",
                "Feeling secure and ready to help!" } },

            { "what's your purpose", new List<string> {
                "I’m here to help you stay safe online.",
                "My purpose is to guide you on cybersecurity best practices." } },

            { "password safety", new List<string> {
                "Use strong, unique passwords for each account—avoid dictionary words or personal info.",
                "Consider a passphrase like ‘Blue!Tiger7Rocket?’ and store it securely." } },

            { "phishing", new List<string> {
                "Don’t click on suspicious links. Hover to inspect real URLs before clicking.",
                "Verify urgent emails by contacting the sender through known channels." } },

            { "two-factor authentication", new List<string> {
                "Enable 2FA everywhere—authenticator apps or hardware keys offer best security.",
                "Keep backup codes offline in a safe place." } },

            { "software updates", new List<string> {
                "Keep your OS, browser, and apps up to date—patches fix vulnerabilities.",
                "Enable automatic updates on your firewall and router firmware." } },

            { "safe browsing", new List<string> {
                "Use HTTPS-only mode and avoid downloads from untrusted sites.",
                "Install an ad-blocker like uBlock Origin to reduce malicious ads." } },

            { "vpn usage", new List<string> {
                "Use a reputable VPN on public Wi‑Fi—avoid free VPNs that log data.",
                "Ensure it uses AES-256 encryption and no-logs policy." } },

            { "malware and antivirus", new List<string> {
                "Run reputable antivirus software and avoid suspicious executables.",
                "Perform on-demand scans periodically." } },

            { "network security", new List<string> {
                "Segment your network to limit access between systems.",
                "Use strong firewall rules and monitor logs for anomalies." } },

            { "social engineering", new List<string> {
                "Be wary of unsolicited requests for information, even if they appear legitimate.",
                "Verify identities by calling people back on known numbers." } }
        };
    }
}
//==================================================================================/
