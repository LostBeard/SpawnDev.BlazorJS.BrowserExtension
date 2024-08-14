using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Read and modify attributes of and listen to clicks on the browser toolbar button defined with the action manifest key.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/action
    /// </summary>
    public class Action : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Action(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Sets the browser action's title. This will be displayed in a tooltip.
        /// </summary>
        public void SetTitle(SetTitleDetails details) => JSRef!.CallVoid("setTitle", details);
        /// <summary>
        /// Gets the browser action's title.
        /// </summary>
        /// <returns></returns>
        public Task<string?> GetTitle(GetTitleDetails details) => JSRef!.CallAsync<string?>("getTitle", details);
        /// <summary>
        /// Sets the browser action's icon.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task SetIcon(SetIconDetails details) => JSRef!.CallVoidAsync("setIcon", details);
        /// <summary>
        /// Sets the HTML document to be opened as a popup when the user clicks on the browser action's icon.
        /// </summary>
        /// <param name="details"></param>
        public void SetPopup(SetPopupDetails details) => JSRef!.CallVoid("setPopup", details);
        /// <summary>
        /// Gets the HTML document set as the browser action's popup.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task<string?> GetPopup(GetPopupDetails details) => JSRef!.CallAsync<string?>("getPopup", details);
        /// <summary>
        /// Open the browser action's popup.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task OpenPopup(OpenPopupDetails details) => JSRef!.CallVoidAsync("openPopup", details);
        /// <summary>
        /// Sets the browser action's badge text. The badge is displayed on top of the icon.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task SetBadgeText(SetBadgeTextDetails details) => JSRef!.CallVoidAsync("setBadgeText", details);
        /// <summary>
        /// Gets the browser action's badge text.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task<string?> GetBadgeText(GetBadgeTextDetails details) => JSRef!.CallAsync<string?>("getBadgeText", details);
        /// <summary>
        /// Sets the badge's background color.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task SetBadgeBackgroundColor(SetBadgeBackgroundColorDetails details) => JSRef!.CallVoidAsync("setBadgeBackgroundColor", details);
        /// <summary>
        /// Gets the badge's background color.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task<int[]?> GetBadgeBackgroundColor(GetBadgeBackgroundColorDetails details) => JSRef!.CallAsync<int[]?>("getBadgeBackgroundColor", details);
        /// <summary>
        /// Sets the badge's text color.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task SetBadgeTextColor(SetBadgeTextColorDetails details) => JSRef!.CallVoidAsync("setBadgeTextColor", details);
        /// <summary>
        /// Gets the badge's text color.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task<int[]?> GetBadgeTextColor(GetBadgeTextColorDetails details) => JSRef!.CallAsync<int[]?>("getBadgeTextColor", details);
        /// <summary>
        /// Gets the user-specified settings for the browser action.
        /// </summary>
        /// <returns></returns>
        public Task<UserSettings> GetUserSettings() => JSRef!.CallAsync<UserSettings>("getUserSettings");
        /// <summary>
        /// Enables the browser action for a tab. By default, browser actions are enabled for all tabs.
        /// </summary>
        public void Enable() => JSRef!.CallVoid("enable");
        /// <summary>
        /// Enables the browser action for a tab. By default, browser actions are enabled for all tabs.
        /// </summary>
        /// <param name="tabId"></param>
        public void Enable(int tabId) => JSRef!.CallVoid("enable", tabId);
        /// <summary>
        /// Disables the browser action for a tab, meaning that it cannot be clicked when that tab is active.
        /// </summary>
        public void Disable() => JSRef!.CallVoid("disable");
        /// <summary>
        /// Disables the browser action for a tab, meaning that it cannot be clicked when that tab is active.
        /// </summary>
        /// <param name="tabId"></param>
        public void Disable(int tabId) => JSRef!.CallVoid("disable", tabId);
        /// <summary>
        /// Checks whether the browser action is enabled or not.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task<bool> IsEnabled(IsEnabledDetails details) => JSRef!.CallAsync<bool>("isEnabled", details);
        /// <summary>
        /// Fired when a browser action icon is clicked. This event will not fire if the browser action has a popup.
        /// </summary>
        public ActionEvent<StorageChanges> OnClicked { get => JSRef!.Get<ActionEvent<StorageChanges>>("onClicked"); set { } }
    }
}
