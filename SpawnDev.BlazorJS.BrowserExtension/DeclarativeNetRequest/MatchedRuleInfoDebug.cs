namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-MatchedRuleInfoDebug
    /// </summary>
    public class MatchedRuleInfoDebug
    {
        /// <summary>
        /// Details about the request for which the rule was matched.
        /// </summary>
        public RequestDetails? Request { get; set; }
        /// <summary>
        /// Matched Rule
        /// </summary>
        public MatchedRule? Rule { get; set; }
    }
}
