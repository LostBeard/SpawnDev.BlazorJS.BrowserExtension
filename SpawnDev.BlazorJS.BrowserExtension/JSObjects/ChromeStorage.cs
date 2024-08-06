using Microsoft.JSInterop;
using SpawnDev.BlazorJS;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// Enables extensions to store and retrieve data, and listen for changes to stored items.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/storage
    /// </summary>
    public class ChromeStorage : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ChromeStorage(IJSInProcessObjectReference _ref) : base(_ref) { }
        public StorageArea Sync => JSRef!.Get<StorageArea>("sync");
        /// <summary>
        /// Represents the local storage area. Items in local storage are local to the machine the extension was installed on.
        /// </summary>
        public StorageArea Local => JSRef!.Get<StorageArea>("local");
        public StorageArea Managed => JSRef!.Get<StorageArea>("managed");
        public StorageArea Session => JSRef!.Get<StorageArea>("session");


        #region Events
        /// <summary>
        /// The function called when this event occurs. The function is passed these arguments:<br />
        /// StorageChanges changes - Object describing the change. This object contains properties for all the keys in the storage area included in the storageArea.set call, even if key values are unchanged. The name of each property is the name of each key. The value of each key is a storage.StorageChange object describing the change to that item.<br />
        /// string areaName - string. The name of the storage area ("sync", "local", or "managed") to which the changes were made.
        /// </summary>
        public JSEventCallback<StorageChanges, string> OnChanged { get => new JSEventCallback<StorageChanges, string>(o => JSRef.CallVoid("onChanged.addListener", o), o => JSRef.CallVoid("onChanged.removeListener", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        #endregion
    }
}
