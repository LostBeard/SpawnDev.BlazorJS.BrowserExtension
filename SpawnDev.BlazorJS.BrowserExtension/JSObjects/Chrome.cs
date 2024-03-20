using Microsoft.JSInterop;
using SpawnDev.BlazorJS;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    public class Chrome : JSObject
    {
        public Chrome(IJSInProcessObjectReference _ref) : base(_ref) { }

        public ChromeRuntime? Runtime => JSRef.Get<ChromeRuntime?>("runtime");
        public ChromeStorage? Storage => JSRef.Get<ChromeStorage?>("storage");
    }
}
