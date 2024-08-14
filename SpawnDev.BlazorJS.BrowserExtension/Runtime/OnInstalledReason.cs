using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
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
}
