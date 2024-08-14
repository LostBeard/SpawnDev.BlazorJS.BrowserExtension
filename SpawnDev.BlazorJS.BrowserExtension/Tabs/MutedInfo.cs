using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// This object contains a boolean indicating whether the tab is muted, and the reason for the last state change.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/tabs/MutedInfo
    /// </summary>
    public class MutedInfo : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public MutedInfo(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// boolean. Whether the tab is currently muted. Equivalent to whether the muted audio indicator is showing.
        /// </summary>
        public bool Muted => JSRef!.Get<bool>("muted");
        // TODO
    }
}
