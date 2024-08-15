using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-ResourceType
    /// </summary>
    public enum ResourceType
    {
        /// <summary>
        /// MainFrame
        /// </summary>
        [JsonPropertyName("main_frame")]
        MainFrame,
        /// <summary>
        /// SubFrame
        /// </summary>
        [JsonPropertyName("sub_frame")]
        SubFrame,
        /// <summary>
        /// StyleSheet
        /// </summary>
        [JsonPropertyName("stylesheet")]
        StyleSheet,
        /// <summary>
        /// Script
        /// </summary>
        [JsonPropertyName("script")]
        Script,
        /// <summary>
        /// Image
        /// </summary>
        [JsonPropertyName("image")]
        Image,
        /// <summary>
        /// Font
        /// </summary>
        [JsonPropertyName("font")]
        Font,
        /// <summary>
        /// Object
        /// </summary>
        [JsonPropertyName("object")]
        Object,
        /// <summary>
        /// XMLHttpRequest
        /// </summary>
        [JsonPropertyName("xmlhttprequest")]
        XMLHttpRequest,
        /// <summary>
        /// Ping
        /// </summary>
        [JsonPropertyName("ping")]
        Ping,
        /// <summary>
        /// CSPReport
        /// </summary>
        [JsonPropertyName("csp_report")]
        CSPReport,
        /// <summary>
        /// Media
        /// </summary>
        [JsonPropertyName("media")]
        Media,
        /// <summary>
        /// WebSocket
        /// </summary>
        [JsonPropertyName("websocket")]
        WebSocket,
        /// <summary>
        /// WebTransport
        /// </summary>
        [JsonPropertyName("webtransport")]
        WebTransport,
        /// <summary>
        /// WebBundle
        /// </summary>
        [JsonPropertyName("webbundle")]
        WebBundle,
        /// <summary>
        /// Other
        /// </summary>
        [JsonPropertyName("other")]
        Other,
    }
}
