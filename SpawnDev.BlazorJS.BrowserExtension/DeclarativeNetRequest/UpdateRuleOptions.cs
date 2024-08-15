using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-UpdateRuleOptions
    /// </summary>
    public class UpdateRuleOptions
    {
        /// <summary>
        /// Rules to add.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Rule[]? AddRules { get; set; }
        /// <summary>
        /// IDs of the rules to remove. Any invalid IDs will be ignored.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int[]? RemoveRuleIds{ get; set; }
    }
}
