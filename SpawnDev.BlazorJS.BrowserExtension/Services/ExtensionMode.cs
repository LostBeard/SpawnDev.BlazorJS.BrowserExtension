namespace SpawnDev.BlazorJS.BrowserExtension.Services
{
    /// <summary>
    /// Extension mode
    /// </summary>
    public enum ExtensionMode
    {
        /// <summary>
        /// Not running as part of an extension
        /// </summary>
        None,
        /// <summary>
        /// Running as a content script or page
        /// </summary>
        Content,
        /// <summary>
        /// Running as a background script or page
        /// </summary>
        Background,
        /// <summary>
        /// Running as a popup
        /// </summary>
        Popup,
        /// <summary>
        /// Running as an options invocation
        /// </summary>
        Options,
        /// <summary>
        /// Running as an invocation of an install event
        /// </summary>
        Installed,
    }
}
