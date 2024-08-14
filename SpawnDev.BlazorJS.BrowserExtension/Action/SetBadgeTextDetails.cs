using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Options used for Action.SetBadgeText()<br/>
    /// - If windowId and tabId are both supplied, the function fails.<br/>
    /// - If windowId and tabId are both omitted, the global badge is set.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/setBadgeText#details
    /// </summary>
    public class SetBadgeTextDetails
    {
        /// <summary>
        /// string or null. Any number of characters can be passed, but only about four can fit in the space.<br/>
        /// Use an empty string - "" - if you don't want any badge.<br/>
        /// - If a tabId is specified, null removes the tab-specific badge text so that the tab inherits the global badge text. Otherwise it reverts the global badge text to "".<br/>
        /// - If a windowId is specified, null removes the window-specific badge text so that the tab inherits the global badge text. Otherwise it reverts the global badge text to "".<br/>
        /// </summary>
        public string? Text { get; set; }
        /// <summary>
        /// integer. Set the badge text only for the given tab. The text is reset when the user navigates this tab to a new page.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// integer. Set the badge text for the given window.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
