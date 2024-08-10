using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// The category of warning that dispatched the runtime.onPerformanceWarning event.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime/OnPerformanceWarningCategory
    /// </summary>
    public enum OnPerformanceWarningCategory
    {
        /// <summary>
        /// The performance warning is for a slow content script in the listening extension.
        /// </summary>
        [JsonPropertyName("content_script")]
        ContentScript,
    }
}
