using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-MatchedRulesFilter
    /// </summary>
    public class MatchedRulesFilter
    {
        /// <summary>
        /// If specified, only matches rules after the given timestamp.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MinTimeStamp { get; set; }
        /// <summary>
        /// If specified, only matches rules for the given tab. Matches rules not associated with any active tab if set to -1.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
    }
}
