using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// This describes the possible operations for a "modifyHeaders" rule.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-HeaderOperation
    /// </summary>
    public enum HeaderOperation
    {
        /// <summary>
        /// Append
        /// </summary>
        [JsonPropertyName("append")]
        Append,
        /// <summary>
        /// Set
        /// </summary>
        [JsonPropertyName("set")]
        Set,
        /// <summary>
        /// Remove
        /// </summary>
        [JsonPropertyName("remove")]
        Remove,
    }
}
