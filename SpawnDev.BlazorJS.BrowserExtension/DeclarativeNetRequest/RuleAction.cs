using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Details of the action to take if a rule is matched, as the action property of a declarativeNetRequest.Rule.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/declarativeNetRequest/RuleAction
    /// </summary>
    public class RuleAction
    {
        /// <summary>
        /// declarativeNetRequest.Redirect. Describes how the redirect should be performed. Only valid for redirect rules.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Redirect? Redirect { get; set; }
        /// <summary>
        /// declarativeNetRequest.ModifyHeaderInfo. The request headers to modify for the request. Only valid if type is "modifyHeaders".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ModifyHeaderInfo? RequestHeaders { get; set; }
        /// <summary>
        /// declarativeNetRequest.ModifyHeaderInfo. The response headers to modify for the request. Only valid if type is "modifyHeaders".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ModifyHeaderInfo? ResponseHeaders { get; set; }
        /// <summary>
        /// A string. The type of action to perform. Possible values are "block", "redirect", "allow", "upgradeScheme", "modifyHeaders", and "allowAllRequests". The use of the "redirect" and "modifyHeaders" actions require host permissions for the request and request initiator. The "block" and "upgradeScheme" actions also require host permissions unless the "declarativeNetRequest" permission is specified. Without these permissions, matching rules are ignored. See Permissions at declarativeNetRequest for more information. More details about the effects of rule actions are provided in Matching precedents.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }
    }
}
