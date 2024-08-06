using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// The query() function gets the tabs whose properties match the properties included here.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/tabs/query#queryinfo
    /// </summary>
    public class TabQueryInfo
    {
        /// <summary>
        /// boolean. Whether the tabs are active in their windows.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Active { get; set; }
        /// <summary>
        /// boolean. Indicates whether the tabs are drawing attention.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Attention { get; set; }
        /// <summary>
        /// boolean. Whether the tabs are audible.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Audible { get; set; }
        /// <summary>
        /// boolean. Whether the tab can be discarded by the browser. The default value is true. When set to false, the browser cannot automatically discard the tab. However, the tab can be discarded by tabs.discard.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AutoDiscardable { get; set; }
        /// <summary>
        /// string or array of string. Use this to return tabs whose tab.cookieStoreId matches any of the cookieStoreId strings. This option is only available if the add-on has the "cookies" permission. See Work with contextual identities for more information.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<string, string[]>? CookieStoreId { get; set; }
        /// <summary>
        /// boolean. Whether the tabs are in the current window.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? CurrentWindow { get; set; }
        /// <summary>
        /// boolean. Whether the tabs are discarded. A discarded tab is one whose content has been unloaded from memory, but is still visible in the tab strip. Its content gets reloaded the next time it's activated.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Discarded { get; set; }
        /// <summary>
        /// boolean. Whether the tabs are hidden.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Hidden { get; set; }
        /// <summary>
        /// boolean. Whether the tabs are highlighted.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Highlighted { get; set; }
        /// <summary>
        /// integer. The position of the tabs within their windows.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index { get; set; }
        /// <summary>
        /// boolean. Whether the tabs are muted.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Muted { get; set; }
        /// <summary>
        /// boolean. Whether the tabs are in the last focused window.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LastFocusedWindow { get; set; }
        /// <summary>
        /// boolean. Whether the tabs are pinned.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Pinned { get; set; }
        /// <summary>
        /// tabs.TabStatus. Whether the tabs have completed loading.<br/>
        /// Values of this type are strings. Possible values are: "loading" and "complete".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TabStatus { get; set; }
        /// <summary>
        /// string. Match page titles against a pattern. Requires the "tabs" permission or host permissions for the tab to match.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }
        /// <summary>
        /// string or array of string. Match tabs against one or more match patterns. Note that fragment identifiers are not matched. Requires the "tabs" permission or host permissions for the tab to match.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<string, string[]>? Url { get; set; }
        /// <summary>
        /// integer. The id of the parent window, or windows.WINDOW_ID_CURRENT for the current window.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
        /// <summary>
        /// tabs.WindowType. The type of window the tabs are in.<br/>
        /// Values of this type are strings. Possible values are:<br/>
        /// - "normal"<br/>
        /// - "popup"<br/>
        /// - "panel"<br/>
        /// - "devtools"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? WindowType { get; set; }
    }
}
