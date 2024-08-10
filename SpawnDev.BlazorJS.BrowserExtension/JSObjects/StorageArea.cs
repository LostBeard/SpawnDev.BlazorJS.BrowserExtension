using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// StorageArea is an object representing a storage area.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/storage/StorageArea
    /// </summary>
    public class StorageArea : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public StorageArea(IJSInProcessObjectReference _ref) : base(_ref) { }

        #region Methods
        /// <summary>
        /// Gets the amount of storage space (in bytes) used one or more items being stored in the storage area.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public Task<long> GetBytesInUse(params string[] keys) => JSRef!.CallAsync<long>("getBytesInUse", keys);

        public Task<long> Remove(params string[] keys) => JSRef!.CallAsync<long>("remove", keys);

        public Task Clear() => JSRef!.CallVoidAsync("clear");

        public async Task<List<string>> GetKeys()
        {
            using var all = await JSRef!.CallAsync<JSObject>("get");
            var keys = JS.Call<List<string>>("Object.keys", all);
            return keys;
        }

        public Task SetAccessLevel(string accessLevel) => JSRef!.CallVoidAsync("setAccessLevel", accessLevel);

        public async Task<T> Get<T>(string key)
        {
            using var tmp = await JSRef!.CallAsync<JSObject?>("get", key);
            if (tmp == null || tmp.JSRef!.IsUndefined(key)) return default(T);
            return tmp.JSRef!.Get<T>(key);
        }
        public async Task<T> Get<T>(string key, T defaultValue)
        {
            using var tmp = await JSRef!.CallAsync<JSObject?>("get", key);
            if (tmp == null || tmp.JSRef!.IsUndefined(key)) return defaultValue;
            return tmp.JSRef!.Get<T>(key);
        }
        public async Task<bool> Exists(string key)
        {
            using var tmp = await JSRef!.CallAsync<JSObject?>("get", key);
            return tmp != null && !tmp.JSRef!.IsUndefined(key);
        }

        public Task Set(string key, object value) => JSRef!.CallVoidAsync("set", new Dictionary<string, object> { { key, value } });
        #endregion

        #region Events
        /// <summary>
        /// The function called when this event occurs. The function is passed these arguments:<br />
        /// StorageChanges changes - Object describing the change. This object contains properties for all the keys in the storage area included in the storageArea.set call, even if key values are unchanged. The name of each property is the name of each key. The value of each key is a storage.StorageChange object describing the change to that item.<br />
        /// </summary>
        public ActionEvent<StorageChanges> OnChanged { get => JSRef!.Get<ActionEvent<StorageChanges>>("onChanged"); set { } }
        #endregion
    }
}
