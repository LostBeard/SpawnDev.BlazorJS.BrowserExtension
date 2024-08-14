namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Active Tab info<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/tabs/onActivated#activeinfo_2
    /// </summary>
    public class ActiveInfo
    {
        /// <summary>
        /// integer. The ID of the previous activated tab, if that tab is still open.
        /// </summary>
        public int PreviousTabId { get; set; }
        /// <summary>
        /// integer. The ID of the tab that has become active.
        /// </summary>
        public int TabId { get; set; }
        /// <summary>
        /// integer. The ID of the tab's window.
        /// </summary>
        public int WindowId { get; set; }
    }
}
