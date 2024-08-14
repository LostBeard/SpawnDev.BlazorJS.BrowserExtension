using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// An object containing information about the sender of a message or connection request that is passed to the runtime.onMessage() listener.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime/MessageSender
    /// </summary>
    public class MessageSender : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public MessageSender(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// string. A UUID of the document that opened the connection.
        /// </summary>
        public string? DocumentId => JSRef!.Get<string?>("documentId");
        /// <summary>
        /// string. The lifecycle state the document that opened the connection was in when the port was created. Note that the lifecycle state of the document may have changed since the port was created.
        /// </summary>
        public string? DocumentLifecycle => JSRef!.Get<string?>("documentLifecycle");
        /// <summary>
        /// integer. The frame that opened the connection. Zero for top-level frames, positive for child frames. This is only set when tab is set.
        /// </summary>
        public int? FrameId => JSRef!.Get<int?>("frameId");
        /// <summary>
        /// string. The origin of the page or frame that opened the connection. It can differ from the url property (e.g., about:blank) or be opaque (e.g., sandboxed iframes). This is useful for identifying if the origin can be trusted if it isn't apparent from the URL.
        /// </summary>
        public string? Origin => JSRef!.Get<string?>("origin");
        /// <summary>
        /// tabs.Tab. The tabs.Tab which opened the connection. This property is only present when the connection was opened from a tab (including content scripts).
        /// </summary>
        public Tab? Tab => JSRef!.Get<Tab?>("tab");
        /// <summary>
        /// string. The TLS channel ID of the page or frame that opened the connection, if requested by the extension and available.
        /// </summary>
        public string? TlsChannelId => JSRef!.Get<string?>("tlsChannelId");
        /// <summary>
        /// string. The URL of the page or frame hosting the script that sent the message.<br/>
        /// If the sender is a script running in an extension page (such as a background page, an options page, or a browser action or page action popup), the URL is in the form "moz-extension://&lt;extension-internal-id>/path/to/page.html". If the sender is a background script and you haven't included a background page, it is "moz-extension://&lt;extension-internal-id>/_generated_background_page.html".<br/>
        /// If the sender is a script running in a web page (including content and normal page scripts), then url is the web page URL. If the script is running in an iframe, url is the iframe's URL.
        /// </summary>
        public string? Url => JSRef!.Get<string?>("url");
    }
}
