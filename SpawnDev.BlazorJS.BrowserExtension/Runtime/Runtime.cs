using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    public class EnumStringConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }
        /// <summary>
        /// Reads the type value from the Json reader
        /// </summary>
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var valueString = JsonSerializer.Deserialize<string?>(ref reader);
            if (string.IsNullOrEmpty(valueString)) return default;
            var enumString = new EnumString<T>(valueString);
            return enumString.Enum ?? default;
        }
        /// <summary>
        /// Writes the type value to the Json reader
        /// </summary>
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var enumString = new EnumString<T>(value);
            JsonSerializer.Serialize(writer, enumString == null ? null : enumString.String);
        }
    }
    /// <summary>
    /// This module provides information about your extension and the environment it's running in.<br/>
    /// It also provides messaging APIs enabling you to:<br/>
    /// - Communicate between different parts of your extension. For advice on choosing between the messaging options, see Choosing between one-off messages and connection-based messaging.<br/>
    /// - Communicate with other extensions.<br/>
    /// - Communicate with native applications.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/runtime
    /// </summary>
    public class Runtime : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Runtime(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The ID of the extension.
        /// </summary>
        public string? Id => JSRef!.Get<string?>("id");
        /// <summary>
        /// This value is set when an asynchronous function has an error condition that it needs to report to its caller.
        /// </summary>
        public Error? LastError => JSRef!.Get<Error?>("lastError");
        #region Methods
        /// <summary>
        /// Retrieves the Window object for the background page running inside the current extension.
        /// </summary>
        /// <returns></returns>
        public Task<Window?> GetBackgroundPage() => JSRef!.CallAsync<Window?>("getBackgroundPage");
        /// <summary>
        /// Opens your extension's options page.
        /// </summary>
        public Task OpenOptionsPage() => JSRef!.CallVoidAsync("openOptionsPage");
        /// <summary>
        /// Given a relative path from the manifest.json to a resource packaged with the extension, returns a fully-qualified URL.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetURL(string path) => JSRef!.Call<string>("getURL", path);
        /// <summary>
        /// Gets the complete manifest.json file, serialized as an object.
        /// </summary>
        /// <returns></returns>
        public JSObject GetManifest() => JSRef!.Call<JSObject>("getManifest");
        /// <summary>
        /// Reloads the extension.
        /// </summary>
        public void Reload() => JSRef!.CallVoid("reload");
        /// <summary>
        /// Establishes a connection from a content script to the main extension process, or from one extension to a different extension.
        /// </summary>
        /// <returns></returns>
        public Port Connect() => JSRef!.Call<Port>("connect");
        /// <summary>
        /// Establishes a connection from a content script to the main extension process, or from one extension to a different extension.
        /// </summary>
        /// <param name="connectInfo"></param>
        /// <returns></returns>
        public Port Connect(ConnectInfo connectInfo) => JSRef!.Call<Port>("connect", connectInfo);
        /// <summary>
        /// Establishes a connection from a content script to the main extension process, or from one extension to a different extension.
        /// </summary>
        /// <param name="extensionId"></param>
        /// <returns></returns>
        public Port Connect(string extensionId) => JSRef!.Call<Port>("connect", extensionId);
        /// <summary>
        /// Establishes a connection from a content script to the main extension process, or from one extension to a different extension.
        /// </summary>
        /// <param name="extensionId"></param>
        /// <param name="connectInfo"></param>
        /// <returns></returns>
        public Port Connect(string extensionId, ConnectInfo connectInfo) => JSRef!.Call<Port>("connect", extensionId, connectInfo);
        /// <summary>
        /// Sends a single message to event listeners within your extension or a different extension. Similar to runtime.connect but only sends a single message, with an optional response.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessage(object message) => JSRef!.CallVoidAsync("sendMessage", message);
        /// <summary>
        /// Sends a single message to event listeners within your extension or a different extension. Similar to runtime.connect but only sends a single message, with an optional response.
        /// </summary>
        /// <param name="extensionId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessage(string extensionId, object message) => JSRef!.CallVoidAsync("sendMessage", extensionId, message);
        /// <summary>
        /// Sends a single message to event listeners within your extension or a different extension. Similar to runtime.connect but only sends a single message, with an optional response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task<T> SendMessage<T>(object message) => JSRef!.CallAsync<T>("sendMessage", message);
        /// <summary>
        /// Sends a single message to event listeners within your extension or a different extension. Similar to runtime.connect but only sends a single message, with an optional response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="extensionId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task<T> SendMessage<T>(string extensionId, object message) => JSRef!.CallAsync<T>("sendMessage", extensionId, message);
        #endregion
        #region Events
        /// <summary>
        /// Fired when a profile that has this extension installed first starts up. This event is not fired when an incognito profile is started.
        /// </summary>
        public ActionEvent OnStartup { get => JSRef!.Get<ActionEvent>("onStartup"); set { } }
        /// <summary>
        /// Fired when the extension is first installed, when the extension is updated to a new version, and when the browser is updated to a new version.
        /// </summary>
        public ActionEvent<OnInstalledDetails> OnInstalled { get => JSRef!.Get<ActionEvent<OnInstalledDetails>>("onInstalled"); set { } }
        /// <summary>
        /// Sent to the event page just before the extension is unloaded. This gives the extension an opportunity to do some cleanup.
        /// </summary>
        public ActionEvent OnSuspend { get => JSRef!.Get<ActionEvent>("onSuspend"); set { } }
        /// <summary>
        /// Sent after runtime.onSuspend to indicate that the extension won't be unloaded after all.
        /// </summary>
        public ActionEvent OnSuspendCanceled { get => JSRef!.Get<ActionEvent>("onSuspendCanceled"); set { } }
        /// <summary>
        /// Fired when an update is available, but isn't installed immediately because the extension is currently running.
        /// </summary>
        public ActionEvent OnUpdateAvailable { get => JSRef!.Get<ActionEvent>("onUpdateAvailable"); set { } }
        /// <summary>
        /// Fired when a connection is made with either an extension process or a content script.
        /// </summary>
        public ActionEvent<Port> OnConnect { get => JSRef!.Get<ActionEvent<Port>>("onConnect"); set { } }
        /// <summary>
        /// Fired when a connection is made with another extension.
        /// </summary>
        public ActionEvent<Port> OnConnectExternal { get => JSRef!.Get<ActionEvent<Port>>("onConnectExternal"); set { } }
        /// <summary>
        /// Fired when a message is sent from either an extension process or a content script.<br/>
        /// To send a response synchronously, call sendResponse() before the listener function returns.<br/>
        /// To send a response asynchronously, keep a reference to the sendResponse() argument and return true from the listener function. You will then be able to call sendResponse() after the listener function has returned.<br/>
        /// </summary>
        public FuncEvent<JSObject, MessageSender, Function?, bool> OnMessage { get => JSRef!.Get<FuncEvent<JSObject, MessageSender, Function?, bool>>("onMessage"); set { } }
        /// <summary>
        /// Fired when a message is sent from another extension. Cannot be used in a content script.
        /// To send a response synchronously, call sendResponse() before the listener function returns.<br/>
        /// To send a response asynchronously, keep a reference to the sendResponse() argument and return true from the listener function. You will then be able to call sendResponse() after the listener function has returned.<br/>
        /// </summary>
        public FuncEvent<JSObject, MessageSender, Function?, bool> OnMessageExternal { get => JSRef!.Get<FuncEvent<JSObject, MessageSender, Function?, bool>>("onMessageExternal"); set { } }
        /// <summary>
        /// Fired when a runtime performance issue is detected for the extension.
        /// </summary>
        public ActionEvent<OnPerformanceWarningDetails> OnPerformanceWarning { get => JSRef!.Get<ActionEvent<OnPerformanceWarningDetails>>("onPerformanceWarning"); set { } }
        /// <summary>
        /// Fired when the device needs to be restarted.
        /// </summary>
        public ActionEvent<EnumString<OnRestartRequiredReason>> OnRestartRequired { get => JSRef!.Get<ActionEvent<EnumString<OnRestartRequiredReason>>>("onRestartRequired"); set { } }
        #endregion
    }
}
