using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Options use with Windows.Get()<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/windows/get#getinfo
    /// </summary>
    public class GetInfo
    {
        /// <summary>
        /// boolean. If true, the windows.Window object will have a tabs property that contains a list of tabs.Tab objects representing the tabs open in the window. The Tab objects only contain the url, title and favIconUrl properties if the extension's manifest file includes the "tabs" permission or a matching host permission.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Populate { get; set; }
        /// <summary>
        /// array of windows.WindowType objects. If set, the windows.Window returned will be filtered based on its type. If unset the default filter is set to ['normal', 'panel', 'popup'], with 'panel' window types limited to the extension's own windows.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<WindowType>[]? WindowTypes{ get; set; }
    }
}
