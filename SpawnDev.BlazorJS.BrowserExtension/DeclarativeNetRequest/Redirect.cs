using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Details describing how a redirect should be performed, as the redirect property of a RuleAction. Only valid for redirect rules.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/declarativeNetRequest/Redirect
    /// </summary>
    public class Redirect
    {
        /// <summary>
        /// A string. The path relative to the extension directory. Should start with '/'. The initiator of the request can only follow the redirect when the resource is listed in web_accessible_resources.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ExtensionPath { get; set; }
        /// <summary>
        /// A string. The substitution pattern for rules that specify a regexFilter. The first match of regexFilter within the URL is replaced with this pattern. Within regexSubstitution, backslash-escaped digits (\1 to \9) are used to insert the corresponding capture groups. \0 refers to the entire matching text.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RegexSubstitution { get; set; }
        /// <summary>
        /// declarativeNetRequest.URLTransform. The URL transformations to perform.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public URLTransform? Transform { get; set; }
        /// <summary>
        /// A string. The redirect URL. Redirects to JavaScript URLs are not allowed.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Url { get; set; }
    }
}
