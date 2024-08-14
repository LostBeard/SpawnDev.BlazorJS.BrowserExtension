using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Use the chrome.windows API to interact with browser windows. You can use this API to create, modify, and rearrange windows in the browser.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/windows<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/windows<br/>
    /// </summary>
    public partial class Windows : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Windows(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Gets details about a window, given its ID.
        /// </summary>
        public Task<Window?> Get(int windowId, GetInfo details) => JSRef!.CallAsync<Window?>("get", windowId, details);
        /// <summary>
        /// Gets the current window.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task<Window?> GetCurrent(GetInfo details) => JSRef!.CallAsync<Window?>("getCurrent", details);
        /// <summary>
        /// Gets the window that was most recently focused — typically the window 'on top'.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task<Window?> GetLastFocused(GetInfo details) => JSRef!.CallAsync<Window?>("getLastFocused", details);
        /// <summary>
        /// Gets all windows.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task<Array<Window>?> GetAll(GetInfo details) => JSRef!.CallAsync<Array<Window>?>("getAll", details);
    }
}
