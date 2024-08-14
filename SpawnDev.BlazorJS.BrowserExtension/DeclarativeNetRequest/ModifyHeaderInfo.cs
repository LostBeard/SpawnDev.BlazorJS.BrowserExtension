using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// The request or response header to modify for a request, declared in the rule.action.requestHeaders array or rule.action.responseHeaders array for rules whose rule.action.type is "modifyHeaders".<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/declarativeNetRequest/ModifyHeaderInfo
    /// </summary>
    public class ModifyHeaderInfo
    {
        /// <summary>
        /// A string. The name of the header to be modified.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Header { get; set; }
        /// <summary>
        /// A string. The operation to be performed on a header. Possible values are "append", "set", and "remove".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Operation { get; set; }
        /// <summary>
        /// A string. The new value for the header. Must be specified for append and set operations. Not allowed for the "remove" operation.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Value { get; set; }
    }
}
