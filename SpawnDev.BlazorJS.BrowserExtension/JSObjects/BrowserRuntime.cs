using Microsoft.JSInterop;
using SpawnDev.BlazorJS;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    public class BrowserRuntime : JSObject
    {
        public BrowserRuntime(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string? Id => JSRef.Get<string>("id");
        public string GetURL(string path) => JSRef.Call<string>("getURL", path);
    }
}
