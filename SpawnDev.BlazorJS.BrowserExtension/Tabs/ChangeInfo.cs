namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/tabs/onUpdated#changeinfo_2
    /// </summary>
    public class ChangeInfo
    {
        /// <summary>
        /// boolean. Indicates whether the tab is drawing attention. For example, attention is true when the tab displays a modal dialog.
        /// </summary>
        public bool? Attention { get; set; }
        /// <summary>
        /// boolean. The tab's new audible state.
        /// </summary>
        public bool? Audible { get; set; }
        /// <summary>
        /// boolean. Whether the tab can be discarded by the browser. The default value is true. When set to false, the browser cannot automatically discard the tab. However, the tab can be discarded by tabs.discard.
        /// </summary>
        public bool? AutoDiscardable { get; set; }
        /// <summary>
        /// boolean. Whether the tab is discarded. A discarded tab is one whose content has been unloaded from memory but is visible in the tab strip. Its content gets reloaded the next time it's activated.
        /// </summary>
        public bool? Discarded { get; set; }
        /// <summary>
        /// string. The tab's new favicon URL. Not included when a tab loses its favicon (navigating from a page with a favicon to a page without one). Check favIconUrl in tab instead.
        /// </summary>
        public string? FavIconUrl { get; set; }
        /// <summary>
        /// boolean. True if the tab is hidden.
        /// </summary>
        public bool? Hidden { get; set; }
        /// <summary>
        /// boolean. True if the tab is an article and is therefore eligible for display in Reader Mode.
        /// </summary>
        public bool? IsArticle { get; set; }
        /// <summary>
        /// tabs.MutedInfo. The tab's new muted state and the reason for the change.
        /// </summary>
        public MutedInfo? MutedInfo { get; set; }
        /// <summary>
        /// boolean. The tab's new pinned state.
        /// </summary>
        public bool? Pinned { get; set; }
        /// <summary>
        /// string. The status of the tab. Can be either loading or complete.
        /// </summary>
        public string? Status { get; set; }
        /// <summary>
        /// string. The tab's new title.
        /// </summary>
        public string? Title{ get; set; }
        /// <summary>
        /// string. The tab's URL, if it has changed.
        /// </summary>
        public string? Url { get; set; }
    }
}
