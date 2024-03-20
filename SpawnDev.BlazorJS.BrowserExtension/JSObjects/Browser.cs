using Microsoft.JSInterop;
using SpawnDev.BlazorJS;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    public class Browser : JSObject
    {
        public Browser(IJSInProcessObjectReference _ref) : base(_ref) { }

        public BrowserRuntime? Runtime => JSRef?.Get<BrowserRuntime>("runtime");
    
    }
}
