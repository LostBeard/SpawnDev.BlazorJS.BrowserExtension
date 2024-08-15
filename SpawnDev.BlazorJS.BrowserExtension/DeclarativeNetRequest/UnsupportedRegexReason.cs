using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Describes the reason why a given regular expression isn't supported.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-UnsupportedRegexReason
    /// </summary>
    public enum UnsupportedRegexReason
    {
        /// <summary>
        /// Block the network request.
        /// </summary>
        [JsonPropertyName("syntaxError")]
        SyntaxError,
        /// <summary>
        /// Block the network request.
        /// </summary>
        [JsonPropertyName("memoryLimitExceeded")]
        MemoryLimitExceeded,
    }
}
