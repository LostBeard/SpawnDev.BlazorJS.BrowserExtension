namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Details passed to the event handler for Runtime.OnUpdateAvailable<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime/onUpdateAvailable#details
    /// </summary>
    public class OnUpdateAvailableDetails
    {
        /// <summary>
        /// The version number of the update
        /// </summary>
        public string Version { get; set; }
    }
}
