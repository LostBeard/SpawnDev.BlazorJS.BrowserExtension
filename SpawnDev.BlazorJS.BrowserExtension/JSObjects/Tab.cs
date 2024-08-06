using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// The type tabs.Tab contains information about a tab. This provides access to information about what content is in the tab, how large the content is, what special states or restrictions are in effect, and so forth.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/tabs/Tab
    /// </summary>
    public class Tab : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Tab(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// boolean. Whether the tab is active in its window. This may be true even if the tab's window is not currently focused.<br/>
        /// The active tab is usually the selected one. However, on Firefox for Android, extension popups open in a new tab. When this popup tab is selected, the active tab will instead be the one in which the popup opened.
        /// </summary>
        public bool Active => JSRef!.Get<bool>("active");
        /// <summary>
        /// boolean. Indicates whether the tab is drawing attention. For example, when the tab displays a modal dialog, attention will be true.
        /// </summary>
        public bool? Attention => JSRef!.Get<bool?>("attention");
        /// <summary>
        /// boolean. Indicates whether the tab is producing sound. However, the user will not hear the sound if the tab is muted (see the mutedInfo property).
        /// </summary>
        public bool? Audible => JSRef!.Get<bool?>("audible");
        /// <summary>
        /// boolean. Whether the tab can be discarded by the browser. The default value is true. When set to false, the browser cannot automatically discard the tab. However, the tab can be discarded by tabs.discard.
        /// </summary>
        public bool? AutoDiscardable => JSRef!.Get<bool?>("autoDiscardable");
        /// <summary>
        /// string. The cookie store of the tab. See Work with contextual identities for more information.
        /// </summary>
        public string? CookieStoreId => JSRef!.Get<string?>("cookieStoreId");
        /// <summary>
        /// boolean. Whether the tab is discarded. A discarded tab is one whose content has been unloaded from memory, but is still visible in the tab strip. Its content gets reloaded the next time it's activated.
        /// </summary>
        public bool? Discarded => JSRef!.Get<bool?>("discarded");
        /// <summary>
        /// string. The URL of the tab's favicon. Only present if the extension has the "tabs" permission or host permissions. It may also be undefined if the page has no favicon, or an empty string if the tab is loading.
        /// </summary>
        public string? FavIconUrl => JSRef!.Get<string?>("favIconUrl");
        /// <summary>
        /// integer. The height of the tab in pixels.
        /// </summary>
        public int? Height => JSRef!.Get<int?>("height");
        /// <summary>
        /// boolean. Whether the tab is hidden.
        /// </summary>
        public bool Hidden => JSRef!.Get<bool>("hidden");
        /// <summary>
        /// boolean. Whether the tab is highlighted, i.e. part of the current tab selection. An active tab is always highlighted, but some browsers may allow additional tabs to be highlighted, for example by clicking them while holding Ctrl, Shift or ⌘ Command keys.<br/>
        /// Firefox for Android doesn't support highlighting multiple tabs.
        /// </summary>
        public bool Highlighted => JSRef!.Get<bool>("highlighted");
        /// <summary>
        /// integer. The tab's ID. Tab IDs are unique within a browser session. The tab ID may also be set to tabs.TAB_ID_NONE (-1) for browser windows that don't host content tabs (for example, devtools windows).
        /// </summary>
        public int Id => JSRef!.Get<int>("id");
        /// <summary>
        /// boolean. Whether the tab is in a private browsing window.
        /// </summary>
        public bool Incognito => JSRef!.Get<bool>("incognito");
        /// <summary>
        /// integer. The zero-based index of the tab within its window.
        /// </summary>
        public int Index => JSRef!.Get<int>("index");
        /// <summary>
        /// boolean. True if the tab can be rendered in Reader Mode, false otherwise.
        /// </summary>
        public bool IsArticle => JSRef!.Get<bool>("isArticle");
        /// <summary>
        /// boolean. True if the tab is currently being rendered in Reader Mode, false otherwise.
        /// </summary>
        public bool IsInReaderMode => JSRef!.Get<bool>("isInReaderMode");
        /// <summary>
        /// double. Time at which the tab was last accessed, in milliseconds since the epoch.
        /// </summary>
        public double LastAccessed => JSRef!.Get<double>("lastAccessed");
        /// <summary>
        /// tabs.MutedInfo. The current muted state for the tab and the reason for the last state change.
        /// </summary>
        public MutedInfo? MutedInfo => JSRef!.Get<MutedInfo?>("mutedInfo");
        /// <summary>
        /// integer. The ID of the tab that opened this tab, if any. This property is only present if the opener tab still exists and is in the same window.
        /// </summary>
        public int? OpenerTabId => JSRef!.Get<int?>("openerTabId");
        /// <summary>
        /// string. The URL the tab is navigating to, before it has committed. This property is only present if the extension's manifest includes the "tabs" permission and there is a pending navigation.
        /// </summary>
        public string? PendingUrl => JSRef!.Get<string?>("pendingUrl");
        /// <summary>
        /// boolean. Whether the tab is pinned.
        /// </summary>
        public bool Pinned => JSRef!.Get<bool>("pinned");
        /// <summary>
        /// string. The session ID used to uniquely identify a Tab obtained from the sessions API.
        /// </summary>
        public string? SessionId => JSRef!.Get<string?>("sessionId");
        /// <summary>
        /// string. Either loading or complete.
        /// </summary>
        public string? Status => JSRef!.Get<string?>("status");
        /// <summary>
        /// integer The ID of the tab's successor.
        /// </summary>
        public int? SuccessorTabId => JSRef!.Get<int?>("successorTabId");
        /// <summary>
        /// string. The title of the tab. Only present if the extension has the "tabs" permission or host permissions that matches the tab's URL.
        /// </summary>
        public string? Title=> JSRef!.Get<string?>("title");
        /// <summary>
        /// string. The URL of the document that the tab is displaying. Only present if the extension has the "tabs" permission or a matching host permissions.
        /// </summary>
        public string? Url => JSRef!.Get<string?>("url");
        /// <summary>
        /// integer. The width of the tab in pixels.
        /// </summary>
        public int? Width => JSRef!.Get<int?>("width");
        /// <summary>
        /// integer. The ID of the window that hosts this tab.
        /// </summary>
        public int WindowId=> JSRef!.Get<int>("windowId");
    }
}
