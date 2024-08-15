using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-UpdateRulesetOptions
    /// </summary>
    public class UpdateRulesetOptions
    {
        /// <summary>
        /// The set of ids corresponding to a static Ruleset that should be disabled.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[] DisableRulesetIds { get; set; }
        /// <summary>
        /// The set of ids corresponding to a static Ruleset that should be enabled.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[] EnableRulesetIds { get; set; }
    }
}
