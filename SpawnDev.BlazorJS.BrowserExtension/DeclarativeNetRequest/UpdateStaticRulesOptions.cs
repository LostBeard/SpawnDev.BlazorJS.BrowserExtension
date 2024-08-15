using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-UpdateStaticRulesOptions
    /// </summary>
    public class UpdateStaticRulesOptions
    {
        /// <summary>
        /// Set of ids corresponding to rules in the Ruleset to disable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int[]? DisableRuleIds { get; set; }
        /// <summary>
        /// Set of ids corresponding to rules in the Ruleset to enable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int[]? EnableRuleIds { get; set; }
        /// <summary>
        /// The id corresponding to a static Ruleset.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RulesetId { get; set; }
    }
}
