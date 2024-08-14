using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// WrappedObjectProxy is a Javascript Proxy object that allows working with objects on website Javascript objects over a content bridge
    /// </summary>
    public class WrappedObjectProxy : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WrappedObjectProxy(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The InstanceID of the content bridge dispatcher that owns the proxy
        /// </summary>
        public string? DispatcherId => JSRef!.Get<string?>("__wrappedObjectDispatcherId");
        #region Methods
        /// <summary>
        /// Releases the wrapped object proxy
        /// </summary>
        /// <returns></returns>
        public bool Release() => JSRef!.Call<bool>("__wrappedObjectRelease");
        /// <summary>
        /// Returns the remote object as type T after a JSON.parse(JSON.stringify(data))<br />
        /// This can aid in retrieving a copy of a remote object that otherwise would be blocked by the browser<br />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Decon<T>() => JSRef!.Call<T>("__wrappedObjectDecon");
        /// <summary>
        /// Returns the remote object as type T<br />
        /// The browser extension environment may block the request, which will cause an exception to be thrown<br />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Direct<T>() => JSRef!.Call<T>("__wrappedObjectDirect");
        #endregion
        #region Static Methods
        /// <summary>
        /// Get WrappedObjectProxy from a JSObject
        /// </summary>
        /// <param name="_ref"></param>
        /// <returns></returns>
        public static WrappedObjectProxy GetWrappedObjectProxy(JSObject _ref) => _ref.JSRefCopy<WrappedObjectProxy>();
        /// <summary>
        /// Returns true if the Javascript object is a WrappedObjectProxy
        /// </summary>
        /// <param name="jsObject"></param>
        /// <returns></returns>
        public static bool IsWrappedObjectProxy(JSObject jsObject) => !string.IsNullOrEmpty(jsObject.JSRef!.Get<string?>("__wrappedObjectDispatcherId"));
        #endregion
    }
}
