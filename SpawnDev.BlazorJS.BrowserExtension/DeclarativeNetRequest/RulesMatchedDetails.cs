namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-RulesMatchedDetails
    /// </summary>
    public class RulesMatchedDetails
    {
        /// <summary>
        /// Rules matching the given filter.
        /// </summary>
        public MatchedRuleInfo[] RulesMatchedInfo { get; set; }
    }
}
