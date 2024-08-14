using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Details describing a URL transformation to perform for a redirect rule. This object can be specified at rule.action.redirect.transform.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/declarativeNetRequest/URLTransform
    /// </summary>
    public class URLTransform
    {
        /// <summary>
        /// A string. The new fragment for the request. Should be either empty, in which case the existing fragment is cleared; or should begin with '#'.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Fragment{ get; set; }
        /// <summary>
        /// A string. The new host name for the request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Host { get; set; }
        /// <summary>
        /// A string. The new password for the request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Password { get; set; }
        /// <summary>
        /// A string. The new path for the request. If empty, the existing path is cleared.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Path { get; set; }
        /// <summary>
        /// A string. The new port for the request. If empty, the existing port is cleared.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Port { get; set; }
        /// <summary>
        /// A string. The new query for the request. Should be either empty, in which case the existing query is cleared; or should begin with '?'.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Query { get; set; }
        /// <summary>
        /// An object describing how to add, remove, or replace query key-value pairs. Cannot be specified if 'query' is specified.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QueryTransform? QueryTransform{ get; set; }
        /// <summary>
        /// A string. The new scheme for the request. Allowed values are "http", "https", and the scheme of the extension, for example, "moz-extension" in Firefox or "chrome-extension" in Chrome. When the extension scheme is used, the host must be specified to generate a meaningful redirection target.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Scheme { get; set; }
        /// <summary>
        /// A string. The new username for the request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Username { get; set; }
    }
}
