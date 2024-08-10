using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// Options used for Action.GetPopup()<br/>
    /// - If windowId and tabId are both supplied, the function fails.<br/>
    /// - If windowId and tabId are both omitted, the global popup is returned.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/getPopup#details
    /// </summary>
    public class GetPopupDetails
    {
        /// <summary>
        /// integer. The tab whose popup to get.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// integer. The windows whose popup to get.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
