using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// The state of this browser window.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/windows/WindowState
    /// </summary>
    public enum WindowState
    {
        /// <summary>
        /// The window is at the default size or user-selected size.
        /// </summary>
        [JsonPropertyName("normal")]
        Normal,
        /// <summary>
        /// The window is only visible as an icon in the taskbar or .
        /// </summary>
        [JsonPropertyName("minimized")]
        Minimized,
        /// <summary>
        /// The window fills the screen on which it is displayed not including any screen areas reserved by the operating system.
        /// </summary>
        [JsonPropertyName("maximized")]
        Maximized,
        /// <summary>
        /// The window is running as a full screen application or content in a tab is using the Fullscreen API
        /// </summary>
        [JsonPropertyName("fullscreen")]
        Fullscreen,
        /// <summary>
        /// A docked window occupies a fixed position relative to other windows owned by the same application.
        /// </summary>
        [JsonPropertyName("docked")]
        Docked,
    }
}
