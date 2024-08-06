using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Enables accessing the website Javascript scope from the extension side in a content script or page
    /// </summary>
    public class ExtensionContentBridge : JSObject
    {
        /// <summary>
        /// Creates a new instance of ExtensionContentBridge
        /// </summary>
        /// <param name="options"></param>
        public ExtensionContentBridge(ExtensionContentBridgeOptions options) : base(JS.New(nameof(ExtensionContentBridge), options)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ExtensionContentBridge(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Enables sharing resources from this side with the other side<br />
        /// WARNING: This should not be enabled on the extension side<br />
        /// setter is disabled here to discourage setting true
        /// </summary>
        public bool Serve { get => JSRef!.Get<bool>("serve"); set { } }
        /// <summary>
        /// Gets a proxied instance of window
        /// </summary>
        /// <returns></returns>
        public Window GetWindow() => GetGlobal<Window>("window");
        /// <summary>
        /// Get a global property value of type T from the remote global scope
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public T GetGlobal<T>(string identifier) => JSRef!.Call<T>("getGlobal", identifier);
        /// <summary>
        /// Call a method on the remote scope with a return value of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public T CallGlobal<T>(string identifier) => JSRef!.Call<T>("callGlobal", identifier);
        /// <summary>
        /// Call a method on the remote scope with no return value
        /// </summary>
        /// <param name="identifier"></param>
        public void CallGlobalVoid(string identifier) => JSRef!.CallVoid("callGlobal", identifier);
        /// <summary>
        /// Call an async method on the remote scope with a return value of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Task<T> CallGlobalAsync<T>(string identifier) => JSRef!.CallAsync<T>("callGlobal", identifier);
        /// <summary>
        /// Call an async method on the remote scope with no return value
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Task CallGlobalVoidAsync(string identifier) => JSRef!.CallVoidAsync("callGlobal", identifier);
        /// <summary>
        /// Set a value on the remote global scope
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        public void SetGlobal(string identifier, object value) => JSRef!.CallVoid("setGlobal", identifier, value);
        /// <summary>
        /// Delete a property from the remote glboal scope
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public bool DeleteGlobal(string identifier) => JSRef!.Call<bool>("deleteGlobal", identifier);
        /// <summary>
        /// Releases all resources for the given proxied object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Release(JSObject obj) => JSRef!.Call<bool>("release", obj);
        /// <summary>
        /// Creates a selector string for the given element usable with document.querySelector()<br />
        /// The selector string may not be valid after any DOM changes but is useful as a reference to an element that can be passed across content scopes
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string MakeQuerySelector(Node node) => JSRef!.Call<string>("makeQuerySelector", node);
        /// <summary>
        /// Returns the same document element from the website side which allows accessing any owned Javascript variables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node1"></param>
        /// <returns></returns>
        public T? GetDocumentElementRemote<T>(T node1) where T : Element
        {
            using var node = node1.JSRefCopy<T>();
            if (node == null) return null;
            var selector = MakeQuerySelector(node);
            using var d = GetGlobal<Document>("document");
            var el = d.QuerySelector<T>(selector);
            d.WrappedObjectRelease();
            return el;
        }
    }
}
