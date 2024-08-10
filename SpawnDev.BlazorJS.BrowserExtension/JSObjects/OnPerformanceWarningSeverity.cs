using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// The severity of warning that dispatched the runtime.onPerformanceWarning event.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime/OnPerformanceWarningSeverity
    /// </summary>
    public enum OnPerformanceWarningSeverity
    {
        /// <summary>
        /// Low
        /// </summary>
        [JsonPropertyName("low")]
        Low,
        /// <summary>
        /// Low
        /// </summary>
        [JsonPropertyName("medium")]
        Medium,
        /// <summary>
        /// Low
        /// </summary>
        [JsonPropertyName("high")]
        High,
    }
}
