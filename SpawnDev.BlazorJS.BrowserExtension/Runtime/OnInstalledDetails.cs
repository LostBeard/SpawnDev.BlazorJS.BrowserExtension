namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Details passed to the event handler for Runtime.OnInstalled<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime/onInstalled#details
    /// </summary>
    public class OnInstalledDetails
    {
        /// <summary>
        /// string. The ID of the imported shared module extension that updated. This is present only if the reason value is shared_module_update.
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// string. The previous version of the extension just updated. This is only present if the reason value is update.
        /// </summary>
        public string? PreviousVersion { get; set; }
        /// <summary>
        /// An runtime.OnInstalledReason value, stating the reason that this event is being dispatched.
        /// </summary>
        public EnumString<OnInstalledReason>? Reason { get; set; }
        /// <summary>
        /// boolean. True if the add-on was installed temporarily. For example, using the "about:debugging" page in Firefox or using web-ext run. False otherwise.
        /// </summary>
        public bool Temporary { get; set; }
    }
}
