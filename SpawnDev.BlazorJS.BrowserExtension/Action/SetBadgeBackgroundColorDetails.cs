using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Options used for Action.SetBadgeBackgroundColor()<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/setBadgeBackgroundColor#details
    /// </summary>
    public class SetBadgeBackgroundColorDetails
    {
        /// <summary>
        /// The color, specified as one of:<br/>
        /// - a string: any CSS &lt;color> value, for example "red", "#FF0000", or "rgb(255 0 0)". If the string is not a valid color, the returned promise will be rejected and the background color won't be altered.<br/>
        /// - a action.ColorArray object.<br/>
        /// - null. If a tabId is specified, it removes the tab-specific badge background color so that the tab inherits the global badge background color. Otherwise it reverts the global badge background color to the default value.<br/>
        /// </summary>
        public Union<string, int[]>? Color { get; set; }
        /// <summary>
        /// integer. Sets the badge background color only for the given tab. The color is reset when the user navigates this tab to a new page.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// integer. Sets the badge background color only for the given tab.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
