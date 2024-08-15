using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Add event listeners for the various stages of making an HTTP request, which includes websocket requests on ws:// and wss://. The event listener receives detailed information about the request and can modify or cancel the request.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/webRequest
    /// </summary>
    public partial class WebRequest : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebRequest(IJSInProcessObjectReference _ref) : base(_ref) { }
        public WebRequestEvent OnBeforeRequest { get => JSRef!.Get<WebRequestEvent>("onBeforeRequest"); set { } }

    }
    public class BlockingResponse
    {

    }
    public class RequestFilter
    {

    }
    public class WebRequestDetails
    {

    }
}
