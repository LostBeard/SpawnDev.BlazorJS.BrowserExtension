using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// Extension event
    /// </summary>
    public class ObservableExtensionEvent : JSObject
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ObservableExtensionEvent operator +(ObservableExtensionEvent a, Callback b)
        {
            a.AddListener(b);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ObservableExtensionEvent operator -(ObservableExtensionEvent a, Callback b)
        {
            a.RemoveListener(b);
            return a;
        }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ObservableExtensionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(Callback callback) => JSRef!.CallVoid("addListener", callback);
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void RemoveListener(Callback callback) => JSRef!.CallVoid("removeListener", callback);
        /// <summary>
        /// Check whether listener is registered for this event. Returns true if it is listening, false otherwise.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public virtual bool HasListener(Callback callback) => JSRef!.Call<bool>("hasListener", callback);
    }
}
