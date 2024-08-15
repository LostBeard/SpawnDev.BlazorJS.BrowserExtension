namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-MatchedRuleInfo
    /// </summary>
    public class MatchedRuleInfo
    {
        /// <summary>
        /// The matched rule
        /// </summary>
        public MatchedRule Rule { get; set; }
        /// <summary>
        /// The tabId of the tab from which the request originated if the tab is still active. Else -1.
        /// </summary>
        public int TabId { get; set; }
        /// <summary>
        /// The time the rule was matched. Timestamps will correspond to the Javascript convention for times, i.e. number of milliseconds since the epoch.
        /// </summary>
        public double TimeStamp { get; set; }
    }
}
