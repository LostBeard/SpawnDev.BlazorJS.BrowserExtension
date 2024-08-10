using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// Options used for Action.SetPopup()<br/>
    /// - If windowId and tabId are both supplied, the function fails and the popup is not set.<br/>
    /// - If windowId and tabId are both omitted, the global popup is set.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/setPopup#details
    /// </summary>
    public class SetPopupDetails
    {
        /// <summary>
        /// string or null. The HTML file to show in a popup, specified as a URL.<br/>
        /// This can point to a file packaged within the extension (for example, created using extension.getURL), or a remote document (e.g. https://example.org/).<br/>
        /// If an empty string ("") is passed here, the popup is disabled, and the extension will receive action.onClicked events.<br/>
        /// If popup is null:<br/>
        /// - If tabId is specified, removes the tab-specific popup so that the tab inherits the global popup.<br/>
        /// - If windowId is specified, removes the window-specific popup so that the window inherits the global popup.<br/>
        /// - If tabId and windowId are both omitted, reverts the global popup to the default value.
        /// </summary>
        public string? Popup { get; set; }
        /// <summary>
        /// integer. Sets the popup only for a specific tab. The popup is reset when the user navigates this tab to a new page.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// integer. Sets the popup only for the specified window.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
