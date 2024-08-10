using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// The reason that the runtime.onInstalled event is being dispatched.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime/OnInstalledReason
    /// </summary>
    public enum OnInstalledReason
    {
        /// <summary>
        /// The extension was installed.
        /// </summary>
        [JsonPropertyName("install")]
        Install,
        /// <summary>
        /// The extension was updated to a new version.
        /// </summary>
        [JsonPropertyName("update")]
        Update,
        /// <summary>
        /// The browser was updated to a new version.
        /// </summary>
        [JsonPropertyName("browser_update")]
        BrowserUpdate,
        /// <summary>
        /// The browser was updated to a new version.
        /// </summary>
        [JsonPropertyName("chrome_update")]
        ChromeUpdate,
        /// <summary>
        /// Another extension, which contains a module used by this extension, was updated.
        /// </summary>
        [JsonPropertyName("shared_module_update")]
        SharedModuleUpdate,
    }
    /// <summary>
    /// The reason that the onRestartRequired event is being dispatched.
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
