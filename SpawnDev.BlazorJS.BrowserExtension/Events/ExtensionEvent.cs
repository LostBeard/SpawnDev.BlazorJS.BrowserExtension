using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// An extension event
    /// </summary>
    public class ExtensionEvent : JSObject
    {
        /// <summary>
        /// Contains Callback references that will be disposed when an equal number of add and remove listener calls are made
        /// </summary>
        protected static CallbackRef CallbackRef = new();
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ExtensionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Check whether listener is registered for this event. Returns true if it is listening, false otherwise.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public bool HasListener(Callback callback) => JSRef!.Call<bool>("hasListener", callback);
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public void AddListener(Callback callback) => JSRef!.CallVoid("addListener", callback);
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        /// <param name="callback"></param>
        public void RemoveListener(Callback callback) => JSRef!.CallVoid("removeListener", callback);
    }
}
