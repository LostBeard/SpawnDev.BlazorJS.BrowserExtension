using Microsoft.JSInterop;
using SpawnDev.BlazorJS;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    public class StorageChange<T> : JSObject
    {
        public StorageChange(IJSInProcessObjectReference _ref) : base(_ref) { }
        public T OldValue<T>() => JSRef.Get<T>("oldValue");
        public T NewValue<T>() => JSRef.Get<T>("newValue");
    }
    public class StorageChanges : JSObject
    {
        public StorageChanges(IJSInProcessObjectReference _ref) : base(_ref) { }
        public List<string> Keys => JS.Call<List<string>>("Object.keys", JSRef);
        public StorageChange<T> Get<T>(string key) => JSRef.Get<StorageChange<T>>(key);
    }
}
