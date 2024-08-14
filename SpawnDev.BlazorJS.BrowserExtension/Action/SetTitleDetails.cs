using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Options used for Action.SetTitle()<br/>
    /// - If windowId and tabId are both supplied, the function fails and the title is not set.<br/>
    /// - If windowId and tabId are both omitted, the global title is set.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/setTitle#details
    /// </summary>
    public class SetTitleDetails
    {
        /// <summary>
        /// string or null. The string the browser action should display when moused over.<br/>
        /// If title is an empty string, the used title will be the extension name, but action.getTitle will still provide the empty string.<br/>
        /// If title is null:<br/>
        /// - If tabId is specified, and the tab has a tab-specific title set, then the tab will inherit the title from the window to which it belongs.<br/>
        /// - if windowId is specified, and the window has a window-specific title set, then the window will inherit the global title.<br/>
        /// - Otherwise, the global title will be reset to the manifest title.
        /// </summary>
        public string? Title { get; set; }
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
