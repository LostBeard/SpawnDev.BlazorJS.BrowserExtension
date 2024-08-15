using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    public class WebRequestEvent : JSObject
    {
        /// <summary>
        /// Contains Callback references that will be disposed when an equal number of add and remove listener calls are made
        /// </summary>
        protected static CallbackRef CallbackRef = new();
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebRequestEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        public void AddListener(Callback callback, RequestFilter requestFilter) => JSRef!.CallVoid("addListener", callback, requestFilter);
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        public void AddListener(Callback callback, RequestFilter requestFilter, string[] extraInfoSpec) => JSRef!.CallVoid("addListener", callback, requestFilter, extraInfoSpec);
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        public void AddListener(Action<WebRequestDetails> callback, RequestFilter requestFilter) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback), requestFilter);
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        public void AddListener(Action<WebRequestDetails> callback, RequestFilter requestFilter, string[] extraInfoSpec) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback), requestFilter, extraInfoSpec);
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        public void AddListener(Func<WebRequestDetails, BlockingResponse> callback, RequestFilter requestFilter) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback), requestFilter);
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        public void AddListener(Func<WebRequestDetails, BlockingResponse> callback, RequestFilter requestFilter, string[] extraInfoSpec) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback), requestFilter, extraInfoSpec);
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        public void AddListener(Func<WebRequestDetails, Task<BlockingResponse?>> callback, RequestFilter requestFilter) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback), requestFilter);
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        public void AddListener(Func<WebRequestDetails, Task<BlockingResponse?>> callback, RequestFilter requestFilter, string[] extraInfoSpec) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback), requestFilter, extraInfoSpec);
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        public void AddListener(Func<WebRequestDetails, Task> callback, RequestFilter requestFilter) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback), requestFilter);
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        public void AddListener(Func<WebRequestDetails, Task> callback, RequestFilter requestFilter, string[] extraInfoSpec) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback), requestFilter, extraInfoSpec);
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public void RemoveListener(Callback callback) => JSRef!.CallVoid("removeListener", callback);
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public void RemoveListener(Func<WebRequestDetails, Task<BlockingResponse?>> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            RemoveListener(callback);
            CallbackRef.RefDel(listener);
        }
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public void RemoveListener(Func<WebRequestDetails, Task> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            RemoveListener(callback);
            CallbackRef.RefDel(listener);
        }
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public void RemoveListener(Func<WebRequestDetails, BlockingResponse> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            RemoveListener(callback);
            CallbackRef.RefDel(listener);
        }
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public void RemoveListener(Action<WebRequestDetails> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            RemoveListener(callback);
            CallbackRef.RefDel(listener);
        }
    }
}
