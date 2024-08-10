using Microsoft.JSInterop;
using SpawnDev.BlazorJS.IJSInProcessObjectReferenceAnyKey;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// A Port object represents one end of a connection between two specific contexts, which can be used to exchange messages.<br/>
    /// One side initiates the connection, using a connect() API. This returns a Port object. The other side listens for connection attempts using an onConnect listener. This is passed a corresponding Port object.<br/>
    /// Once both sides have Port objects, they can exchange messages using Port.postMessage() and Port.onMessage. When they are finished, either end can disconnect using Port.disconnect(), which will generate a Port.onDisconnect event at the other end, enabling the other end to do any cleanup required.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime/Port
    /// </summary>
    public class Port : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Port(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// string. The port's name, defined in the runtime.connect() or tabs.connect() call that created it. If this port is connected to a native application, its name is the name of the native application.
        /// </summary>
        public string? Name => JSRef!.Get<string>("name");
        /// <summary>
        /// runtime.MessageSender. Contains information about the sender of the message. This property will only be present on ports passed to onConnect/onConnectExternal listeners.
        /// </summary>
        public MessageSender? Sender => JSRef!.Get<MessageSender?>("sender");
        /// <summary>
        /// function. Send a message to the other end. This takes one argument, which is a serializable value (see Data cloning algorithm) representing the message to send. It will be delivered to any script listening to the port's onMessage event, or to the native application if this port is connected to a native application.
        /// </summary>
        /// <param name="message"></param>
        public void PostMessage(object message) => JSRef!.CallVoid("postMessage", message);
        /// <summary>
        /// object. If the port was disconnected due to an error, this will be set to an object with a string property message, giving you more information about the error. See onDisconnect.
        /// </summary>
        public Error? Error => JSRef!.Get<Error>("error");
        /// <summary>
        /// function. Disconnects a port. Either end can call this when they have finished with the port. It will cause onDisconnect to be fired at the other end. This is useful if the other end is maintaining some state relating to this port, which can be cleaned up on disconnect. If this port is connected to a native application, this function will close the native application.
        /// </summary>
        public void Disconnect() => JSRef!.CallVoid("disconnect");
        /// <summary>
        /// object. This contains the addListener() and removeListener() functions common to all events for extensions built using WebExtension APIs. Listener functions will be called when the other end has called Port.disconnect(). This event will only be fired once for each port. The listener function will be passed the Port object. If the port was disconnected due to an error, then the Port argument will contain an error property giving more information about the error:
        /// </summary>
        public ActionEvent<Port> OnDisconnect { get => JSRef!.Get<ActionEvent<Port>>("onDisconnect"); set { } }
        /// <summary>
        /// object. This contains the addListener() and removeListener() functions common to all events for extensions built using WebExtension APIs. Listener functions will be called when the other end has sent this port a message. The listener will be passed the value that the other end sent.
        /// </summary>
        public ActionEvent<JSObject> OnMessage { get => JSRef!.Get<ActionEvent<JSObject>>("onMessage"); set { } }
    }
}
