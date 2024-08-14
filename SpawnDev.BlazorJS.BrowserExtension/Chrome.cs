using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Extension APIs
    /// </summary>
    public class Chrome : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Chrome(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Read and modify attributes of and listen to clicks on the browser toolbar button defined with the action manifest key.
        /// </summary>
        public Action? Action => JSRef!.Get<Action?>("action");
        /// <summary>
        /// This module provides information about your extension and the environment it's running in.
        /// </summary>
        public Runtime? Runtime => JSRef!.Get<Runtime?>("runtime");
        /// <summary>
        /// Enables extensions to store and retrieve data, and listen for changes to stored items.
        /// </summary>
        public Storage? Storage => JSRef!.Get<Storage?>("storage");
        /// <summary>
        /// Interact with the browser's tab system.
        /// </summary>
        public Tabs? Tabs => JSRef!.Get<Tabs?>("tabs");
        /// <summary>
        /// The chrome.declarativeNetRequest API is used to block or modify network requests by specifying declarative rules. This lets extensions modify network requests without intercepting them and viewing their content, thus providing more privacy.
        /// </summary>
        public DeclarativeNetRequest? DeclarativeNetRequest => JSRef!.Get<DeclarativeNetRequest?>("declarativeNetRequest");
    }
}
