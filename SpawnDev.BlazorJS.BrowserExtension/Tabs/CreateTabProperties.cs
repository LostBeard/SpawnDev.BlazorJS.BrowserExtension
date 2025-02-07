using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/tabs/create#createproperties<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/tabs#parameters_2<br/>
    /// </summary>
    public class CreateTabProperties
    {
        /// <summary>
        /// Whether the tab should become the active tab in the window. Does not affect whether the window is focused (see windows.update). Defaults to true.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Active { get; set; }
        /// <summary>
        /// The position the tab should take in the window. The provided value is clamped to between zero and the number of tabs in the window.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index { get; set; }
        /// <summary>
        /// The ID of the tab that opened this tab. If specified, the opener tab must be in the same window as the newly created tab.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? OpenerTabId { get; set; }
        /// <summary>
        /// Whether the tab should be pinned. Defaults to false
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Pinned { get; set; }
        /// <summary>
        /// The URL to initially navigate the tab to. Fully-qualified URLs must include a scheme (i.e., 'http://www.google.com', not 'www.google.com'). Relative URLs are relative to the current page within the extension. Defaults to the New Tab Page.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Url { get; set; }
        /// <summary>
        /// The window in which to create the new tab. Defaults to the current window.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
