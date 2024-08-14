using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// The type of browser window this is.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/windows/WindowType
    /// </summary>
    public enum WindowType
    {
        /// <summary>
        /// Normal
        /// </summary>
        [JsonPropertyName("normal")]
        Normal,
        /// <summary>
        /// Popup
        /// </summary>
        [JsonPropertyName("popup")]
        Popup,
        /// <summary>
        /// Panel
        /// </summary>
        [JsonPropertyName("panel")]
        Panel,
        /// <summary>
        /// DevTools
        /// </summary>
        [JsonPropertyName("devtools")]
        DevTools,
    }
}
