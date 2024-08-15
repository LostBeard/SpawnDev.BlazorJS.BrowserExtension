using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Describes the kind of action to take if a given RuleCondition matches.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-RuleActionType
    /// </summary>
    public enum RuleActionType
    {
        /// <summary>
        /// Block the network request.
        /// </summary>
        [JsonPropertyName("block")]
        Block,
        /// <summary>
        /// Redirect the network request.
        /// </summary>
        [JsonPropertyName("redirect")]
        Redirect,
        /// <summary>
        /// Allow the network request. The request won't be intercepted if there is an allow rule which matches it.
        /// </summary>
        [JsonPropertyName("allow")]
        Allow,
        /// <summary>
        /// Upgrade the network request url's scheme to https if the request is http or ftp.
        /// </summary>
        [JsonPropertyName("upgradeScheme")]
        UpgradeScheme,
        /// <summary>
        /// Modify request/response headers from the network request.
        /// </summary>
        [JsonPropertyName("modifyHeaders")]
        ModifyHeaders,
        /// <summary>
        /// Allow all requests within a frame hierarchy, including the frame request itself.
        /// </summary>
        [JsonPropertyName("allowAllRequests")]
        AllowAllRequests,
    }
}
