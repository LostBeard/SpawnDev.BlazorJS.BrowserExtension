using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Details of the connection<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime/connect#connectinfo
    /// </summary>
    public class ConnectInfo
    {
        /// <summary>
        /// string. Will be passed into runtime.onConnect for processes that are listening for the connection event.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }
        /// <summary>
        /// boolean. Whether the TLS channel ID will be passed into runtime.onConnectExternal for processes that are listening for the connection event.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeTlsChannelId { get; set; }
    }
}
