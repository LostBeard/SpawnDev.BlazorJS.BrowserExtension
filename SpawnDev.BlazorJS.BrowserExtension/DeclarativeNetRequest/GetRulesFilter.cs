using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-GetRulesFilter
    /// </summary>
    public class GetRulesFilter
    {
        /// <summary>
        /// An array of integer. The IDs of the rules to return.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int[]? RuleIds { get; set; }
    }
}
