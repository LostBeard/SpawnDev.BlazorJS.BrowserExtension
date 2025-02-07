using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Information sent when a context menu item is clicked.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/contextMenus#type-OnClickData<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/menus/OnClickData
    /// </summary>
    public class OnClickData : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public OnClickData(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// integer. Which mouse button was pressed. The values are the same as for MouseEvent.button.<br/>
        /// (Firefox)
        /// </summary>
        public int? Button => JSRef!.Get<int?>("button");
        /// <summary>
        /// string. The ID of the bookmark where the context menu was clicked.<br/>
        /// (Firefox
        /// </summary>
        public string? BookmarkId => JSRef!.Get<string?>("bookmarkId");
        /// <summary>
        /// A flag indicating the state of a checkbox or radio item after it is clicked.
        /// </summary>
        public bool? Checked => JSRef!.Get<bool?>("checked");
        /// <summary>
        /// A flag indicating whether the element is editable (text input, textarea, etc.).
        /// </summary>
        public bool? Editable => JSRef!.Get<bool?>("editable");
        /// <summary>
        /// integer. The ID of the frame in which the item was clicked. The frame ID can be used in other APIs that accept frame IDs, such as tabs.sendMessage(). If the item was clicked in the top level document, frameId is zero. If the item was clicked outside the page entirely (for example, in the tools_menu or tab context), then frameId is undefined.
        /// </summary>
        public int? FrameId => JSRef!.Get<int?>("frameId");
        /// <summary>
        /// string. The URL of the frame of the element where the context menu was clicked, if it was in a frame.
        /// </summary>
        public string? FrameUrl => JSRef!.Get<string?>("frameUrl");
        /// <summary>
        /// If the element is a link, the URL it points to.
        /// </summary>
        public string? LinkUrl => JSRef!.Get<string?>("linkUrl");
        /// <summary>
        /// string. If the element is a link, the text for the link. If the link contains no text, the URL itself is given here.<br/>
        /// (Firefox)
        /// </summary>
        public string? LinkText => JSRef!.Get<string?>("linkText");
        /// <summary>
        /// One of 'image', 'video', or 'audio' if the context menu was activated on one of these types of elements.
        /// </summary>
        public string? MediaType => JSRef!.Get<string?>("mediaType");
        /// <summary>
        /// The ID of the menu item that was clicked.<br/>
        /// read as a string
        /// </summary>
        public string? MenuItemId => JSRef!.Get<string?>("menuItemId");
        /// <summary>
        /// array of string. An array containing any modifier keys that were pressed when the item was clicked. Possible values are: "Alt", "Command", "Ctrl", "MacCtrl", and "Shift". On a Mac, if the user has the Control key pressed, then both "Ctrl" and "MacCtrl" are included.<br/>
        /// (Firefox)
        /// </summary>
        public string[]? Modifiers => JSRef!.Get<string[]?>("modifiers");
        /// <summary>
        /// The ID of the menu item that was clicked.<br/>
        /// read as an int
        /// </summary>
        public int? MenuItemIdI => JSRef!.Get<int?>("menuItemId");
        /// <summary>
        /// The URL of the page where the menu item was clicked. This property is not set if the click occured in a context where there is no current page, such as in a launcher context menu.
        /// </summary>
        public string? PageUrl => JSRef!.Get<string?>("pageUrl");
        /// <summary>
        /// The parent ID, if any, for the item clicked.<br/>
        /// read as an string
        /// </summary>
        public string? ParentMenuId => JSRef!.Get<string?>("parentMenuId");
        /// <summary>
        /// The parent ID, if any, for the item clicked.<br/>
        /// read as an int
        /// </summary>
        public int? ParentMenuIdI => JSRef!.Get<int?>("parentMenuId");
        /// <summary>
        /// The text for the context selection, if any.
        /// </summary>
        public string? SelectionText => JSRef!.Get<string?>("selectionText");
        /// <summary>
        /// Will be present for elements with a 'src' URL.
        /// </summary>
        public string? SrcUrl => JSRef!.Get<string?>("srcUrl");
        /// <summary>
        /// integer. An identifier of the element, if any, over which the context menu was created. Use menus.getTargetElement() in the content script to locate the element. Note that this is not the id attribute of the page element.<br/>
        /// (Firefox)
        /// </summary>
        public int? TargetElementId => JSRef!.Get<int?>("targetElementId");
        /// <summary>
        /// ViewType. The type of extension view.<br/>
        /// (Firefox)
        /// </summary>
        public string? ViewType => JSRef!.Get<string?>("viewType");
        /// <summary>
        /// A flag indicating the state of a checkbox or radio item before it was clicked.
        /// </summary>
        public bool? WasChecked => JSRef!.Get<bool?>("wasChecked");
    }
}
