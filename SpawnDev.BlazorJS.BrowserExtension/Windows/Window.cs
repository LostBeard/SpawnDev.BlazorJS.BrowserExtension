using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Information about a browser window.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/windows/Window
    /// </summary>
    //public partial class Windows;
    public class Window : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Window(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// boolean. Whether the window is set to be always on top.
        /// </summary>
        public bool AlwaysOnTop => JSRef!.Get<bool>("alwaysOnTop");
        /// <summary>
        /// boolean. Whether the window is currently the focused window.
        /// </summary>
        public bool Focused => JSRef!.Get<bool>("focused");
        /// <summary>
        /// integer. The height of the window, including the frame, in pixels.
        /// </summary>
        public int? Height => JSRef!.Get<int?>("height");
        /// <summary>
        /// integer. The ID of the window. Window IDs are unique within a browser session.
        /// </summary>
        public int? Id => JSRef!.Get<int?>("id");
        /// <summary>
        /// boolean. Whether the window is incognito (private).
        /// </summary>
        public bool Incognito => JSRef!.Get<bool>("incognito");
        /// <summary>
        /// integer. The offset of the window from the left edge of the screen in pixels.
        /// </summary>
        public int? Left => JSRef!.Get<int?>("left");
        /// <summary>
        /// string. The session ID used to uniquely identify a Window obtained from the sessions API.
        /// </summary>
        public string? SessionId => JSRef!.Get<string?>("sessionId");
        /// <summary>
        /// A windows.WindowState value representing the state of this browser window — maximized, minimized, etc.
        /// </summary>
        public EnumString<WindowState>? State => JSRef!.Get<EnumString<WindowState>?>("state");
        /// <summary>
        /// Array of tabs.Tab objects representing the current tabs in the window.
        /// </summary>
        public Array<Tab>? Tabs => JSRef!.Get<Array<Tab>?>("tabs");
        /// <summary>
        /// The title of the browser window. Requires "tabs" permission or host permissions for the active tab's URL. Read only.
        /// </summary>
        public string? Title => JSRef!.Get<string?>("title");
        /// <summary>
        /// integer. The offset of the window from the top edge of the screen in pixels.
        /// </summary>
        public int? Top => JSRef!.Get<int?>("top");
        /// <summary>
        /// A windows.WindowType value representing the type of browser window this is — normal browser window, popup, etc.
        /// </summary>
        public EnumString<WindowType>? Type => JSRef!.Get<EnumString<WindowType>?>("type");
        /// <summary>
        /// integer. The width of the window, including the frame, in pixels.
        /// </summary>
        public int? Width => JSRef!.Get<int?>("width");
    }
}
