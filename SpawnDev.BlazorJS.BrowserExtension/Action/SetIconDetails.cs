using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// object. An object containing the imageData or path property and, optionally, either or both of the tabId and windowId properties.<br/>
    /// - If windowId and tabId are both supplied, the function fails and the icon is not set.<br/>
    /// - If windowId and tabId are both omitted, the global icon is set.<br/>
    /// If each one of imageData and path is one of undefined, null or empty object:<br/>
    /// - If tabId is specified, and the tab has a tab-specific icon set, then the tab will inherit the icon from the window to which it belongs.<br/>
    /// - If windowId is specified, and the window has a window-specific icon set, then the window will inherit the global icon.<br/>
    /// - Otherwise, the global icon will be reset to the manifest icon.
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/setIcon#details
    /// </summary>
    public class SetIconDetails
    {
        /// <summary>
        /// action.ImageDataType or object. This is either a single ImageData object or a dictionary object.<br/>
        /// Use a dictionary object to specify multiple ImageData objects in different sizes, so the icon does not have to be scaled for a device with a different pixel density. If imageData is a dictionary, the value of each property is an ImageData object, and its name is its size.<br/>
        /// The browser will choose the image to use depending on the screen's pixel density. See Choosing icon sizes for more information on this.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<ImageData, Dictionary<int, ImageData>>? ImageDataType { get; set; }
        /// <summary>
        /// string or object. This is either a relative path to an icon file or it is a dictionary object.<br/>
        /// Use a dictionary object to specify multiple icon files in different sizes, so the icon does not have to be scaled for a device with a different pixel density. If path is a dictionary, the value of each property is a relative path, and its name is its size.<br/>
        /// The browser will choose the image to use depending on the screen's pixel density. See Choosing icon sizes for more information on this.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<string, Dictionary<int, string>>? Path { get; set; }
        /// <summary>
        /// integer. Sets the icon only for the given tab. The icon is reset when the user navigates this tab to a new page.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// integer. Sets the icon for the given window.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
