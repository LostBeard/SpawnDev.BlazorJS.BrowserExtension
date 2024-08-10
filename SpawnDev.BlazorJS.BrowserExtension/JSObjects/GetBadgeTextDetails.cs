using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// Options used for Action.GetBadgeText()<br/>
    /// - If windowId and tabId are both supplied, the function fails.<br/>
    /// - If windowId and tabId are both omitted, the global badge text is returned.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/getBadgeText#details
    /// </summary>
    public class GetBadgeTextDetails
    {
        /// <summary>
        /// integer. Specifies the tab from which to get the badge text.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// integer. Specifies the window from which to get the badge text.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
