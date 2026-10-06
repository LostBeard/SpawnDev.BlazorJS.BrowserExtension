using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// offscreen.createDocument parameters.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/offscreen#type-CreateParameters
    /// </summary>
    public class OffscreenCreateParameters
    {
        /// <summary>
        /// The (relative) URL of the document to load; it must be a static HTML file bundled with the extension.
        /// </summary>
        public string Url { get; set; } = "";
        /// <summary>
        /// Why the extension creates it (<see cref="OffscreenReason"/>): Chrome checks the document's lifetime against them.
        /// </summary>
        public string[] Reasons { get; set; } = Array.Empty<string>();
        /// <summary>
        /// A developer-provided string that explains, in more detail, why the offscreen document is needed.
        /// </summary>
        public string Justification { get; set; } = "";
    }

    /// <summary>
    /// offscreen.Reason values.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/offscreen#type-Reason
    /// </summary>
    public static class OffscreenReason
    {
        /// <summary>A reason used for testing purposes only.</summary>
        public const string Testing = "TESTING";
        /// <summary>The offscreen document is responsible for playing audio.</summary>
        public const string AudioPlayback = "AUDIO_PLAYBACK";
        /// <summary>The offscreen document needs to embed and script an iframe to modify its content.</summary>
        public const string IframeScripting = "IFRAME_SCRIPTING";
        /// <summary>The offscreen document needs to embed an iframe and scrape its DOM to extract information.</summary>
        public const string DomScraping = "DOM_SCRAPING";
        /// <summary>The offscreen document needs to interact with Blob objects (including URL.createObjectURL()).</summary>
        public const string Blobs = "BLOBS";
        /// <summary>The offscreen document needs to use the DOMParser API.</summary>
        public const string DomParser = "DOM_PARSER";
        /// <summary>The offscreen document needs to interact with media streams from user media (e.g. getUserMedia()).</summary>
        public const string UserMedia = "USER_MEDIA";
        /// <summary>The offscreen document needs to interact with media streams from display media (e.g. getDisplayMedia()).</summary>
        public const string DisplayMedia = "DISPLAY_MEDIA";
        /// <summary>The offscreen document needs to use WebRTC APIs.</summary>
        public const string WebRtc = "WEB_RTC";
        /// <summary>The offscreen document needs to interact with the Clipboard API.</summary>
        public const string Clipboard = "CLIPBOARD";
        /// <summary>Specifies that the offscreen document needs access to localStorage.</summary>
        public const string LocalStorage = "LOCAL_STORAGE";
        /// <summary>Specifies that the offscreen document needs to spawn workers.</summary>
        public const string Workers = "WORKERS";
        /// <summary>Specifies that the offscreen document needs to use navigator.getBattery.</summary>
        public const string BatteryStatus = "BATTERY_STATUS";
        /// <summary>Specifies that the offscreen document needs to use window.matchMedia.</summary>
        public const string MatchMedia = "MATCH_MEDIA";
        /// <summary>Specifies that the offscreen document needs to use navigator.geolocation.</summary>
        public const string Geolocation = "GEOLOCATION";
    }
}
