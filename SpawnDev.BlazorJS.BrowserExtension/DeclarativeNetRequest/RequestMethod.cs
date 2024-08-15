using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-RequestMethod
    /// </summary>
    public enum RequestMethod
    {
        /// <summary>
        /// Connect
        /// </summary>
        [JsonPropertyName("connect")]
        Connect,
        /// <summary>
        /// Delete
        /// </summary>
        [JsonPropertyName("delete")]
        Delete,
        /// <summary>
        /// Get
        /// </summary>
        [JsonPropertyName("get")]
        Get,
        /// <summary>
        /// Head
        /// </summary>
        [JsonPropertyName("head")]
        Head,
        /// <summary>
        /// Options
        /// </summary>
        [JsonPropertyName("options")]
        Options,
        /// <summary>
        /// Patch
        /// </summary>
        [JsonPropertyName("patch")]
        Patch,
        /// <summary>
        /// Post
        /// </summary>
        [JsonPropertyName("post")]
        Post,
        /// <summary>
        /// Put
        /// </summary>
        [JsonPropertyName("put")]
        Put,
        /// <summary>
        /// Other
        /// </summary>
        [JsonPropertyName("other")]
        Other,
    }
}
