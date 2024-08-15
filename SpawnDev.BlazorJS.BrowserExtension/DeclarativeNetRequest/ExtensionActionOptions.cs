using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-ExtensionActionOptions
    /// </summary>
    public class ExtensionActionOptions
    {
        /// <summary>
        /// boolean Whether to automatically display the action count for a page as the extension's badge text. This preference persists across sessions.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DisplayActionCountAsBadgeText { get; set; }
        /// <summary>
        /// TabActionCountUpdate. Details of how the tab's action count should be adjusted. See the tabUpdate section for more details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TabActionCountUpdate? TabUpdate { get; set; }
    }
}
