using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Options used for Action.IsEnabled()<br/>
    /// - If windowId and tabId are both supplied, the function fails.<br/>
    /// - If windowId and tabId are both omitted, the global enabled/disabled status is returned.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/isEnabled#details
    /// </summary>
    public class IsEnabledDetails
    {
        /// <summary>
        /// integer. ID of a tab to check.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// integer. ID of a window to check.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
