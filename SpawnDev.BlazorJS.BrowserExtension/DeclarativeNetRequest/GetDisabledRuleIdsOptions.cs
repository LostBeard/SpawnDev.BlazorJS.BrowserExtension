using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// An object containing details of the ruleset to return disabled rules for.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-GetDisabledRuleIdsOptions
    /// </summary>
    public class GetDisabledRuleIdsOptions
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RulesetId { get; set; }
    }
}
