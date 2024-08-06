//using Microsoft.JSInterop;
//using SpawnDev.BlazorJS.JSObjects;

//namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
//{
//    /// <summary>
//    /// This module provides information about your extension and the environment it's running in.<br/>
//    /// It also provides messaging APIs enabling you to:<br/>
//    /// - Communicate between different parts of your extension. For advice on choosing between the messaging options, see Choosing between one-off messages and connection-based messaging.<br/>
//    /// - Communicate with other extensions.<br/>
//    /// - Communicate with native applications.<br/>
//    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime
//    /// </summary>
//    public class BrowserRuntime : JSObject
//    {
//        /// <summary>
//        /// Deserialization constructor
//        /// </summary>
//        public BrowserRuntime(IJSInProcessObjectReference _ref) : base(_ref) { }
//        /// <summary>
//        /// The ID of the extension.
//        /// </summary>
//        public string? Id => JSRef!.Get<string>("id");
//        /// <summary>
//        /// Given a relative path from the manifest.json to a resource packaged with the extension, returns a fully-qualified URL.
//        /// </summary>
//        /// <param name="path"></param>
//        /// <returns></returns>
//        public string GetURL(string path) => JSRef!.Call<string>("getURL", path);
//        /// <summary>
//        /// Opens your extension's options page.
//        /// </summary>
//        public Task OpenOptionsPage() => JSRef!.CallVoidAsync("openOptionsPage");
//        /// <summary>
//        /// Gets the complete manifest.json file, serialized as an object.
//        /// </summary>
//        /// <returns></returns>
//        public JSObject GetManifest() => JSRef!.Call<JSObject>("getManifest");
//        /// <summary>
//        /// Reloads the extension.
//        /// </summary>
//        public void Reload() => JSRef!.CallVoid("reload");
//        /// <summary>
//        /// Establishes a connection from a content script to the main extension process, or from one extension to a different extension.
//        /// </summary>
//        /// <returns></returns>
//        public Port Connect() => JSRef!.Call<Port>("connect");
//        /// <summary>
//        /// Establishes a connection from a content script to the main extension process, or from one extension to a different extension.
//        /// </summary>
//        /// <param name="connectInfo"></param>
//        /// <returns></returns>
//        public Port Connect(ConnectInfo connectInfo) => JSRef!.Call<Port>("connect", connectInfo);
//        /// <summary>
//        /// Establishes a connection from a content script to the main extension process, or from one extension to a different extension.
//        /// </summary>
//        /// <param name="extensionId"></param>
//        /// <returns></returns>
//        public Port Connect(string extensionId) => JSRef!.Call<Port>("connect", extensionId);
//        /// <summary>
//        /// Establishes a connection from a content script to the main extension process, or from one extension to a different extension.
//        /// </summary>
//        /// <param name="extensionId"></param>
//        /// <param name="connectInfo"></param>
//        /// <returns></returns>
//        public Port Connect(string extensionId, ConnectInfo connectInfo) => JSRef!.Call<Port>("connect", extensionId, connectInfo);
//        /// <summary>
//        /// Sends a single message to event listeners within your extension or a different extension. Similar to runtime.connect but only sends a single message, with an optional response.
//        /// </summary>
//        /// <param name="message"></param>
//        /// <returns></returns>
//        public Task SendMessage(object message) => JSRef!.CallVoidAsync("sendMessage", message);
//        /// <summary>
//        /// Sends a single message to event listeners within your extension or a different extension. Similar to runtime.connect but only sends a single message, with an optional response.
//        /// </summary>
//        /// <param name="extensionId"></param>
//        /// <param name="message"></param>
//        /// <returns></returns>
//        public Task SendMessage(string extensionId, object message) => JSRef!.CallVoidAsync("sendMessage", extensionId, message);
//        /// <summary>
//        /// Sends a single message to event listeners within your extension or a different extension. Similar to runtime.connect but only sends a single message, with an optional response.
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="message"></param>
//        /// <returns></returns>
//        public Task<T> SendMessage<T>(object message) => JSRef!.CallAsync<T>("sendMessage", message);
//        /// <summary>
//        /// Sends a single message to event listeners within your extension or a different extension. Similar to runtime.connect but only sends a single message, with an optional response.
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="extensionId"></param>
//        /// <param name="message"></param>
//        /// <returns></returns>
//        public Task<T> SendMessage<T>(string extensionId, object message) => JSRef!.CallAsync<T>("sendMessage", extensionId, message);
//        #region Events
//        /// <summary>
//        /// The function called when this event occurs. The function is passed these arguments:<br />
//        /// StorageChanges changes - Object describing the change. This object contains properties for all the keys in the storage area included in the storageArea.set call, even if key values are unchanged. The name of each property is the name of each key. The value of each key is a storage.StorageChange object describing the change to that item.<br />
//        /// </summary>
//        public JSEventCallback<JSObject, MessageSender, Function?> OnMessage { get => new JSEventCallback<JSObject, MessageSender, Function?>(o => JSRef!.CallVoid("onMessage.addListener", o), o => JSRef!.CallVoid("onMessage.removeListener", o)); set { } }
//        /// <summary>
//        /// Fired when a connection is made with either an extension process or a content script.
//        /// </summary>
//        public JSEventCallback<Port> OnConnect { get => new JSEventCallback<Port>(o => JSRef!.CallVoid("onConnect.addListener", o), o => JSRef!.CallVoid("onConnect.removeListener", o)); set { } }
//        /// <summary>
//        /// Fired when a profile that has this extension installed first starts up. This event is not fired when an incognito profile is started.
//        /// </summary>
//        public ObservableExtensionEvent onStartup { get => JSRef!.Get<ObservableExtensionEvent>("onStartup"); set { } }
//        /// <summary>
//        /// Fired when the extension is first installed, when the extension is updated to a new version, and when the browser is updated to a new version.
//        /// </summary>
//        public ObservableExtensionEvent onInstalled { get => JSRef!.Get<ObservableExtensionEvent>("onInstalled"); set { } }
//        /// <summary>
//        /// Sent to the event page just before the extension is unloaded. This gives the extension an opportunity to do some cleanup.
//        /// </summary>
//        public ObservableExtensionEvent onSuspend { get => JSRef!.Get<ObservableExtensionEvent>("onSuspend"); set { } }
//        /// <summary>
//        /// Sent after runtime.onSuspend to indicate that the extension won't be unloaded after all.
//        /// </summary>
//        public ObservableExtensionEvent onSuspendCanceled { get => JSRef!.Get<ObservableExtensionEvent>("onSuspendCanceled"); set { } }
//        /// <summary>
//        /// Fired when an update is available, but isn't installed immediately because the extension is currently running.
//        /// </summary>
//        public ObservableExtensionEvent onUpdateAvailable { get => JSRef!.Get<ObservableExtensionEvent>("onUpdateAvailable"); set { } }
//        /// <summary>
//        /// Fired when a connection is made with either an extension process or a content script.
//        /// </summary>
//        public ObservableExtensionEvent onConnect { get => JSRef!.Get<ObservableExtensionEvent>("onConnect"); set { } }
//        /// <summary>
//        /// Fired when a connection is made with another extension.
//        /// </summary>
//        public ObservableExtensionEvent onConnectExternal { get => JSRef!.Get<ObservableExtensionEvent>("onConnectExternal"); set { } }
//        /// <summary>
//        /// Fired when a message is sent from either an extension process or a content script.
//        /// </summary>
//        public ObservableExtensionEvent onMessage { get => JSRef!.Get<ObservableExtensionEvent>("onMessage"); set { } }
//        /// <summary>
//        /// Fired when a message is sent from another extension. Cannot be used in a content script.
//        /// </summary>
//        public ObservableExtensionEvent onMessageExternal { get => JSRef!.Get<ObservableExtensionEvent>("onMessageExternal"); set { } }
//        /// <summary>
//        /// Fired when a runtime performance issue is detected for the extension.
//        /// </summary>
//        public ObservableExtensionEvent onPerformanceWarning { get => JSRef!.Get<ObservableExtensionEvent>("onPerformanceWarning"); set { } }
//        /// <summary>
//        /// Fired when the device needs to be restarted.
//        /// </summary>
//        public ObservableExtensionEvent onRestartRequired { get => JSRef!.Get<ObservableExtensionEvent>("onRestartRequired"); set { } }
//        #endregion
//    }
//}
