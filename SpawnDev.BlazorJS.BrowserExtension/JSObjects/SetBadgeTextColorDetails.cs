using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// Options used for Action.SetBadgeTextColor()<br/>
    /// - If windowId and tabId are both supplied, the function fails and the color is not set.<br/>
    /// - If windowId and tabId are both omitted, the global badge text color is set instead.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/setBadgeTextColor#details
    /// </summary>
    public class SetBadgeTextColorDetails
    {
        /// <summary>
        /// The color, specified as one of:<br/>
        /// - a string: any CSS <color> value, for example "red", "#FF0000", or "rgb(255 0 0)". If the string is not a valid color, the returned promise will be rejected and the text color won't be altered.<br/>
        /// - a action.ColorArray object.<br/>
        /// - null. If a tabId is specified, it removes the tab-specific badge text color so that the tab inherits the global badge text color. Otherwise it reverts the global badge text color to the default value.<br/>
        /// </summary>
        public Union<string, int[]>? Color { get; set; }
        /// <summary>
        /// integer. Sets the badge text color only for the given tab. The color is reset when the user navigates this tab to a new page.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// integer. Sets the badge text color only for the given tab.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
