namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-MatchedRule
    /// </summary>
    public class MatchedRule
    {
        /// <summary>
        /// A matching rule's ID.
        /// </summary>
        public int RuleId { get; set; }
        /// <summary>
        /// ID of the Ruleset this rule belongs to. For a rule originating from the set of dynamic rules, this will be equal to DYNAMIC_RULESET_ID.
        /// </summary>
        public string RulesetId { get; set; }
    }
}
