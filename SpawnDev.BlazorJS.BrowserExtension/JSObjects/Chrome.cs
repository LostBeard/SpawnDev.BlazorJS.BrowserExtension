using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
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
        /// This module provides information about your extension and the environment it's running in.
        /// </summary>
        public ChromeRuntime? Runtime => JSRef!.Get<ChromeRuntime?>("runtime");
        /// <summary>
        /// Enables extensions to store and retrieve data, and listen for changes to stored items.
        /// </summary>
        public ChromeStorage? Storage => JSRef!.Get<ChromeStorage?>("storage");
        /// <summary>
        /// Interact with the browser's tab system.
        /// </summary>
        public Tabs? Tabs => JSRef!.Get<Tabs?>("tabs");
    }
}
