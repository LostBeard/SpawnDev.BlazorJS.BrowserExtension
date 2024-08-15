namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-TabActionCountUpdate
    /// </summary>
    public class TabActionCountUpdate
    {
        /// <summary>
        /// The amount to increment the tab's action count by. Negative values will decrement the count.
        /// </summary>
        public int Incremenet{ get; set; }
        /// <summary>
        /// The tab for which to update the action count.
        /// </summary>
        public int TabId { get; set; }
    }
}
