using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// Options used for Action.GetBadgeBackgroundColor()<br/>
    /// - If windowId and tabId are both supplied, the function fails.<br/>
    /// - If windowId and tabId are both omitted, the global badge background color is returned.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/getBadgeBackgroundColor#details
    /// </summary>
    public class GetBadgeBackgroundColorDetails
    {
        /// <summary>
        /// integer. Specifies the tab to get the badge background color from.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// integer. Specifies the window from which to get the badge background color.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
