using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Chrome only (MV3): create and manage ONE offscreen document - an extension page without a window, with full DOM and
    /// web APIs (WebGPU included), that a service-worker background can use for work it cannot do itself. Requires the
    /// "offscreen" permission. Firefox has no offscreen API: its background is a page already.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/offscreen
    /// </summary>
    public class Offscreen : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Offscreen(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new offscreen document for the extension. Only one may exist at a time: creating a second rejects.
        /// </summary>
        public Task CreateDocument(OffscreenCreateParameters parameters) => JSRef!.CallVoidAsync("createDocument", parameters);
        /// <summary>
        /// Closes the extension's open offscreen document (rejects when there is none).
        /// </summary>
        public Task CloseDocument() => JSRef!.CallVoidAsync("closeDocument");
        /// <summary>
        /// True when the extension has an open offscreen document (Chrome 116+; runtime.getContexts is the newer way).
        /// </summary>
        public Task<bool> HasDocument() => JSRef!.CallAsync<bool>("hasDocument");
    }
}
