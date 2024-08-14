using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Options object used with Tabs.SendMessage()<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/tabs/sendMessage#options
    /// </summary>
    public class TabMessageOptions
    {
        /// <summary>
        /// integer. Sends the message to a specific frame identified by frameId instead of all frames in the tab. Whether the content script is executed in all frames depends on the all_frames setting in the content_scripts section of manifest.json.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameId { get; set; }
    }
}
