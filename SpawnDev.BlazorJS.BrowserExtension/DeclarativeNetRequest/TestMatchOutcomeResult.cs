namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-TestMatchOutcomeResult
    /// </summary>
    public class TestMatchOutcomeResult
    {
        /// <summary>
        /// The rules (if any) that match the hypothetical request.
        /// </summary>
        public MatchedRule[] MatchedRules { get; set; }
    }
}
