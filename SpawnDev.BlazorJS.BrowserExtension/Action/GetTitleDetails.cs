using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Options used for Action.GetTitle()<br/>
    /// - If windowId and tabId are both supplied, the function fails and the promise it returns is rejected.<br/>
    /// - If windowId and tabId are both omitted, the global title is returned.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/getTitle#details
    /// </summary>
    public class GetTitleDetails
    {
        /// <summary>
        /// integer. Sets the title only for the given tab.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// integer. Sets the title for the given window.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
