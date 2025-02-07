using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Properties of the new context menu item.<br/>
    /// Properties vary between Firefox and Chrome<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/contextMenus#type-CreateProperties<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/menus/create#createproperties
    /// </summary>
    public class CreateProperties
    {
        /// <summary>
        /// string. String describing an action that should be taken when the user clicks the item. The recognized values are:<br/>
        /// "_execute_browser_action": simulate a click on the extension's browser action, opening its popup if it has one (Manifest V2 only)<br/>
        /// "_execute_action": simulate a click on the extension's action, opening its popup if it has one (Manifest V3 only)<br/>
        /// "_execute_page_action": simulate a click on the extension's page action, opening its popup if it has one<br/>
        /// "_execute_sidebar_action": open the extension's sidebar<br/>
        /// When one of the recognized values is specified, clicking the item does not trigger the menus.onClicked event; instead, the default action triggers, such as opening a pop-up.<br/>
        /// Otherwise, clicking the item triggers menus.onClicked and the event can be used to implement fallback behavior.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Command { get; set; }
        /// <summary>
        /// object. One or more custom icons to display next to the item. Custom icons can only be set for items appearing in submenus. This property is an object with one property for each supplied icon: the property's name should include the icon's size in pixels, and path is relative to the icon from the extension's root directory. The browser tries to choose a 16x16 pixel icon for a normal display or a 32x32 pixel icon for a high-density display. To avoid any scaling, you can specify icons like this:
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<int, string>? Icons { get; set; }


        /// <summary>
        /// The initial state of a checkbox or radio button: true for selected, false for unselected. Only one radio button can be selected at a time in a given group.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Checked { get; set; }
        /// <summary>
        /// List of contexts this menu item will appear in. Defaults to ['page'].
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string>? Contexts { get; set; }
        /// <summary>
        /// Restricts the item to apply only to documents or frames whose URL matches one of the given patterns. For details on pattern formats, see Match Patterns.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string>? DocumentUrlPatterns { get; set; }
        /// <summary>
        /// Whether this context menu item is enabled or disabled. Defaults to true.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Enabled { get; set; }
        /// <summary>
        /// The unique ID to assign to this item. Mandatory for event pages. Cannot be the same as another ID for this extension.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }
        /// <summary>
        /// The ID of a parent menu item; this makes the item a child of a previously added item.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<string, int>? ParentId { get; set; }
        /// <summary>
        /// Similar to documentUrlPatterns, filters based on the src attribute of img, audio, and video tags and the href attribute of a tags.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string>? TargetUrlPatterns { get; set; }
        /// <summary>
        /// The text to display in the item; this is required unless type is separator. When the context is selection, use %s within the string to show the selected text. For example, if this parameter's value is "Translate '%s' to Pig Latin" and the user selects the word "cool", the context menu item for the selection is "Translate 'cool' to Pig Latin".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }
        /// <summary>
        /// The type of menu item. Defaults to normal.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ItemType { get; set; }
        /// <summary>
        /// Whether the item is visible in the menu.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Visible { get; set; }
        /// <summary>
        /// A function that is called back when the menu item is clicked. This is not available inside of a service worker; instead, you should register a listener for contextMenus.onClicked.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ActionCallback<OnClickData, Tab>? OnClick { get; set; }
    }
}
