using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/contextMenus<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/user_interface/Context_menu_items<br/>
    /// </summary>
    public class ContextMenus : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public ContextMenus(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new context menu item. If an error occurs during creation, it may not be detected until the creation callback fires; details will be in runtime.lastError.
        /// </summary>
        /// <param name="createProperties"></param>
        /// <returns>The ID of the newly created item. (number | string)</returns>
        public JSObject Create(MenuItemProperties createProperties) => JSRef!.Call<JSObject>("create", createProperties);
        /// <summary>
        /// Creates a new context menu item. If an error occurs during creation, it may not be detected until the creation callback fires; details will be in runtime.lastError.
        /// </summary>
        /// <param name="createProperties"></param>
        /// <param name="callback"></param>
        /// <returns>The ID of the newly created item. (number | string)</returns>
        public JSObject Create(MenuItemProperties createProperties, ActionCallback callback) => JSRef!.Call<JSObject>("create", createProperties, callback);
        /// <summary>
        /// Removes a context menu item.
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <param name="callback"></param>
        public void Remove(string menuItemId, ActionCallback callback) => JSRef!.CallVoid("remove", menuItemId, callback);
        /// <summary>
        /// Removes a context menu item.
        /// </summary>
        /// <param name="menuItemId"></param>
        public void Remove(int menuItemId) => JSRef!.CallVoid("remove", menuItemId);
        /// <summary>
        /// Removes a context menu item.
        /// </summary>
        /// <param name="menuItemId"></param>
        public void Remove(string menuItemId) => JSRef!.CallVoid("remove", menuItemId);
        /// <summary>
        /// Removes a context menu item.
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <param name="callback"></param>
        public void Remove(int menuItemId, ActionCallback callback) => JSRef!.CallVoid("remove", menuItemId, callback);
        /// <summary>
        /// Removes all context menu items added by this extension.
        /// </summary>
        /// <param name="callback"></param>
        public void RemoveAll(ActionCallback callback) => JSRef!.CallVoid("removeAll", callback);
        /// <summary>
        /// Removes all context menu items added by this extension.
        /// </summary>
        public void RemoveAll() => JSRef!.CallVoid("removeAll");
        /// <summary>
        /// Updates a previously created context menu item.
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <param name="updateProperties"></param>
        /// <param name="callback"></param>
        public void Update(string menuItemId, MenuItemProperties updateProperties, ActionCallback callback) => JSRef!.CallVoid("update", menuItemId, updateProperties, callback);
        /// <summary>
        /// Updates a previously created context menu item.
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <param name="updateProperties"></param>
        public void Update(string menuItemId, MenuItemProperties updateProperties) => JSRef!.CallVoid("update", menuItemId, updateProperties);
        /// <summary>
        /// Updates a previously created context menu item.
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <param name="updateProperties"></param>
        /// <param name="callback"></param>
        public void Update(int menuItemId, MenuItemProperties updateProperties, ActionCallback callback) => JSRef!.CallVoid("update", menuItemId, updateProperties, callback);
        /// <summary>
        /// Updates a previously created context menu item.
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <param name="updateProperties"></param>
        public void Update(int menuItemId, MenuItemProperties updateProperties) => JSRef!.CallVoid("update", menuItemId, updateProperties);
        /// <summary>
        /// Fired when a context menu item is clicked.
        /// </summary>
        public ActionEvent<OnClickData, Tab> OnClicked { get => JSRef!.Get<ActionEvent<OnClickData, Tab>>("onClicked"); set { } }
    }
}
