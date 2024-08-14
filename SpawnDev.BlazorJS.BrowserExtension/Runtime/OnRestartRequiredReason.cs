using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// The reason that the onRestartRequired event is being dispatched.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime/OnRestartRequiredReason
    /// </summary>
    public enum OnRestartRequiredReason
    {
        /// <summary>
        /// The application is being updated to a newer version.
        /// </summary>
        [JsonPropertyName("app_update")]
        AppUpdate,
        /// <summary>
        /// The browser/OS is updated to a newer version.
        /// </summary>
        [JsonPropertyName("os_update")]
        OSUpdate,
        /// <summary>
        /// The system has run for more than the permitted uptime set in the enterprise policy.
        /// </summary>
        [JsonPropertyName("periodic")]
        Periodic,
    }
}
