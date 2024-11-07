using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Interact with the browser's tab system.<br/>
    /// Note: The Tabs API can be used by the service worker and extension pages, but not content scripts.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/tabs
    /// </summary>
    public class Tabs : JSObject
    {
        /// <summary>
        /// A special ID value given to tabs that are not browser tabs (for example, tabs in devtools windows).
        /// </summary>
        public static int TAB_ID_NONE { get; } = -1;
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Tabs(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region Methods
        /// <summary>
        /// Retrieves details about the specified tab.
        /// </summary>
        /// <param name="tabId"></param>
        /// <returns></returns>
        public Task<Tab> Get(int tabId) => JSRef!.CallAsync<Tab>("get", tabId);
        /// <summary>
        /// Gets all tabs that have the specified properties, or all tabs if no properties are specified.
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        public Task<Tab[]> Query(TabQueryInfo queryInfo) => JSRef!.CallAsync<Tab[]>("query", queryInfo);
        /// <summary>
        /// Sends a single message to the content script(s) in the specified tab.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tabId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task<T> SendMessage<T>(int tabId, object message) => JSRef!.CallAsync<T>("sendMessage", tabId, message);
        /// <summary>
        /// Sends a single message to the content script(s) in the specified tab.
        /// </summary>
        /// <param name="tabId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessage(int tabId, object message) => JSRef!.CallVoidAsync("sendMessage", tabId, message);
        /// <summary>
        /// Sends a single message to the content script(s) in the specified tab.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tabId"></param>
        /// <param name="message"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task SendMessage(int tabId, object message, TabMessageOptions options) => JSRef!.CallVoidAsync("sendMessage", tabId, message, options);
        /// <summary>
        /// Sends a single message to the content script(s) in the specified tab.
        /// </summary>
        /// <param name="tabId"></param>
        /// <param name="message"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<T> SendMessage<T>(int tabId, object message, TabMessageOptions options) => JSRef!.CallAsync<T>("sendMessage", tabId, message, options);
        /// <summary>
        /// Reload a tab.
        /// </summary>
        /// <returns></returns>
        public Task Reload() => JSRef!.CallVoidAsync("reload");
        /// <summary>
        /// Reload a tab.
        /// </summary>
        /// <param name="tabId"></param>
        /// <returns></returns>
        public Task Reload(int tabId) => JSRef!.CallVoidAsync("reload", tabId);
        /// <summary>
        /// Reload a tab.
        /// </summary>
        /// <param name="tabId"></param>
        /// <param name="reloadProperties"></param>
        /// <returns></returns>
        public Task Reload(int tabId, ReloadProperties reloadProperties) => JSRef!.CallVoidAsync("reload", tabId, reloadProperties);
        #endregion
        #region Events
        // https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/tabs#events
        /// <summary>
        /// Fires when the active tab in a window changes. Note that the tab's URL may not be set at the time this event fired.
        /// </summary>
        public ActionEvent<ActiveInfo> OnActivated { get => JSRef!.Get<ActionEvent<ActiveInfo>>("onActivated"); set { } }
        /// <summary>
        /// Fired when a tab is updated.
        /// </summary>
        public ActionEvent<ChangeInfo> OnUpdated { get => JSRef!.Get<ActionEvent<ChangeInfo>>("onUpdated"); set { } }

        #endregion
    }
}
