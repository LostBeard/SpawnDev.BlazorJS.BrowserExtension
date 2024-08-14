namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// An object containing the user-specified settings for the browser action.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action/getUserSettings#usersettings
    /// </summary>
    public class UserSettings
    {
        /// <summary>
        /// boolean. Whether the user has pinned the action's icon to the browser UI. This setting does not indicate whether the action icon is visible. The icon's visibility depends on the size of the browser window and the layout of the browser UI.
        /// </summary>
        public bool? IsOnToolbar { get; set; }
    }
}
